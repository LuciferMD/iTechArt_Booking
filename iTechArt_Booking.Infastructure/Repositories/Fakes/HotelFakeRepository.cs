using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.Fakes
{
    public class HotelFakeRepository//: IHotelRepository
    {
        public List<Hotel> GetAll()
        {
            return new List<Hotel>()
            {
                new Hotel
                {
                    Id = Guid.NewGuid(),
                    Name ="Moscow Hotel",
                    Stars =5,
                    Pictures="Yand//fff//fff",
                    Description ="Ver nice."
                   
                },

                  new Hotel
                {
                    Id = Guid.NewGuid(),
                    Name ="Billy Hotel",
                    Stars =2,
                    Pictures="Yand//fff//fff2",
                    Description ="So so."
                   
                },

                   new Hotel
                {
                    Id = Guid.NewGuid(),
                    Name ="Askey Hotel",
                    Stars =4,
                    Pictures="Yand//fff//fff3",
                    Description ="It's skrskrskrskr."
                },

                  new Hotel
                {
                    Id = Guid.NewGuid(),
                    Name ="Normandia Hotel",
                    Stars =5,
                    Pictures="Yand//fff//fff4",
                    Description ="In Normandes"
                },

                            new Hotel
                {
                    Id = Guid.NewGuid(),
                    Name ="Sport Hotel",
                    Stars =4,
                    Pictures="Yand//fff//fff5",
                    Description ="Whith sportes club."
                },

            };
        }
    }
}
