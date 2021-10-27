using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public string First_name { get; set; }
        public string Second_name { get; set; }
        public string Patronymic { get; set; }
        public string Tel_number { get; set; }
    }

}
