using iTechArt_Booking.Domain.Interfaces;
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
    [Authorize(Roles="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

       
        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> GetAll()
        {
            return userService.GetAll();
        }

       
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
