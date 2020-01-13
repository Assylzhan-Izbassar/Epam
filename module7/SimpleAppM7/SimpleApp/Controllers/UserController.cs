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
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

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

        public ViewResult Details(int id)
        {
            return View(Repository.GetUserByID(id));
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

            try
            {
                if (ModelState.IsValid && userView.Photo != null)
                {
                    string fileName = SetPhotoPath(userView);
                    string path = "/img/" + Path.GetFileName(userView.Photo.FileName);

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

            UserEditViewModel view = new UserEditViewModel()
            {
                Id = user.UserID,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Age = user.Age,
                ExistingPath = user.PhotoPath
            };
            return View(view);
        }
        [HttpPost]
        [Obsolete]
        public ActionResult Edit(UserEditViewModel userView)
        {
            User user = null;

            try
            {
                if (ModelState.IsValid)
                { 
                    user = Repository.GetUserByID(userView.Id);
                    user.Name = userView.Name;
                    user.Birthdate = userView.Birthdate;
                    user.Age = userView.Age;

                    if(userView.Photo != null)
                    {
                        if(userView.ExistingPath != null)
                        {
                            string oldPath = Path
                                .Combine(@"C:\Users\Brother\Desktop\Epam\module8\SimpleApp\SimpleApp\wwwroot\img", Path.GetFileName(userView.ExistingPath));
                            System.IO.File.Delete(oldPath);
                        }
                        string fileName = SetPhotoPath(userView);
                        string path = "/img/" + Path.GetFileName(userView.Photo.FileName);
                        user.PhotoPath = path;
                    }

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

        [Obsolete]
        private string SetPhotoPath(UserView userView)
        {
            string fileName = Path
                        .Combine(hosting.WebRootPath, "img", Path.GetFileName(userView.Photo.FileName));
            using(var stream = new FileStream(fileName, FileMode.Create))
            {
                userView.Photo.CopyTo(stream);
            }

            return fileName;
        }

        public FileResult Download()
        {
            var list = Repository.GetUsers().ToList();

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < list.Count(); ++i)
            {
                stringBuilder.Append((i + 1) + ")" + list[i].ToString() + "\n");
            }
            string content = stringBuilder.ToString();
            stringBuilder.Clear();

            var binFormater = new BinaryFormatter();
            var ms = new MemoryStream();
            byte[] byteFile = null;

            try
            {
                binFormater.Serialize(ms, content);
            }
            catch (SerializationException e)
            {
                ModelState.AddModelError("", "Failed to serialize. Reason: " + e.Message);
            }
            finally
            {
                byteFile = ms.ToArray();
                ms.Close();
            }

            return File(byteFile, "application/force-download", "data.txt");
        }
    }
}