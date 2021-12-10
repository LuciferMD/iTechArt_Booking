using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public   class Booking
    {
        public Guid Id { get; set; }

        public User User { get; set; } //navigation properties
        public IEnumerable<Room> Rooms { get; set; } //navigation properties

        public char Status { get; set; }
        public DateTime CreationDate { get; set;}
        public DateTime StartDate {get;set;}
        public DateTime EndDate { get; set; }
    }
}
