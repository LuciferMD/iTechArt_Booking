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

        public float Cost_per_day { get; set; }
        public long Number_of_beds { get; set; }

        public Guid Hotel_id { get; set; }
    }
}
