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

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        [ForeignKey("RoomId")]
        public Guid RoomId { get; set; }

        public char Status { get; set; }
        public DateTime CreationDate { get; set;}
        public DateTime StartDate {get;set;}
        public DateTime EndDate { get; set; }
    }
}
