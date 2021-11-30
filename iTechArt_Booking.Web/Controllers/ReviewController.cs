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

        public ReviewController(IReviewRepository reviewRepository)
        {
            ReviewRepository = reviewRepository;
        }

        [HttpGet(Name = "GetAllReview")]
        public IEnumerable<Review> GetAll()
        {
            return ReviewRepository.GetAll();

        }



        [HttpGet("{id}", Name = "GetReview")]
        public IActionResult Get(Guid id)
        {
            Review review = ReviewRepository.Get(id);
            if (review == null)
            {
                return NotFound();
            }

            return new ObjectResult(review);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest();
            }

            ReviewRepository.Create(review);
            return CreatedAtRoute("GetReview", new { Id = review.Id }, review);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (Guid id)
        {
            var deletedReview = ReviewRepository.Delete(id);

            if (deletedReview == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedReview);
        }
    }
}
