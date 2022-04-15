using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Models
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid HotelId { get; set; }
        public string Text { get; set; }


    }
}
