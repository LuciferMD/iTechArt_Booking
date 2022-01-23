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
//using iTechArt_Booking.Infastructure.Repositories.Fakes;

namespace iTechArt_Booking.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        //   private readonly HotelService hotelService = new Booking(new HotelFakeRepository());

        HotelService hotelService;
        RoomService roomService;

        public HotelController (HotelService _hotelService, RoomService _roomService)
        {
            hotelService = _hotelService;
            roomService = _roomService;
        }


        [Authorize]
        [HttpGet(Name ="GetAllHotels")]
        public IEnumerable<Hotel> GetAll()
        {
            return hotelService.GetAll();
        }



        [HttpGet("{id}",Name ="GetHotel")]
        public IActionResult Get(Guid id)
        {
            Hotel hotel = hotelService.Get(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return new ObjectResult(hotel);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] HotelModel hotelM)
        {
            if (hotelM == null)
            {
                return BadRequest();
            }

            var rooms = roomService.GetAllHotels(hotelM.RoomId);

            Hotel hotel = new Hotel
            {
                Id = hotelM.Id,
                Name = hotelM.Name,
                Stars = hotelM.Stars,
                Pictures = hotelM.Pictures,
                Description = hotelM.Description,
                Rooms = rooms,
                Reviews = null,
            };

            hotelService.Create(hotel);
            return CreatedAtRoute("GetHotel", new { id = hotel.Id }, hotel);
            
        }



        [Authorize]
        [HttpPut("{id}")] //to do
        public IActionResult Update(Guid id,[FromBody] Hotel updatedHotel)
        {
            if (updatedHotel == null || updatedHotel.Id!=id)
            {
                return BadRequest();
            }

            var hotel = hotelService.Get(id);

            if (hotel == null)
            {
                return NotFound();
            }

            hotelService.Update(hotel);
            return RedirectToRoute("GetAllHotels");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deletedHotel = hotelService.Delete(id);

            if (deletedHotel == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedHotel);
        }

        
        [Authorize]
        [HttpGet("{HotelId}/rooms",Name = "GetFreeRooms")]
        public IActionResult GetFreeRooms(Guid HotelId , DateTime startDate, DateTime endDate)
        {   
            var rooms = hotelService.GetFreeRooms(HotelId,startDate , endDate);

            return new ObjectResult(rooms);
        }

        [Authorize]
        [HttpGet("{id}/reviews", Name = "GetHotelReviews")]

        public IActionResult HotelReviews(Guid id)
        {
            var reviews = hotelService.HotelReviews(id);

            return new ObjectResult(reviews);
        }


    }
}
