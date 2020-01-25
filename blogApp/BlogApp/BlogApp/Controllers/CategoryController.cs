using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataManager _dataManager;

        public CategoryController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var categories = from category in _dataManager.Category.GetCategories()
                             select category;
            return View(categories);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(new Category());
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _dataManager.Category.InsertCategory(category);
                    _dataManager.Category.Save();
                    return RedirectToAction("Index", "Category");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(category);
        }
    }
}