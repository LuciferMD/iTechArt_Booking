using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Models
{
    public class ReviewModel
    {

        [Required(ErrorMessage ="Empty id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Empty author id")]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage ="Empty hotel id")]
        public Guid HotelId { get; set; }

        [Required(ErrorMessage ="Empty text")]
        [Range(1,200)]
        public string Text { get; set; }


    }
}
