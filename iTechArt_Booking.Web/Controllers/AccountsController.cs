using iTechArt_Booking.Domain.Models;
using iTechArt_Booking.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
     

        private UserManager<User> userManager;
        private IConfiguration Configuration;
        public AccountsController(UserManager<User> usrMgr, IConfiguration configuration)
        {
            userManager = usrMgr;
            Configuration = configuration;
        }

        [HttpPost("/signup")]
        public async Task<IActionResult> Register (RegisterUserModel regModel)
        {
            var user = new User()
            {
                FirstName = regModel.FirstName,
                Email = regModel.Email,
                UserName = regModel.FirstName,
            };

            var result = await userManager.CreateAsync(user, regModel.Password);

            if (!result.Succeeded)
            {
                return StatusCode(
                        StatusCodes.Status500InternalServerError,
                    new
                    {
                        Message = Configuration["Message:Failed"],
                        Errors = result.Errors
                    }
                );
            }


            return Ok(new
            {
                Message = Configuration["Message:Succes"]
            });
               
        }




        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel logModel)
        {
            var user = await userManager.FindByNameAsync(logModel.Email);

            if (user != null && await userManager.CheckPasswordAsync(user, logModel.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name , user.FirstName)
                          //  new Claim(ClaimTypes.Role, ...) TO DO  
                };

                var SignKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["Identity:JwtKey"]));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(SignKey, SecurityAlgorithms.HmacSha256));

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration=token.ValidTo,
                        id=user.Id
                    });

            }
                return Unauthorized(new
                {
                    Message = Configuration["Message:WrongLog"]
                });;
        }

    }
}
