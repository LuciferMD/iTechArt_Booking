using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public   class Booking
    {
        public Guid Id { get; set; }

        public Guid User_id { get; set; }

        public Guid Rooms_id { get; set; }

        public char Status { get; set; }
        public DateTime Date_from {get;set;}
        public DateTime Date_to { get; set; }
    }
}
