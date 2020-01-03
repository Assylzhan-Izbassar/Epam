using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repository;
using DAL.Staff;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DAL.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SimpleApp.Controllers
{
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

        public ActionResult Create()
        {
            return View(new AwardView());
        }
        [HttpPost]
        [Obsolete]
        public ActionResult Create(AwardView awardView)
        {
            Award award = null;
            string fileName = null;
            string path = null;

            try
            {
                if(ModelState.IsValid && awardView.Image != null)
                {
                    fileName = Path
                        .Combine(hosting.WebRootPath, "img", Path.GetFileName(awardView.Image.FileName));
                    awardView.Image.CopyTo(new FileStream(fileName, FileMode.Create));
                    path = "/img/" + Path.GetFileName(awardView.Image.FileName);

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

    }
}