using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Interfaces
{
     public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();

        void Create(Room room);

        Room Get(Guid id);

        IEnumerable<Room> GetAllHotels(IEnumerable<Guid> RoomsId);
    }

}
