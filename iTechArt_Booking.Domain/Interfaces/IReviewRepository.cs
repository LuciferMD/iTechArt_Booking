using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll();

        void Create(Review review);
    }
}
