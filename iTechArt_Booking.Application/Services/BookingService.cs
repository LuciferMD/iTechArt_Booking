using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt_Booking.Application.Services
{
    public class BookingService : IBookingRepository
    {
        public readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository _bookingRepository)
        {
            bookingRepository = _bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        public void Create(Booking booking)
        {
            bookingRepository.Create(booking);
        }

        public Booking Delete(Guid id)
        {
            return bookingRepository.Delete(id);
        }

        public Booking Get(Guid id)
        {
            return bookingRepository.Get(id);
        }

        public IEnumerable<Booking> GetAll(Guid userId)
        {
            return bookingRepository.GetAll(userId);
        }
    }
}
