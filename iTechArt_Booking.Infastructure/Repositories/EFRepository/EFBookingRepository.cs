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
        private EFBookingDBContext Context;

        public EFBookingRepository(EFBookingDBContext context)
        {
            Context = context;
        }

        public IEnumerable<Booking> GetAll()
        {
            return Context.Booking;
        }

        public Booking Get(long id)
        {
            return Context.Booking.Find(id);
        }
        
        public void Create(Booking booking)
        {
            Context.Booking.Add(booking);
            Context.SaveChanges();
        }

        public Booking Delete(long id)
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