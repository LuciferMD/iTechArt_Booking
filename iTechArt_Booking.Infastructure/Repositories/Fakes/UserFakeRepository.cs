using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.Fakes
{

    public class UserFakeRepository : IUserRepository
    {
        public List<User> GetAll()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    First_name = "Max",
                    Second_name = "Some text...",
                    Patronymic = "efwe",
                    Tel_number = "ergf"
                },



            };
        }

    }   
}
