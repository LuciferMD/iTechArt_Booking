using iTechArt_Booking.Domain.Models;
using iTechArt_Booking.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private UserManager<User> userManager;
        public AccountsController(UserManager<User> usrMgr)
        {
            userManager = usrMgr;
        }

        [HttpPost("/signup")]
        public async Task<IActionResult> Register (RegisterUserModel regModel)
        {
            var user = new User()
            {
                Email = regModel.Email,
                UserName = regModel.FirstName,
                FirstName = regModel.FirstName,
                LastName = regModel.LastName,
                SecondName = regModel.SecondName,
                PhoneNumber = regModel.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, regModel.Password);

            if (!result.Succeeded)
            {
                return StatusCode(
                        StatusCodes.Status500InternalServerError,
                    new
                    {
                        Message = "User creation failed",
                        Errors = result.Errors
                    }
                );
            }


            return Ok(new
            {
                Status = "Succes",
                Message = "User created successfully"
            });
               
        }


    }
}
