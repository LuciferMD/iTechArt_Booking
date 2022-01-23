using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Application.Services
{
    public class HotelService: IHotelRepository 
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


        public Hotel Get(Guid id)
        {
            var hotels = hotelRepository.Get(id);

            return hotels;
        }

        public void Create(Hotel hotel)
        {
             hotelRepository.Create(hotel);
        }

        public Hotel Delete(Guid id)
        {
            return hotelRepository.Delete(id);
        }

        public void Update(Hotel hotel)
        {
           hotelRepository.Update(hotel);
        }


        public IEnumerable<Room> GetFreeRooms(Guid id, DateTime startDate, DateTime endTime)
        {
            return hotelRepository.GetFreeRooms(id, startDate, endTime);
        }

        public IEnumerable<Review> HotelReviews(Guid id)
        {
            return hotelRepository.HotelReviews(id);
        }
         
    }
}
