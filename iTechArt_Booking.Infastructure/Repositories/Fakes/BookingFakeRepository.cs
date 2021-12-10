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
                    Id =Guid.NewGuid(),
                    User = { },   ////Question
                    
                    Status = Status.New,
                    StartDate = new DateTime(2001, 01, 21),
                    EndDate = new DateTime(2001, 01, 27)
                },

                    new Booking
                {
                    Id =Guid.NewGuid(),
                    User = { },

                    Status = Status.Cancelled,
                    StartDate = new DateTime(2005, 01, 11),
                    EndDate = new DateTime(2005, 01, 17)
                },

                        new Booking
                {
                    Id =Guid.NewGuid(),
                    User = { },
                    Status = Status.New,
                    StartDate = new DateTime(2017, 02, 21),
                    EndDate = new DateTime(2017, 02, 27)
                },

                            new Booking
                {
                    Id =Guid.NewGuid(),
                    User = { },
                    Status = Status.New,
                    StartDate = new DateTime(2020, 04, 27),
                    EndDate = new DateTime(2021, 05, 07)
                },

                                new Booking
                {
                    Id =Guid.NewGuid(),
                    User = { },
                    Status = Status.Paid,
                    StartDate = new DateTime(2021, 11, 01),
                    EndDate = new DateTime(2001, 11, 16)
                },
            };
        }

    }
}
