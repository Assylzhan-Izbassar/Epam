using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Models;

namespace BlogApp.Controllers
{
    public class TagController : Controller
    {
        private readonly DataManager _dataManager;

        public TagController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var tags = from tag in _dataManager.Tag.GetTags()
                       select tag;
            return View(tags);
        }
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }

            Tag tag = _dataManager.Tag.GetTagById(id);

            return View(tag);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _dataManager.Tag.DeleteTag(id);
                _dataManager.Tag.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id, V = true });
            }
            return RedirectToAction("Index","Blog");
        }

        [Authorize(Roles = "admin, moderator")]
        public ViewResult Create()
        {
            return View(new TagViewModel());
        }
        [HttpPost]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Create(TagViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Tag tag = new Tag
                    {
                        Name = model.Name,
                        Description = model.Description,
                        UrlSlug = model.UrlSlug
                    };
                    _dataManager.Tag.InsertTag(tag);
                    _dataManager.Tag.Save();

                    return RedirectToAction("Index", "User");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult SaveTag(TagEditModel model)
        {
            try
            {
                if(isValid(model) && ModelState.IsValid)
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
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return Json(false);
        }

        [HttpPost]
        public JsonResult TagList()
        {
            var tags = from tag in _dataManager.Tag.GetTags()
                       select tag;
            if(tags != null)
            {
                return Json(tags);
            }
            return Json(false);
        }

        private bool isValid(TagEditModel tag)
        {
            if (tag.Name == null || (tag.Name.Length < 4 && tag.Name.Length > 15))
            {
                return false;
            }
            if(tag.Description == null || (tag.Description.Length < 5 && tag.Description.Length > 40))
            {
                return false;
            }
            if(tag.UrlSlug == null)
            {
                return false;
            }
            return true;
        }
    }
}