using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Application.Services
{
    public class ReviewService : IReviewRepository
    {
        public readonly IReviewRepository reviewRepository;

        public ReviewService (IReviewRepository _reviewRepository)
        {
            reviewRepository = _reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
        }


        public void Create(Review review)
        {
            reviewRepository.Create(review);
        }

        public Review Delete(Guid id)
        {
           return reviewRepository.Delete(id);
        }

        public Review Get(Guid id)
        {
            return reviewRepository.Get(id);
        }

        public IEnumerable<Review> GetAll()
        {
            return reviewRepository.GetAll();
        }
    }
}
