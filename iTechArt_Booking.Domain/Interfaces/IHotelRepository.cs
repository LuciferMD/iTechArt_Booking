using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Interfaces
{
    public interface IHotelRepository
    {
         IEnumerable<Hotel> GetAll();

         Hotel Get(long id);

         void Create(Hotel hotel);

         void Update(Hotel hotel);

         Hotel Delete(long id); 
    }

 }
