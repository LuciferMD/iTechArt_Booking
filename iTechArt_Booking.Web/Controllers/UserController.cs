﻿using iTechArt_Booking.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArt_Booking.Domain.Services;
using iTechArt_Booking.Domain.Models;

namespace iTechArt_Booking.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository UserRepository;

        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpGet(Name = "GetAllItems")]
        public IEnumerable<User> GetAll()
        {
            return UserRepository.GetAll();
        }


        [HttpGet("{id}",Name ="GetUser")]
        public IActionResult Get(long Id)
        {
            User user = UserRepository.Get(Id);
            if(user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Create ([FromBody] User user)
        {
            if(user==null)
            {
                return BadRequest();
            }
            UserRepository.Create(user);
            return CreatedAtRoute("GetUser", new { Id = user.Id }, user);
        }

        [HttpPut("id")]
        public IActionResult Update (long Id,[FromBody] User updatedUser)
        {
            if(updatedUser==null|| updatedUser.Id != Id)
            {
                return BadRequest();
            }

            var user = UserRepository.Get(Id);
            if (user == null)
            {
                return NotFound();
            }

            UserRepository.Update(updatedUser);
            return RedirectToRoute("GetAllItems");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (long Id)
        {

            var deletedUser = UserRepository.Delete(Id);

            if (deletedUser == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedUser);
        }

    }
}
