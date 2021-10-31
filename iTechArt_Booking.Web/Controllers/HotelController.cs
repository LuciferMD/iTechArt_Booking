using iTechArt_Booking.Application.Services;
using iTechArt_Booking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArt_Booking.Infastructure.Repositories.Fakes;

namespace iTechArt_Booking.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService hotelService = new HotelService(new HotelFakeRepository());
        [HttpGet]

    public List<Hotel> GetAll()
        {
            return hotelService.GetAll();
        }
    }
}
