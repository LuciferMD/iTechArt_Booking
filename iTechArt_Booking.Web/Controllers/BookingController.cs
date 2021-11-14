
using iTechArt_Booking.Domain.Interfaces;
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
    public class BookingController : Controller
    {
        //   private readonly BookingService bookingService = new BookingService(new BookingFakeRepository());


        IBookingRepository BookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            BookingRepository = bookingRepository;
        }

        [HttpGet(Name = "GetAllBooking")]
        public IEnumerable<Booking> GetAll()
        {
            return BookingRepository.GetAll();
        }

        [HttpGet("{id}", Name ="GetBooking")]
        public IActionResult Get(long id)
        {
            Booking booking = BookingRepository.Get(id);
            if(booking == null)
            {
                return BadRequest();
            }

            return new ObjectResult(booking);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Booking booking)
        {
            if(booking == null)
            {
                return BadRequest();
            }
            BookingRepository.Create(booking);
            return CreatedAtRoute("GetBooking", new { id = booking.Id }, booking);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var deletedBooking = BookingRepository.Get(id);
            if (deletedBooking == null)
            {
                return BadRequest();
            }
            return new ObjectResult(deletedBooking);

        }
    }
}
