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
                    Second_name = "markiy",
                    Patronymic = "Maximovich",
                    Tel_number = "666"
                },

                new User
                {
                    Id = 2,
                    First_name = "Ricky",
                    Second_name = "Ticky.",
                    Patronymic = "Tavi",
                    Tel_number = "+37512121212"
                },

                new User
                {
                    Id = 3,
                    First_name = "bob",
                    Second_name = "Bobobi",
                    Patronymic = "-",
                    Tel_number = "0000"
                },

            };
        }

    }   
}
