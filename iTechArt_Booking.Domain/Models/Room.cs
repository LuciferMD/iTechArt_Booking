using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
     public class Room
    {
        public Guid Id { get; set; }
        public string Category { get; set; }

        public float CostPerDay { get; set; }
        public long NumberOfBeds { get; set; }

        public Guid HotelId { get; set; }
    }
}
