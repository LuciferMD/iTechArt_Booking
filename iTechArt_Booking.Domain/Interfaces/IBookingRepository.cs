using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Interfaces
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();

        Booking Get(long id);
        void Create(Booking booking);

        Booking Delete(long id);

    }
}
