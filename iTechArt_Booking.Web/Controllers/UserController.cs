using iTechArt_Booking.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArt_Booking.Domain.Services;
using iTechArt_Booking.Infastructure.Repositories.Fakes;
using iTechArt_Booking.Domain.Models;

namespace iTechArt_Booking.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService = new UserService(new UserFakeRepository());
        [HttpGet]
        public List<User> GetAll()
        {
            return userService.GetAll();
        }

    }
}
