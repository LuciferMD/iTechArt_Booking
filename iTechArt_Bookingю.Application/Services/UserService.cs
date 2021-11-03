using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

    }
}
