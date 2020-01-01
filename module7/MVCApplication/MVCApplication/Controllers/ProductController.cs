using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using DAL.Model;
using System.Data;
using DAL.ViewModel;

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
        public ViewResult Details(int id)
        {
            Product product = repository.GetProductByID(id);
            return View(product);
        }

        public ActionResult Create(int customerId)
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.InsertProduct(product);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            Product product = repository.GetProductByID(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.UpdateProduct(product);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(product);
        }
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Product product = repository.GetProductByID(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                repository.DeleteProduct(id);
                repository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id, V = true });
            }
            return RedirectToAction("Index");
        }
    }
}