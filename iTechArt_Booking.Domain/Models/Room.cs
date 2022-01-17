using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{

    public enum Category {Standart, Vip, President }
     public class Room
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostPerDay { get; set; }

        public byte NumberOfBeds { get; set; }

        public Hotel Hotel { get; set; }
    }
}
