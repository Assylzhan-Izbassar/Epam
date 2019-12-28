using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Model;
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
            return View(new Order());
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
    }
}