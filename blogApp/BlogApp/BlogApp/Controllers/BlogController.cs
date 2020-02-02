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

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly DataManager _dataManager;

        public BlogController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Posts(string searchString, int p = 1)
        {
            var listViewModel = new ListViewModel(_dataManager, p);
            StringBuilder st = new StringBuilder();

            if (!string.IsNullOrEmpty(searchString))
            {
                var posts = new List<Post>();
                foreach (var post in listViewModel.Posts)
                {
                    st.Append(post.Category.Name); st.Append("#"); st.Append(searchString);
                    string temp = st.ToString();
                    st.Clear();

                    List<int> pi = KMPSearch(temp);

                    for (int i = 0; i < pi.Count; ++i)
                    {
                        if (pi[i] == searchString.Length)
                        {
                            posts.Add(post);
                        }
                    }
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
    }
}