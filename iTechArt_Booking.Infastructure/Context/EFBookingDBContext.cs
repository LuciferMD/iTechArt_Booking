using iTechArt_Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt_Booking.Infastructure.Repositories.EFRepository
{
    public class EFBookingDBContext : DbContext
    {
        public EFBookingDBContext(DbContextOptions<EFBookingDBContext> options) : base(options) { }


        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<User> Users { get; set; }


    }
}

