using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly DataManager _dataManager;

        public CommentController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var comments = from comment in _dataManager.Comment.GetComments()
                           select comment;
            return View(comments);
        }
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }

            Comment comment = _dataManager.Comment.GetCommentById(id);

            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _dataManager.Comment.DeleteComment(id);
                _dataManager.Comment.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id, V = true });
            }
            return RedirectToAction("Index", "Blog");
        }

        [HttpPost]
        public JsonResult SaveComment(Comment model)
        {
            try
            {
                if (model.CommentId > 0)
                {
                    Comment comment = _dataManager.Comment.GetComments().ToList().SingleOrDefault(x => x.CommentId == model.CommentId);
                    comment.UserName = model.UserName;
                    comment.CommentBody = model.CommentBody;
                    comment.PostId = model.PostId;
                    comment.Published = DateTime.Now;
                    _dataManager.Comment.Save();
                    return Json(comment);
                }
                else
                {
                    Comment comment = new Comment
                    {
                        UserName = model.UserName,
                        PostId = model.PostId,
                        CommentBody = model.CommentBody,
                        Published = DateTime.Now
                    };
                    _dataManager.Comment.InsertComment(comment);
                    _dataManager.Comment.Save();
                    return Json(comment);
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return Json(false);
        }

        [Authorize(Roles = "admin, moderator")]
        public ActionResult Edit(int id)
        {
            Comment comment = _dataManager.Comment.GetCommentById(id);
            return View(comment);
        }

        [HttpPost]
        [Authorize(Roles = "admin, moderator")]
        public ActionResult Edit(Comment model)
        {
            Comment comment = null;

            try
            {
                if (ModelState.IsValid)
                {
                    comment = _dataManager.Comment.GetCommentById(model.CommentId);
                    comment.UserName = model.UserName;
                    comment.CommentBody = model.CommentBody;

                    _dataManager.Comment.UpdateComment(comment);
                    _dataManager.Comment.Save();
                    return RedirectToAction("Index", "Blog");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(comment);
        }
    }
}