using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public User Author { get; set; }
        public Hotel Hotel { get; set; }
        public string Text { get; set; }

    }
}
