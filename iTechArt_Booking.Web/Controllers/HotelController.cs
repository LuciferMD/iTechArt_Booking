using iTechArt_Booking.Application.Services;
using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
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

        IHotelRepository HotelRepository;


        public HotelController (IHotelRepository hotelRepository)
        {
            HotelRepository = hotelRepository;
        }


        [HttpGet(Name ="GetAllHotels")]
        public IEnumerable<Hotel> GetAll()
        {
            return HotelRepository.GetAll();
        }

        [HttpGet("{id}",Name ="GetHotel")]
        public IActionResult Get(long id)
        {
            Hotel hotel = HotelRepository.Get(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return new ObjectResult(hotel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }
            HotelRepository.Create(hotel);
            return CreatedAtRoute("GetHotel", new { id = hotel.Id }, hotel);
            
        }

        [HttpPut("{id}")] //to do
        public IActionResult Update(long id,[FromBody] Hotel updatedHotel)
        {
            if (updatedHotel == null || updatedHotel.Id!=id)
            {
                return BadRequest();
            }

            var hotel = HotelRepository.Get(id);

            if (hotel == null)
            {
                return NotFound();
            }

            HotelRepository.Update(hotel);
            return RedirectToRoute("GetAllHotels");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var deletedHotel = HotelRepository.Delete(id);

            if (deletedHotel == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedHotel);
        }

    }
}
