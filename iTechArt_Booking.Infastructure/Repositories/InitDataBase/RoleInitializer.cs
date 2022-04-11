using iTechArt_Booking.Domain.Models;

using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.InitDataBase
{
    public static class RoleInitializer
    {

        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            string adminEmail = "admin@mail.com";
            string password = "Admin_1234";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>("user"));
            }
            if (await userManager.FindByNameAsync("Admin") == null)
            {
                User admin = new User { FirstName = adminEmail,   Email = adminEmail, UserName ="Admin"};
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }

    }
}
