using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Models
{
    public class LoginUserModel
    {
        [Required(ErrorMessage ="Empty email")]
        [EmailAddress(ErrorMessage ="Wrong email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Empty eamil")]
        [StringLength(40,ErrorMessage = "Password max 40")]
        public string Password { get; set; }
    }
}
