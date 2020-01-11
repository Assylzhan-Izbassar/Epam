using System.Data;
using DAL.Staff;
using DAL.Models;
using DAL.Repository;
using Task6.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Task6.Controllers
{
    public class AccountController : Controller
    {
        private IAwardRepository repository;

        public AccountController()
        {
            repository = new AwardRepository(new AwardDbContext());
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = await repository.GetUsers().FirstOrDefaultAsync(u => u.Email == model.Email);

                    if (user == null)
                    {
                        user = new User 
                        { 
                            Name = model.Name,
                            Birthdate = model.Birthdate,
                            Email = model.Email, 
                            Password = model.Password 
                        };

                        Role userRole = await repository.GetRoles().FirstOrDefaultAsync(r => r.Name == "user");

                        if (userRole != null)
                            user.Role = userRole;

                        repository.AddUser(user);
                        repository.SaveAsync();

                        await Authenticate(user);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ModelState.AddModelError("", "Incorrect login or password!");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel { ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = await repository.GetUsers()
                        .Include(u => u.Role)
                        .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                    if (user != null)
                    {
                        await Authenticate(user);

                        return Redirect(model.ReturnUrl ?? Url.Action("Index", "Home"));
                    }
                    ModelState.AddModelError("", "Incorrect login or password!");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
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