using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.EFRepository
{
    public class EFBookingRepository : IBookingRepository
    {
        private BookingDBContext Context;

        public EFBookingRepository(BookingDBContext context)
        {
            Context = context;
        }

        public IEnumerable<Booking> GetAll(Guid userId)
        {
            return Context.Booking.Where(b => b.User.Id == userId);
        }

        public Booking Get(Guid id)
        {
            return Context.Booking.Find(id);
        }
        
        public void Create(Booking booking)
        {
            Context.Booking.Add(booking);
            Context.SaveChanges();
        }

        public Booking Delete(Guid id)
        {
            Booking booking = Get(id);

            if (booking != null)
            {
                Context.Booking.Remove(booking);
                Context.SaveChanges();
            }
            return booking;

        }

    }
}