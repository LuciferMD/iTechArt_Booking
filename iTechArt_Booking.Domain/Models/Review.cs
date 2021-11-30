using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public class Review
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid HotelId { get; set; }


        public string Text { get; set; }

    }
}
