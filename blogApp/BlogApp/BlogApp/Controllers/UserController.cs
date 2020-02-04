using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlogApp.Controllers
{
    [Authorize(Roles = "admin, moderator")]
    public class UserController : Controller
    {
        UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        Birthdate = model.Birthdate
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            UserEditModel model = new UserEditModel
            {
                UserId = user.Id,
                Email = user.Email,
                Birthdate = user.Birthdate
            };

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UserEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    User user = await _userManager.FindByIdAsync(model.UserId);

                    if(user != null)
                    {
                        user.Email = model.Email;
                        user.UserName = model.Email;
                        user.Birthdate = model.Birthdate;

                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(string id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }

            User user = await _userManager.FindByIdAsync(id);

            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                User user = await _userManager.FindByIdAsync(id);
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id, V = true });
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = await _userManager.FindByIdAsync(model.Id);

                    if(user != null)
                    {
                        var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User is not found");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

    }
}