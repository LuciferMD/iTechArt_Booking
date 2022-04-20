using iTechArt_Booking.Application.Services;
using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using iTechArt_Booking.WebUI.Models;
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
    public class RoomController : Controller
    {
        RoomService roomService;
        HotelService hotelService;
        public RoomController (RoomService _roomService, HotelService _hotelService)
        {
            roomService = _roomService;
            hotelService = _hotelService;
        }

        [Authorize]
        [HttpGet(Name ="GetAllRooms")]
        public IEnumerable<Room> GetAll()
        {
            return roomService.GetAll();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create([FromBody]RoomModel roomM)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(
                    StatusCodes.Status400BadRequest,
                    new
                    {
                        Message = ModelState.Values
                    }
                );
            }

            var hotel = hotelService.Get(roomM.HotelId);

            if (hotel == null)
            {
                return BadRequest(new { message = "The hotel with the specified id does not exist" });
            }

            Room room = new Room
            {
                Id = roomM.Id,
                Category = roomM.Category,
                CostPerDay = roomM.CostPerDay,
                NumberOfBeds = roomM.NumberOfBeds,
                Hotel = hotel
            };

            roomService.Create(room);
            return CreatedAtRoute("GetUser", new { Id = room.Id }, room);     

        }


    }
}
