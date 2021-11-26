using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.EFRepository
{
    public class EFReviewRepository : IReviewRepository
    {
        private BookingDBContext Context;

        public EFReviewRepository (BookingDBContext context)
        {
            Context = context;
        }
        public void Create(Review review)
        {
            Context.Reviews.Add(review);
            Context.SaveChanges();
        }

        public IEnumerable<Review> GetAll()
        {
            return Context.Reviews;
        }
    }
}
