using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Models
{
    public class RoomModel
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostPerDay { get; set; }

        public byte NumberOfBeds { get; set; }

        public Guid HotelId { get; set; }
    }
}
