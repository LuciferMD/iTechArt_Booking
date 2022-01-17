using iTechArt_Booking.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTechArt_Booking.Infastructure.Repositories.EFRepository
{
    public class BookingDBContext : IdentityDbContext<User, IdentityRole<Guid>, Guid> 
    {
        public BookingDBContext(DbContextOptions <BookingDBContext> options) : base(options) { }


        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}

