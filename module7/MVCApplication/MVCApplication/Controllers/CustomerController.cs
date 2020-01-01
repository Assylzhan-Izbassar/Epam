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
    public class CustomerController : Controller
    {
        IShopRepository repository;

        public CustomerController()
        {
            repository = new ShopRepository(new ShopDbContext());
        }

        public IActionResult Index()
        {
            var customers = from customer in repository.GetCustomers()
                            select customer;
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = repository.GetCustomerByID(id);
            return View(customer);
        }

        public ActionResult Create()
        {
            return View(new Customer());
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    repository.InsertCustomer(customer);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = repository.GetCustomerByID(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    repository.UpdateCustomer(customer);
                    repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(customer);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Customer customer = repository.GetCustomerByID(id);
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                repository.DeleteCustomer(id);
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