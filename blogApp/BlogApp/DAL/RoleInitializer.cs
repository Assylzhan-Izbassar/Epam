using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleInitializer
    {
        public static async Task InitAcync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            string adminEmail = "admin@hotmail.com";
            string adminPassword = "A_shym_13";

            if(await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role("admin"));
            }
            if(await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new Role("user"));
            }
            if(await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    Email = adminEmail,
                    UserName = adminEmail
                };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
