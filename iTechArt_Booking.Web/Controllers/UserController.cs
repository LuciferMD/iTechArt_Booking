﻿using iTechArt_Booking.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArt_Booking.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using iTechArt_Booking.Application.Services;

namespace iTechArt_Booking.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [Authorize]
        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> GetAll()
        {
            return userService.GetAll();
        }

        [Authorize]
        [HttpGet("{id}",Name ="GetUser")]
        public IActionResult Get(Guid id)
        {
            User user = userService.Get(id);
            if(user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }


        [Authorize]
        [HttpPost]   
        public IActionResult Create ([FromBody] User user)
        {
            if(user==null)
            {
                return BadRequest();
            }
            userService.Create(user);
            return CreatedAtRoute("GetUser", new { Id = user.Id }, user);
        }


        [Authorize]
        [HttpPut("{id}", Name = "UpdateUser")] // to do
        public IActionResult Update (Guid id,[FromBody] User updatedUser)
        {
            if(updatedUser==null|| updatedUser.Id != id)
            {
                return BadRequest();
            }

            var user = userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            userService.Update(updatedUser);
            return RedirectToRoute("GetAllItems");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete (Guid id)
        {

            var deletedUser = userService.Delete(id);

            if (deletedUser == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedUser);
        }

    }
}
