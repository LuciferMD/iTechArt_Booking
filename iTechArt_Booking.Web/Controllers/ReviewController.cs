using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
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
        IReviewRepository ReviewRepository;

        public ReviewController (IReviewRepository reviewRepository)
        {
            ReviewRepository = reviewRepository;
        }

        [HttpGet(Name = "GetAllReview")]
        public IEnumerable<Review> GetAll()
        {
            return ReviewRepository.GetAll();
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Review review)
        {
            if(review == null)
            {
                return BadRequest();
            }

            ReviewRepository.Create(review);
            return CreatedAtRoute("GetReview", new { Id = review.Id }, review);
        }
    }
}
