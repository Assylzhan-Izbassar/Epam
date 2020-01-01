using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Model;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MVCApplication.Controllers
{
    public class OrderController : Controller
    {
        private IShopRepository repository;

        public OrderController()
        {
            repository = new ShopRepository(new ShopDbContext());
        }

        public IActionResult Index()
        {
            var orders = from order in repository.GetOrders()
                         select order;
            return View(orders);
        }

        public ActionResult Create()
        {
            List<CustomerModel> customers = repository.GetCustomers()
                .Select(c => new CustomerModel { Id = c.CustomerID, Name = c.Name, Surname = c.Surname }).ToList();
            List<ProductModel> products = repository.GetProducts()
                .Select(p => new ProductModel { ProductID = p.ProductID, ProductName = p.ProductName }).ToList();
            List<ProductOrder> productOrders = repository.GetProductOrder().ToList();
            IndexViewModel indexView = new IndexViewModel { Customers = customers , Products = products, ProductOrders = productOrders};
            return View(indexView);
        }
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    repository.InsertOrder(order);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(order);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if(saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Order order = repository.GetOrderByID(id);
            return View(order);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleleConfirmed(int id)
        {
            try
            {
                repository.DeleteOrder(id);
                repository.Save();
            }
            catch(DataException)
            {
                return RedirectToAction("Delete", new { id, V = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            List<CustomerModel> customers = repository.GetCustomers()
                .Select(c => new CustomerModel { Id = c.CustomerID, Name = c.Name, Surname = c.Surname }).ToList();
            List<ProductModel> products = repository.GetProducts()
                .Select(p => new ProductModel { ProductID = p.ProductID, ProductName = p.ProductName }).ToList();
            List<ProductOrder> productOrders = repository.GetProductOrder().ToList();
            Order order = repository.GetOrderByID(id);
            IndexViewModel indexView = new IndexViewModel { Customers = customers, Products = products, ProductOrders = productOrders, Order = order};
            return View(indexView);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.UpdateOrder(order);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(order);
        }

    }
}