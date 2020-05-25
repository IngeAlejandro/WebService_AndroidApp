using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSApp.Contexts;
using WSApp.Entities;

namespace WSApp.Controllers
{
    [Route("WS/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DBContext context;

        public UsersController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Users> GetAll()
        {
            return context.Users.ToList();
        }

        [HttpGet("{username}")]
        public Users GetUser(String username)
        {
            var user = context.Users.FirstOrDefault(u => u.username == username);
            return user;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Users user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return Ok("Data Uploaded");
            }
            catch (Exception ex)
            {
               return BadRequest("Bad data input");
            }

        }

        [HttpPut("{username}")]
        public ActionResult Put(string username, [FromBody] Users user)
        {
            if (user.username == username)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                return Ok("Data updated");
            }
            else
            {
                return BadRequest("User not found");
            }

        }

        [HttpDelete("{username}")]
        public ActionResult Delete(string username)
        {
            var user = context.Users.FirstOrDefault(u => u.username == username);
            if (user != null) {
                context.Users.Remove(user);
                context.SaveChanges();
                return Ok("Data deleted");
            }
            else
            {
                return BadRequest("User not found");
            }
        }
    }
}
