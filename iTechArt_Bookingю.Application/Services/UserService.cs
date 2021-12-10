using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Application.Services
{
    public class UserService: IUserRepository
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Create(User item)
        {
            userRepository.Create(item);
        }

        public User Delete(Guid id)
        {
            return userRepository.Delete(id);
        }

        public User Get(Guid id)
        {
            return userRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public void Update(User item)
        {
            userRepository.Update(item);
        }
    }
}
