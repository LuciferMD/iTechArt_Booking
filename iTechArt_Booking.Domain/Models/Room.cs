using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
     public class Room
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public decimal Cost_per_day { get; set; }
        public long Number_of_beds { get; set; }

        public long Hotel_id { get; set; }
    }
}
