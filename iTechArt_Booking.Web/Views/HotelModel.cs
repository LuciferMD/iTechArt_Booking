using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Models
{
    public class HotelModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Stars { get; set; }

        public string Pictures { get; set; }

        public string Description { get; set; }

        public IEnumerable<Guid> RoomId { get; set; }

    }
}
