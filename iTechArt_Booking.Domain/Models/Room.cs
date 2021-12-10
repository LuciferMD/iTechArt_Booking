using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
     public class Room
    {
        public Guid Id { get; set; }
        public string Category { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostPerDay { get; set; }

        public byte NumberOfBeds { get; set; }

        [ForeignKey("HotelFK")]
        public Guid HotelId { get; set; }
    }
}
