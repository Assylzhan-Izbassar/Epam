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

        public IActionResult Index()
        {
            return View();
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
    }
}