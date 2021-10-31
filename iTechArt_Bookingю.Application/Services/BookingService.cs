using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt_Bookingю.Application.Services
{
    public class BookingService
    {
        public readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository _bookingRepository)
        {
            bookingRepository = _bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        public List<Booking> GetAll()
        {
            return bookingRepository.GetAll();
        }
    }
}
