using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public class Category
    {
        public long Id { get; set; }
        public float Cost_per_day { get; set; }
        public long Number_of_beds { get; set; }
        public string Picture { get; set; }
    }
}
