using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.EFRepository
{
    public class EFHotelRepository : IHotelRepository
    {
        private EFBookingDBContext Context;

        public EFHotelRepository (EFBookingDBContext context)
        {
            Context = context;
        }
        public IEnumerable<Hotel> GetAll()
        {
            return Context.Hotels;
        }

        public Hotel Get(long id)
        {
            return Context.Hotels.Find(id);
        }

        public void Create(Hotel hotel)
        {
            Context.Hotels.Add(hotel);
            Context.SaveChanges();
        }

        public void Update(Hotel updatedHotel)
        {
            Hotel currentHotel = Get(updatedHotel.Id);
            currentHotel.Id = updatedHotel.Id;
            currentHotel.Name = updatedHotel.Name;
            currentHotel.Pictures = updatedHotel.Pictures;
            currentHotel.Stars = updatedHotel.Stars;
            currentHotel.Description = updatedHotel.Description;
           

            Context.Hotels.Update(currentHotel);
            Context.SaveChanges();
        } 

        public Hotel Delete (long id)
        {
            Hotel hotel = Get(id);
            if (hotel != null)
            {
                Context.Hotels.Remove(hotel);
                Context.SaveChanges();
            }

            return hotel;
        }

    }
}
