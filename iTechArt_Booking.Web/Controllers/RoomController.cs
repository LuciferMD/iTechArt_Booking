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
    public class RoomController : Controller
    {
        IRoomRepository RoomRepository;

        public RoomController (IRoomRepository roomRepository)
        {
            RoomRepository = roomRepository;
        }

        [HttpGet(Name ="GetAllRooms")]
        public IEnumerable<Room> GetAll()
        {
            return RoomRepository.GetAll();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody]Room room)
        {
            if (room == null)
            {
                return BadRequest();
            }
            RoomRepository.Create(room);
            return CreatedAtRoute("GetUser", new { Id = room.Id }, room);     

        }


    }
}
