using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Application.Services
{
    class RoomService : IRoomRepository
    {
        public readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository _roomRepository)
        {
            roomRepository = _roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }

        public void Create(Room room)
        {
            roomRepository.Create(room);
        }

        public IEnumerable<Room> GetAll()
        {
            return roomRepository.GetAll();
        }
    }
}
