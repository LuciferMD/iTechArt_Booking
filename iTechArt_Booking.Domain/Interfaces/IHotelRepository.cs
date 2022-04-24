using iTechArt_Booking.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Interfaces
{
    public interface IHotelRepository
    {
         IEnumerable<Hotel> GetAll();

         Hotel Get(Guid id);

         void Create(Hotel hotel);

         void Update(Hotel hotel);

         Hotel Delete(Guid id);

         IEnumerable<Review> HotelReviews(Guid id);

         IEnumerable<Room> GetFreeRooms(Guid id, DateTime startDate, DateTime  endTime);

         bool UploadImage(Guid id, IFormFile file);

         FileStream DownloadImage(Guid id);

          
    }

 }
