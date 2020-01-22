using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly DataManager _dataManager;

        public BlogController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public ViewResult Posts(int p = 1)
        {
            var listViewModel = new ListViewModel(_dataManager, p);

            return View(listViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            List<Category> categories = _dataManager.Category.GetCategories().ToList();

            ViewBag.Categories = categories;

            return View(new PostViewModel());
        }
        [HttpPost]
        public ActionResult Create(PostViewModel postModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Post post = new Post
                    {
                        Title = postModel.Title,
                        Description = postModel.Description,
                        ShortDescription = postModel.Description.Substring(0, 30),
                        Category = postModel.Category,
                        UrlSlug = Request.Scheme
                    };

                    List<PostTag> postTags = postModel.Tags.Select(tag => new PostTag
                    {
                        Post = post,
                        Tag = tag
                    }).ToList();

                    post.PostTags = postTags;

                    if(postModel.Published == true)
                    {
                        post.Published = true;
                        post.PostedOn = DateTime.Now;
                    }
                    else
                    {
                        post.Published = false;
                    }

                    _dataManager.Post.InsertPost(post);

                    return RedirectToAction("Posts");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(postModel);
        }
    }
}