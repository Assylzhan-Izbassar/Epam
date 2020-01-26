using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
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
    }
}