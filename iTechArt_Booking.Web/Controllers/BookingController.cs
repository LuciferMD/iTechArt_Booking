using iTechArt_Booking.Application.Services;
using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class BookingController : Controller
    {
        //   private readonly BookingService bookingService = new BookingService(new BookingFakeRepository());


        BookingService bookingService;

        public BookingController(BookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        
        [HttpGet(Name = "GetAllBooking")]
        public IEnumerable<Booking> GetAll()
        {
            return bookingService.GetAll();
        }

        [HttpGet("{id}", Name ="GetBooking")]
        public IActionResult Get(Guid id)
        {
            Booking booking = bookingService.Get(id);
            if(booking == null)
            {
                return BadRequest();
            }

            return new ObjectResult(booking);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] Booking booking)
        {
            if(booking == null)
            {
                return BadRequest();
            }
            bookingService.Create(booking);
            return CreatedAtRoute("GetBooking", new { id = booking.Id }, booking);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deletedBooking = bookingService.Get(id);
            if (deletedBooking == null)
            {
                return BadRequest();
            }
            return new ObjectResult(deletedBooking);

        }
    }
}
