using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Models
{
    public class HotelModel
    {
        [Required(ErrorMessage ="Empty id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Empty name")]
        public string Name { get; set; }

        [Range(0,5)]
        public int Stars { get; set; }
     
        public string Pictures { get; set; }

        public string Description { get; set; }

        public IEnumerable<Guid> RoomId { get; set; }

    }
}
