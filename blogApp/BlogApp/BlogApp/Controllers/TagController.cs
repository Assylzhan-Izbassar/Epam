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

        public ViewResult Create()
        {
            return View(new TagViewModel());
        }
        [HttpPost]
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
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return Json(false);
        }
    }
}