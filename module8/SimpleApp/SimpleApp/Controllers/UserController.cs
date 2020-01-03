using System;
using System.Linq;
using DAL.Repository;
using DAL.Staff;
using DAL.Models;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DAL.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SimpleApp.Controllers
{
    public class UserController : Controller
    {
        private IAwardRepository Repository;
        [Obsolete]
        private readonly IHostingEnvironment hosting;

        [Obsolete]
        public UserController(IHostingEnvironment hosting)
        {
            Repository = new AwardRepository(new AwardDbContext());
            this.hosting = hosting;
        }

        public IActionResult Index()
        {
            var users = from user in Repository.GetUsers()
                        select user;
            return View(users);
        }

        public ActionResult Create()
        {
            return View(new UserView());
        }
        [HttpPost]
        [Obsolete]
        public ActionResult Create(UserView userView)
        {
            User user = null;
            string path, fileName = null;

            try
            {
                if (ModelState.IsValid && userView.Photo != null)
                {
                    fileName = Path
                        .Combine(hosting.WebRootPath, "img", Path.GetFileName(userView.Photo.FileName));
                    userView.Photo.CopyTo(new FileStream(fileName, FileMode.Create));
                    path = "/img/" + Path.GetFileName(userView.Photo.FileName);

                    user = new User()
                    {
                        Name = userView.Name,
                        Birthdate = userView.Birthdate,
                        Age = userView.Age,
                        PhotoPath = path
                    };

                    Repository.AddUser(user);
                    Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }

            User user = Repository.GetUserByID(id);

            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Repository.DeleteUser(id);
                Repository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id, V = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            User user = Repository.GetUserByID(id);

            UserView view = new UserView()
            {
                Name = user.Name,
                Birthdate = user.Birthdate,
                Age = user.Age
            };
            return View(view);
        }
        [HttpPost]
        [Obsolete]
        public ActionResult Edit(UserView userView)
        {
            User user = null;
            string path, fileName = null;

            try
            {
                if (ModelState.IsValid && userView.Photo != null)
                {
                    fileName = Path
                        .Combine(hosting.WebRootPath, "img", Path.GetFileName(userView.Photo.FileName));
                    userView.Photo.CopyTo(new FileStream(fileName, FileMode.Create));
                    path = "/img/" + Path.GetFileName(userView.Photo.FileName);

                    user = new User()
                    {
                        Name = userView.Name,
                        Birthdate = userView.Birthdate,
                        Age = userView.Age,
                        PhotoPath = path
                    };

                    Repository.UpdateUser(user);
                    Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user);
        }
    }
}