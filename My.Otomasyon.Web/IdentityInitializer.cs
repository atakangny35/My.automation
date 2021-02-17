using Microsoft.AspNetCore.Identity;
using My.Otomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.Otomasyon.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {

            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                AppRole role = new AppRole()
                {
                    Name = "Admin"
                };
                await roleManager.CreateAsync(role);
                var memberRole = await roleManager.FindByNameAsync("Perconel");
                if (memberRole == null)
                {
                    await roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Perconel"
                    });
                }
                var CurrentRole = await roleManager.FindByNameAsync("Current");
                if (CurrentRole == null)
                {
                    await roleManager.CreateAsync(new AppRole()
                    {
                        Name = "Current"
                    });
                }
                var denem = await roleManager.FindByNameAsync("deneme");
                if (denem == null)
                {
                    await roleManager.CreateAsync(new AppRole()
                    {
                        Name = "deneme"
                    });
                }
                var adminUser = await userManager.FindByNameAsync("atakan");
                if (adminUser == null)
                {
                    AppUser user = new AppUser()
                    {
                        Name = "Atakan",
                        Email = "atakan@gmail.com",
                        UserName = "atakan",
                        Surname = "günay"
                    };

                    await userManager.CreateAsync(user, "123456");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
