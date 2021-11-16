using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.Fakes
{

    public class UserFakeRepository //: IUserRepository
    {
        public List<User> GetAll()
        {
            return new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(),          
                    FirstName = "Max",
                    SecondName = "markiy",
                    LastName = "Maximovich",
                    PhoneNumber = "666"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Ricky",
                    SecondName = "Ticky.",
                    LastName = "Tavi",
                    PhoneNumber = "+37512121212"
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "bob",
                    SecondName = "Bobobi",
                    LastName = "-",
                    PhoneNumber = "0000"
                },

            };
        }

    }   
}
