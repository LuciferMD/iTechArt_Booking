using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public class Hotel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public int Stars { get; set; }

        public string Pictures { get; set; }

        public string Description { get; set; }

       
    }
}
