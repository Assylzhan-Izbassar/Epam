using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PL.Models;

namespace BlogApp.Controllers
{
    public class PostController : Controller
    {
        private readonly DataManager _dataManager;

        public PostController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var posts = from post in _dataManager.Post.GetPosts()
                        select post;
            return View(posts);
        }

        public IActionResult Create()
        {
            List<Category> categories = _dataManager.Category.GetCategories().ToList();
            List<Tag> tags = _dataManager.Tag.GetTags().ToList();

            ViewBag.Categories = new SelectList(categories, "Name", "Name");
            ViewBag.Tags = new SelectList(tags, "Name", "Name");

            var model = new IndexViewModel { Tags = tags, Categories = categories };

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(IndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Post post = new Post
                    {
                        Title = model.Post.Title,
                        Description = model.Post.Description,
                        ShortDescription = model.Post.ShortDescription,
                        Meta = model.Post.Meta,
                        UrlSlug = model.Post.UrlSlug,
                        Category = _dataManager.Category.GetCategoryById(model.Category.CategoryId)
                    };

                    PostTag postTag = new PostTag
                    {
                        Post = post,
                        Tag = _dataManager.Tag.GetTagById(model.Tag.TagId)

                    };

                    _dataManager.PostTag.AddPostTag(postTag);

                    if (model.Post.Published == true)
                    {
                        post.Published = true;
                        post.PostedOn = DateTime.Now;
                    }
                    else
                    {
                        post.Published = false;
                    }

                    _dataManager.Post.InsertPost(post);
                    _dataManager.Post.Save();

                    return RedirectToAction("Index", "Blog");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }
    }
}