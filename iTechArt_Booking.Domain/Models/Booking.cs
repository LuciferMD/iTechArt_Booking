using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public   class Booking
    {
        public long Id { get; set; }

        public User User { get; set; }

        public Room Rooms { get; set; }

        public char Status { get; set; }
        public DateTime Date_from {get;set;}
        public DateTime Date_to { get; set; }
    }
}
