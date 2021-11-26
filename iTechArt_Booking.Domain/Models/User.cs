using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace iTechArt_Booking.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }    
    }

}
//save user in db
//add servise and controller   // moddel in web //registrationnmodels.cs