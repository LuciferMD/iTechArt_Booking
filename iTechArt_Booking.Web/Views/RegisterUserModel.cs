using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt_Booking.WebUI.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage ="Empty name")]
        [StringLength(20,MinimumLength =4,ErrorMessage ="Name must be from 4 to 20")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Empty email")]
        [EmailAddress(ErrorMessage ="Wrong email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Empty password")]
        [StringLength(40,ErrorMessage ="Password max 40")]
        public string Password { get; set; }

    }
}
