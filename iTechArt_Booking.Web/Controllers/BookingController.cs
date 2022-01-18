using iTechArt_Booking.Application.Services;
using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using iTechArt_Booking.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        //   private readonly BookingService bookingService = new BookingService(new BookingFakeRepository());


        BookingService bookingService;
        UserService userService;
        RoomService roomService;

        public BookingController(BookingService _bookingService, UserService _userService, RoomService _roomService)
        {
            bookingService = _bookingService;
            userService = _userService;
            roomService = _roomService;
        }

        [Authorize]
        [HttpGet(Name = "GetAllBooking")]
        public IEnumerable<Booking> GetAll()
        {
            return bookingService.GetAll();
        }


        [Authorize]
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
        public IActionResult Create([FromBody] BookingModel bookingM)
        {
            if(bookingM == null)
            {
                return BadRequest();
            }

            User user = userService.Get(bookingM.UserId);
            if (user == null)
            {
               return BadRequest(new { message = "The user with the specified id does not exist" });
            }

            Room room = roomService.Get(bookingM.RoomId);
            if(room == null)
            {
                return BadRequest(new { message = "The room with the specified id does not exist" });
            }

            var booking = new Booking()
            {
                Id = bookingM.Id,
                Status = bookingM.Status,
                CreationDate = DateTime.Now,
                StartDate = bookingM.StartDate,
                EndDate = bookingM.StartDate,
                Room = room,
                User = user
            };

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
