using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL.Entities;
using PL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly DataManager _dataManager;
        private StringBuilder st = new StringBuilder();

        public BlogController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Posts(string searchString, string searchOption = "Category", int p = 1)
        {
            var listViewModel = new ListViewModel(_dataManager, p);

            if (!string.IsNullOrEmpty(searchString))
            {
                var posts = new List<Post>();
                List<PostTag> postTags = _dataManager.PostTag.GetPostTags()
                    .OrderBy(t => t.PostId)
                    .ToList();

                switch (searchOption)
                {
                    case "Tag":
                        foreach(var post in listViewModel.Posts)
                        {
                            foreach(var postTag in postTags)
                            {
                                if(post.PostId == postTag.PostId)
                                {
                                    Tag tag = _dataManager.Tag.GetTagById(postTag.TagId);

                                    if (isAddPost(tag.Name, searchString, post))
                                    {
                                        posts.Add(post);
                                    }
                                }
                            }
                        }
                        break;
                    case "Posts":
                        foreach (var post in listViewModel.Posts)
                        {
                            if(isAddPost(post.Title, searchString, post))
                            {
                                posts.Add(post);
                            }
                        }
                        break;
                    default:
                        foreach (var post in listViewModel.Posts)
                        {
                            if(isAddPost(post.Category.Name, searchString, post))
                            {
                                posts.Add(post);
                            }
                        }
                        break;
                    
                }
                listViewModel.Posts = posts.ToList();
            }

            return View(listViewModel);
        }

        public PartialViewResult Sidebars()
        {
            var widgetViewModel = new WidgetViewModel(_dataManager);
            return PartialView("_Sidebars", widgetViewModel);
        }

        public ActionResult Archives()
        {
            return View(_dataManager.Post.GetPosts().ToList());
        }

        private List<int> KMPSearch(string s)
        {
            int n = s.Length;
            List<int> prefixFunction = new List<int>();

            for (int i = 0; i < n; ++i)
            {
                prefixFunction.Add(0);
            }

            for (int i = 1; i < n; ++i)
            {
                int j = prefixFunction[i - 1];
                while (j > 0 && s[i] != s[j])
                {
                    j = prefixFunction[j - 1];
                }
                if (s[i] == s[j]) ++j;
                prefixFunction[i] = j;
            }
            return prefixFunction;
        }

        private bool isAddPost(string name, string searchString, Post post)
        {
            st.Append(name); st.Append("#"); st.Append(searchString);
            string temp = st.ToString();
            st.Clear();

            List<int> pi = KMPSearch(temp);

            for (int i = 0; i < pi.Count; ++i)
            {
                if (pi[i] == searchString.Length)
                {
                    return true;
                }
            }
            return false;
        }
    }
}