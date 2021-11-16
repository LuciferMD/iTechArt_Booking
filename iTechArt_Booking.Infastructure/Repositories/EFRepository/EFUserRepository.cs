using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTechArt_Booking.Infastructure.Repositories.EFRepository
{
    public class EFUserRepository : IUserRepository
    {
        private EFBookingDBContext Context;

        public EFUserRepository(EFBookingDBContext context)
        {
            Context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return Context.Users;
        }

        public User Get(Guid Id)
        {
            return Context.Users.Find(Id);
        }

        public void Create(User item)
        {
            Context.Users.Add(item);
            Context.SaveChanges();
        }

        public void Update(User updatedUser)
        {
            User curentItem = Get(updatedUser.Id);
            curentItem.Id = updatedUser.Id;
            curentItem.First_name = updatedUser.First_name;
            curentItem.Patronymic = updatedUser.Patronymic;
            curentItem.Second_name = updatedUser.Second_name;
            curentItem.Tel_number = updatedUser.Tel_number;

            Context.Users.Update(curentItem);
            Context.SaveChanges();
        }

        public User Delete(Guid Id)
        {
            User user = Get(Id);

            if (user != null)
            {
                Context.Users.Remove(user);
                Context.SaveChanges();
            }
            return user;
        }
    }
}
