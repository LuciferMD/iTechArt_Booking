using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.EFRepository
{
    public class EFRoomRepository : IRoomRepository
    {
        private BookingDBContext Context;

        public EFRoomRepository(BookingDBContext context)
        {
            Context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return Context.Rooms;
        }

        public void Create(Room room)
        {
            Context.Rooms.Add(room);
            Context.SaveChanges();
        }
        public Room Get(Guid id)
        {
            return Context.Rooms.Find(id);
        }

        public IEnumerable<Room> GetAllHotels(IEnumerable<Guid> roomsId)
        {
            var rooms = Context.Rooms.Include(r => r.Hotel);

            return rooms;
        }

    }
}
