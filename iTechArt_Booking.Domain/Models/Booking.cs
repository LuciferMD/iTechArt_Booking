using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public enum Status
    {
        New,
        Paid,
        Cancelled,
        Fulfiled
    }
    public   class Booking
    {
        public Guid Id { get; set; }

        public Status Status { get; set; }
        public DateTime CreationDate { get; set;}
        public DateTime StartDate {get;set;}
        public DateTime EndDate { get; set; }
        public User User { get; set; } //navigation properties
        public Room Room { get; set; } //navigation properties
    }
}
