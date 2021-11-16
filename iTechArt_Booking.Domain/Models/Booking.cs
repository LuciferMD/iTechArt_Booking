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

        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }

        public char Status { get; set; }
        public DateTime StartDate {get;set;}
        public DateTime EndDate { get; set; }
    }
}
