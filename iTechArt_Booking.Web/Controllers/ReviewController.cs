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
    public class ReviewController : Controller
    {
        ReviewService reviewService;
        HotelService hotelService;
        UserService userService;
        public ReviewController(ReviewService _reviewService, HotelService _hotelService, UserService _userService)
        {
            reviewService = _reviewService;
            hotelService = _hotelService;
            userService = _userService;
        }


        [Authorize]
        [HttpGet(Name = "GetAllReview")]
        public IEnumerable<Review> GetAll()
        {
            return reviewService.GetAll();

        }


        [Authorize]
        [HttpGet("{id}", Name = "GetReview")]
        public IActionResult Get(Guid id)
        {
            Review review = reviewService.Get(id);
            if (review == null)
            {
                return NotFound();
            }

            return new ObjectResult(review);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] ReviewModel reviewM)
        {
            if (reviewM == null)
            {
                return BadRequest();
            }

            var hotel = hotelService.Get(reviewM.HotelId);
            if(hotel == null)
            {
                return BadRequest(new { message = "The hotel with the specified id does not exist" });
            }

            var user = userService.Get(reviewM.AuthorId);
            if (user == null)
            {
                return BadRequest(new { message = "The author with the specified id does not exist" });
            }


            Review review = new Review
            {
                Id = reviewM.Id,
                Text = reviewM.Text,
                Author = user,
                Hotel = hotel

            };

            reviewService.Create(review);
            return CreatedAtRoute("GetReview", new { Id = review.Id }, review);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete (Guid id)
        {
            var deletedReview = reviewService.Delete(id);

            if (deletedReview == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedReview);
        }
    }
}
