﻿using iTechArt_Booking.Domain.Interfaces;
using iTechArt_Booking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Context.Hotels;
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
            
        }
    }
}
