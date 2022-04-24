using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
            var hotel = hotelRepository.Get(id);

            return hotel;
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

        public bool UploadImage(Guid id, IFormFile file)
        {
            return hotelRepository.UploadImage(id,file);
        }

        public FileStream DownloadImage(Guid id)
        {
            return hotelRepository.DownloadImage(id);
        }

        public bool DeleteImage(Guid id)
        {
            return hotelRepository.DeleteImage(id);
        }
    }
}
