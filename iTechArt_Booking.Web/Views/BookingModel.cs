using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Models
{

    public class BookingModel
    {
        [Required(ErrorMessage ="Empty id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage ="Empty status")]
        [DataType("Status")]
        public Status Status { get; set; }


        [Required(ErrorMessage ="Empty start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage ="Empty end date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


        [Required(ErrorMessage ="Empty user id")]
        public Guid UserId { get; set; }


        [Required(ErrorMessage ="Empty room id")]
        public Guid RoomId { get; set; } 
    }
}
