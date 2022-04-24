using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace iTechArt_Booking.Infastructure.Repositories.EFRepository
{
    public class EFHotelRepository : IHotelRepository
    {
        private BookingDBContext Context;

        public EFHotelRepository (BookingDBContext context)
        {
            Context = context;
        }
        public IEnumerable<Hotel> GetAll()
        {
            return Context.Hotels.Include(x => x.Rooms).Include(x =>x.Reviews);
        }

        public Hotel Get(Guid id)
        {
            return Context.Hotels.Find(id);
        }

        public void Create(Hotel hotel)
        {
            Context.Hotels.Add(hotel);
            Context.SaveChanges();
        }

        public void Update(Hotel updatedHotel)
        {
            Hotel currentHotel = Get(updatedHotel.Id);
            currentHotel.Id = updatedHotel.Id;
            currentHotel.Name = updatedHotel.Name;
            currentHotel.Pictures = updatedHotel.Pictures;
            currentHotel.Stars = updatedHotel.Stars;
            currentHotel.Description = updatedHotel.Description;
           

            Context.Hotels.Update(currentHotel);
            Context.SaveChanges();
        } 

        public Hotel Delete (Guid id)
        {
            Hotel hotel = Get(id);
            if (hotel != null)
            {
                Context.Hotels.Remove(hotel);
                Context.SaveChanges();
            }

            return hotel;
        }
        
        public IEnumerable<Room> GetFreeRooms(Guid hotelId, DateTime startDate, DateTime endDate)
        {
            /*
             Hotel hotel = Get(hotelId);

             if (hotel == null) //to services
             {
              throw new Exception("There isn't such hotel!");        
             }

             IEnumerable<Room> freeRooms = Context.Rooms.Where(r=>r.HotelId== hotelId);
             List<Guid> guids = freeRooms.Select(r => r.Id).ToList();

             List<Guid> bookedGuids =  Context.Booking.Where(b => guids.Contains(b.RoomId) && b.StartDate <= startDate && b.EndDate >= endDate).Select(b=>b.RoomId).ToList();
             var freeGuids = guids.Except(bookedGuids);
             freeRooms = Context.Rooms.Where(r => freeGuids.Contains(r.Id));

             return freeRooms;
             */
            return null;
            
        }

        public IEnumerable<Review> HotelReviews(Guid id)
        {
            Hotel hotel = Get(id);

            if (hotel == null) 
            {
                throw new Exception("There isn't such hotel!");
            }

            return Context.Reviews.Where(r => r.Hotel.Id == id);
        }

        public bool UploadImage(Guid id, IFormFile file)
        {
            Hotel hotel = Get(id);

            string path = "..\\iTechArt_Booking.Infastructure\\Images\\Hotels\\" + hotel.Name+".png";

            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyToAsync(stream);
            stream.Close();

            hotel.Pictures = path;
            Context.Hotels.Update(hotel);
            Context.SaveChanges();

            return true;
        }

        public FileStream DownloadImage(Guid id)
        {
            Hotel hotel = Get(id);
            string path = hotel.Pictures;

            if (!File.Exists(path))
            {
                throw new Exception("There isn't image!");
            }

            return new FileStream(path, FileMode.Open);

        }

        public bool DeleteImage(Guid id)
        {
            Hotel hotel = Get(id);
            string path = hotel.Pictures;


            if (!File.Exists(path))
            {
                return false;
                throw new Exception("There isn't image!");
              
            }
            FileInfo fileInf = new FileInfo(path);

            fileInf.Delete();

            hotel.Pictures = string.Empty;
            Context.Hotels.Update(hotel);
            Context.SaveChanges();

            return true;

        }
    }
}
