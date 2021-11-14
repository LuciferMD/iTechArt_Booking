using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(long id);

        void Create(User item);

        void Update(User item);
        User Delete(long id);

    }
}
