using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repository;
using DAL.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using SimpleApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SimpleApp.Controllers
{
    public class AccountController : Controller
    {
        private IAwardRepository repository;

        public AccountController()
        {
            repository = new AwardRepository(new AwardDbContext());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = repository.GetUsers().FirstOrDefault(u => u.Email == model.Email);

                    if (user == null)
                    {
                        user = new User
                        {
                            Name = model.Name,
                            Birthdate = model.Birthdate,
                            Email = model.Email,
                            Password = model.Password
                        };
                        Role userRole = repository.GetRoles().FirstOrDefault(u => u.Name == "user");
                        if (userRole != null)
                        {
                            user.Role = userRole;
                        }
                        repository.AddUser(user);
                        repository.Save();
                        await Authenticate(user);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect login or password!");
                    }
                    RedirectToAction("Index", "Home");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = repository.GetUsers()
                        .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                    if(user != null)
                    {
                        await Authenticate(user);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Incorrect login or password!");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}