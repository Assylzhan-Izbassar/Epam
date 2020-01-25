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

        public PartialViewResult Sidebars()
        {
            var widgetViewModel = new WidgetViewModel(_dataManager);
            return PartialView("_Sidebars", widgetViewModel);
        }

        public ViewResult Create()
        {
            List<Category> categories = _dataManager.Category.GetCategories().ToList();
            List<Tag> tags = _dataManager.Tag.GetTags().ToList();

            ViewBag.Categories = new SelectList(categories, "Name", "Name");
            ViewBag.Tags = new SelectList(tags, "Name", "Name");

            PostEditModel postModel = new PostEditModel { Tags = tags, Categories = categories };

            return View(postModel);
        }
        [HttpPost]
        public ActionResult Create(PostEditModel postModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Post post = new Post
                    {
                        Title = postModel.Title,
                        Description = postModel.Description,
                        ShortDescription = postModel.Description.Substring(0, 3),
                        Category = _dataManager.Category.GetCategoryById(postModel.Category.CategoryId)
                    };

                    PostTag postTag = new PostTag
                    {
                        Post = post,
                        Tag = _dataManager.Tag.GetTagById(postModel.Tag.TagId)

                    };

                    _dataManager.PostTag.AddPostTag(postTag);

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
                    _dataManager.Post.Save();

                    return RedirectToAction("Index", "User");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(postModel);
        }

        [HttpPost]
        public JsonResult SaveTag(TagEditModel model)
        {
            try
            {
                if (model.TagId > 0)
                {
                    Tag tag = _dataManager.Tag.GetTags().ToList().SingleOrDefault(x => x.TagId == model.TagId);
                    tag.Name = model.Name;
                    tag.Description = model.Description;
                    tag.UrlSlug = model.UrlSlug;
                    _dataManager.Tag.Save();
                    return Json(tag);
                }
                else
                {
                    Tag tag = new Tag
                    {
                        Name = model.Name,
                        Description = model.Description,
                        UrlSlug = model.UrlSlug
                    };
                    _dataManager.Tag.InsertTag(tag);
                    _dataManager.Tag.Save();
                    return Json(tag);
                }
            }
            catch(DataException)
            {

            }
            return Json(false);
        }
    }
}