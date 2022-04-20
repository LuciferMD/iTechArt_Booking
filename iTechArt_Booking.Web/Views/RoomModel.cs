using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Models
{
    public class RoomModel
    {
        [Required(ErrorMessage ="Empty id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Empty category")]
        [DataType("Category")]
        public Category Category { get; set; }

        [Required(ErrorMessage ="Empty cost")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostPerDay { get; set; }

        [Required(ErrorMessage ="Empty number of beds")]
        public byte NumberOfBeds { get; set; }

        [Required(ErrorMessage = "Empty hotel id")]
        public Guid HotelId { get; set; }
    }
}
