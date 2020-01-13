using System;
using System.Linq;
using DAL.Staff;
using DAL.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using DAL.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using DAL.Repository;

namespace Task6.Controllers
{
    public class UserController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment hosting;
        private IAwardRepository Repository;

        [Obsolete]
        public UserController(IHostingEnvironment hosting)
        {
            Repository = new AwardRepository(new AwardDbContext());
            this.hosting = hosting;
        }

        #region Main methods to show item(s)
        [Route("users")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var users = from user in Repository.GetUsers()
                        select user;
            return View(users);
        }

        [Route("users/{name:maxlength(10)}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult ListByName(string name)
        {
            List<User> users = null;
            if (name.Length == 1)
            {
                users = Repository.GetUsers()
                .Where(x => x.Name[0] == name[0])
                .ToList();
            }
            else
            {
                users = Repository.GetUsers()
                .Where(x => x.Name == name)
                .ToList();
            }

            return View(users);
        }

        [Route("user/{id:int}")]
        [Authorize(Roles = "admin, user")]
        public ViewResult Details(int id)
        {
            return View(Repository.GetUserByID(id));
        }
        #endregion

        #region Methods that show awards
        [Authorize(Roles = "admin, user")]
        public ViewResult Awards(int id)
        {
            User user = Repository.GetUserByID(id);

            List<AwardEditView> awards = Repository.GetAwards().Select(award => new AwardEditView
            {
                Id = award.AwardID,
                Title = award.Title,
                Description = award.Description,
                ExistingPath = award.ImagePath,
                UserID = user.UserID
            }).ToList();

            List<UserAward> userAwards = Repository.GetUserAwards().ToList();

            IndexViewModel indexView = new IndexViewModel { Awards = awards, User = user, UserAwards = userAwards };

            return View(indexView);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult RewardUser(IndexViewModel index)
        {
            User user = Repository.GetUserByID(index.User.UserID);
            Award award = Repository.GetAwardByID(index.AwardEdit.Id);

            if (user != null && award != null)
            {
                UserAward userAward = new UserAward
                {
                    Users = user,
                    Awards = award
                };
                Repository.AddUserAward(userAward);
                Repository.Save();
            }
            return RedirectToAction("Award", new { user.UserID });
        }
        #endregion

        #region Create action of a user
        [HttpGet("/create-user")]
        [Authorize(Roles = "admin")]
        public PartialViewResult Create()
        {
            return PartialView(new UserView());
        }

        [Obsolete]
        [HttpPost("/create-user")]
        [Authorize(Roles = "admin")]
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
        #endregion

        #region Delete ActionResult
        [Route("user/{id:int}/delete")]
        [Authorize(Roles = "admin")]
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
        [Route("user/{id:int}/delete")]
        [Authorize(Roles = "admin")]
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
        #endregion

        #region Edit action of a user
        [Route("user/{id:int}/edit")]
        [Authorize(Roles = "admin")]
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

        [Obsolete]
        [HttpPost]
        [Route("user/{id:int}/edit")]
        [Authorize(Roles = "admin")]
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

                    if (userView.Photo != null)
                    {
                        if (userView.ExistingPath != null)
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
        #endregion

        [Obsolete]
        private string SetPhotoPath(UserView userView)
        {
            string fileName = Path
                        .Combine(hosting.WebRootPath, "img", Path.GetFileName(userView.Photo.FileName));
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                userView.Photo.CopyTo(stream);
            }

            return fileName;
        }

        /*public FileResult Download()
        {
            var list = Repository.GetUsers().ToList();
            MemoryStream stream = null;
            using (stream = new MemoryStream(list.Count()))
            {
                IFormatter formatter = new BinaryFormatter();
                foreach (var data in list)
                {
                    formatter.Serialize(stream, data);
                }
                stream.Seek(0, SeekOrigin.Begin);
                object file = formatter.Deserialize(stream);
            }

            return File(stream, ".txt");
        }*/

        public JsonResult Remove(int id)
        {
            User user = Repository.GetUserByID(id);

            if(user != null)
            {
                Repository.DeleteUser(id);
                Repository.Save();

                return Json(true);
            }
            return Json(false);
        }
    }
}