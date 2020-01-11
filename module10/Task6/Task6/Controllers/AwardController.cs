using System;
using System.IO;
using System.Linq;
using DAL.Staff;
using DAL.Models;
using System.Data;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using DAL.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Task6.Controllers
{
    [Authorize]
    public class AwardController : Controller
    {
        private IAwardRepository Repository;
        [Obsolete]
        private IHostingEnvironment hosting;

        [Obsolete]
        public AwardController(IHostingEnvironment hosting)
        {
            Repository = new AwardRepository(new AwardDbContext());
            this.hosting = hosting;
        }

        public IActionResult Index()
        {
            var awards = from award in Repository.GetAwards()
                         select award;
            return View(awards);
        }

        public ViewResult Details(int id)
        {
            return View(Repository.GetAwardByID(id));
        }
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View(new AwardView());
        }
        [HttpPost]
        [Obsolete]
        [Authorize(Roles = "admin")]
        public ActionResult Create(AwardView awardView)
        {
            Award award = null;

            try
            {
                if(ModelState.IsValid && awardView.Image != null)
                {
                    string fileName = SetPhotoPath(awardView);
                    string path = "/img/" + Path.GetFileName(awardView.Image.FileName);

                    award = new Award()
                    {
                        Title = awardView.Title,
                        Description = awardView.Description,
                        ImagePath = path
                    };

                    Repository.AddAward(award);
                    Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(award);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Award award = Repository.GetAwardByID(id);
            return View(award);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Repository.DeleteAward(id);
                Repository.Save();
            }
            catch(DataException)
            {
                return RedirectToAction("Delete", new { id, V = true });
            }
            return RedirectToAction("Index");
        }

        [Obsolete]
        private string SetPhotoPath(AwardView awardView)
        {
            string fileName = Path
                        .Combine(hosting.WebRootPath, "img", Path.GetFileName(awardView.Image.FileName));
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                awardView.Image.CopyTo(stream);
            }

            return fileName;
        }

        public ViewResult Edit(int id)
        {
            Award award = Repository.GetAwardByID(id);

            AwardEditView view = new AwardEditView
            {
                Id = award.AwardID,
                Title = award.Title,
                Description = award.Description,
                ExistingPath = award.ImagePath
            };

            return View(view);
        }

        [HttpPost]
        [Obsolete]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(AwardEditView awardView)
        {
            Award award = null;

            try
            {
                if(ModelState.IsValid)
                {
                    award = Repository.GetAwardByID(awardView.Id);

                    award.Title = awardView.Title;
                    award.Description = awardView.Description;

                    if (awardView.Image != null)
                    {
                        if(awardView.ExistingPath != null)
                        {
                            string oldPath = Path
                                .Combine(@"C:\Users\Brother\Desktop\Epam\module8\SimpleApp\SimpleApp\wwwroot\img", Path.GetFileName(awardView.Image.FileName));
                            System.IO.File.Delete(oldPath);
                        }
                        string filePath = SetPhotoPath(awardView);
                        string path = "/img/" + Path.GetFileName(awardView.Image.FileName);
                        award.ImagePath = path;
                    }

                    Repository.UpdateAward(award);
                    Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(award);
        }

    }
}