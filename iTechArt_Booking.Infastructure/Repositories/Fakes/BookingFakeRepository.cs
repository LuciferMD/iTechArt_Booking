using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.Fakes
{
    public class BookingFakeRepository// : IBookingRepository
    {
        public List<Booking> GetAll()
        {
            return new List<Booking>() {
                new Booking
                {
                    Id = 1,
                    User_id = 1,   ////Question
                    Rooms_id =1,
                    Status = 'N',
                    Date_from = new DateTime(2001, 01, 21),
                    Date_to = new DateTime(2001, 01, 27)
                },

                    new Booking
                {
                    Id = 2,
                    User_id = 2,  
                    Rooms_id = 1,
                    Status = 'N',
                    Date_from = new DateTime(2005, 01, 11),
                    Date_to = new DateTime(2005, 01, 17)
                },

                        new Booking
                {
                    Id = 3,
                    User_id = 1,
                    Rooms_id = 2,
                    Status = 'F',
                    Date_from = new DateTime(2017, 02, 21),
                    Date_to = new DateTime(2017, 02, 27)
                },

                            new Booking
                {
                    Id = 4,
                   User_id = 3,
                    Rooms_id = 1,
                    Status = 'F',
                    Date_from = new DateTime(2020, 04, 27),
                    Date_to = new DateTime(2021, 05, 07)
                },

                                new Booking
                {
                    Id = 5,
                    User_id = 3,
                    Rooms_id = 2,
                    Status = 'N',
                    Date_from = new DateTime(2021, 11, 01),
                    Date_to = new DateTime(2001, 11, 16)
                },
            };
        }

    }
}
