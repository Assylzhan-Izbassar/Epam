using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using DAL.Model;
using System.Data;

namespace MVCApplication.Controllers
{
    public class ProductController : Controller
    {
        private IShopRepository repository;

        public ProductController()
        {
            repository = new ShopRepository(new ShopDbContext());
        }

        public IActionResult Index()
        {
            var products = from product in repository.GetProducts()
                           select product;
            return View(products);
        }

        public ActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    repository.InsertProduct(product);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(product);
        }
    }
}