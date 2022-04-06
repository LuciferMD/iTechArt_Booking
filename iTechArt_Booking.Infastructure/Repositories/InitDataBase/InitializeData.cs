using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using iTechArt_Booking.Infastructure.Repositories.EFRepository;
using Microsoft.AspNetCore.Identity;

namespace iTechArt_Booking.Infastructure.Repositories.InitDataBase
{
    public class InitializeData
    {
        private BookingDBContext Context;
        private RoleManager<IdentityRole> roleManager;
        private readonly IUserRepository userRepository;
        public InitializeData(BookingDBContext _context, RoleManager<IdentityRole> _roleManager)
        {
            Context = _context;
            roleManager = _roleManager;
        }

        public async void  Initialize()
        {
            bool roleExist = await roleManager.RoleExistsAsync("Admin");
            if (!roleExist)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);


              /*  var user = new User();
                user.FirstName = "adminchik";
                user.Email = "admin@mail.ru";
                user.PasswordHash = "Admin_1234";

                userRepository.Create(user);

                */

                Context.SaveChanges();
            }
        }

    }
}
