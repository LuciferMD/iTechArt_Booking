using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string First_name { get; set; }
        public string Second_name { get; set; }
        public string Patronymic { get; set; }
        public string Tel_number { get; set; }
    }

}
//save user in db
//add servise and controller   // moddel in web //registrationnmodels.cs