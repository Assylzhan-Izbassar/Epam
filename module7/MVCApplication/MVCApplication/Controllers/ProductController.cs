using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using DAL.Model;
using System.Data;
using DAL.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MVCApplication.Controllers
{
    public class ProductController : Controller
    {
        private IShopRepository repository;
        [Obsolete]
        private readonly IHostingEnvironment hosting;

        [Obsolete]
        public ProductController(IHostingEnvironment hosting)
        {
            this.hosting = hosting;
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

        public ActionResult Create()
        {
            return View(new ProductModel());
        }
        [HttpPost]
        [Obsolete]
        public ActionResult Create(ProductModel productModel)
        {
            Product product = null;
            string fileName = null;
            string path = null;
            try
            {
                if (ModelState.IsValid)
                {
                    if(productModel.Picture != null)
                    {
                        fileName = Path
                            .Combine(hosting.WebRootPath, "img", Path.GetFileName(productModel.Picture.FileName));
                        productModel.Picture.CopyTo(new FileStream(fileName, FileMode.Create));
                        path = "/img/" + Path.GetFileName(productModel.Picture.FileName);
                    }
                    product = new Product() {
                        ProductName = productModel.ProductName,
                        Quantity = productModel.Quantity,
                        Price = productModel.Price,
                        DateOfProduction = productModel.DateOfProduction,
                        UnitsInStock = productModel.UnitsInStock,
                        UnitsOnOrder = productModel.UnitsOnOrder,
                        ImageUrl = path
                    };

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