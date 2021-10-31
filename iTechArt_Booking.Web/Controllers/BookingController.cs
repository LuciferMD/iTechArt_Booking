
using iTechArt_Booking.Domain.Models;
using iTechArt_Booking.Infastructure.Repositories.Fakes;
using iTechArt_Bookingю.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService bookingService = new BookingService(new BookingFakeRepository());
        [HttpGet]

        public List<Booking> GetAll()
        {
            return bookingService.GetAll();
        }
    }
}
