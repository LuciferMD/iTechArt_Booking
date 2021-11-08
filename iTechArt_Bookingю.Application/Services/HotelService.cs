using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Application.Services
{
    public class HotelService
    {
        private readonly IHotelRepository hotelRepository;

        public HotelService(IHotelRepository _hotelRepository)
        {
            hotelRepository = _hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        }

        public IEnumerable<Hotel> GetAll()
        {
            return hotelRepository.GetAll();
        }
    }
}
