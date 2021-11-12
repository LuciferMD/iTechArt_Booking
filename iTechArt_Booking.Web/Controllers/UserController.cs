using iTechArt_Booking.Domain.Interfaces;
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

        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> GetAll()
        {
            return UserRepository.GetAll();
        }


        [HttpGet("{id::long}",Name ="GetUser")]
        public IActionResult Get(long id)
        {
            User user = UserRepository.Get(id);
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
        public IActionResult Update (long id,[FromBody] User updatedUser)
        {
            if(updatedUser==null|| updatedUser.Id != id)
            {
                return BadRequest();
            }

            var user = UserRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            UserRepository.Update(updatedUser);
            return RedirectToRoute("GetAllItems");
        }

        [HttpDelete("{id::long}")]
        public IActionResult Delete (long id)
        {

            var deletedUser = UserRepository.Delete(id);

            if (deletedUser == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedUser);
        }

    }
}
