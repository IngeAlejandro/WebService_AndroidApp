using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using WSApp.Contexts;
using WSApp.Entities;

namespace WSApp.Controllers
{
    [Route("WS/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private DBContext context;

        public ScoresController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet("{top}")]
        public ActionResult GetGlobal(int top)
        {
            var data = context.Users
                .Join(
                    context.Scores, 
                    user => user.username, 
                    score => score.User.username, 
                    (user, score) => new
        {
            username = user.username,
            score = score.score,
            country = user.country
        }).OrderByDescending(d => d.score).Take(top);
            return Ok(data);
        }

        [HttpGet("{top}/{username}")]
        public ActionResult GetUsername(int top, String username)
        {
            var data = context.Users
                .Join(
                    context.Scores,
                    user => user.username,
                    score => score.User.username,
                    (user, score) => new
                    {
                        username = user.username,
                        score = score.score,
                        country = user.country
                    }).Where(d => d.username == username).OrderByDescending(d => d.score).Take(top);
            return Ok(data);
        }

        [HttpGet("{top}/code={country}")]
        public ActionResult GetCountry(int top, String country)
        {
            var data = context.Users
                .Join(
                    context.Scores,
                    user => user.username,
                    score => score.User.username,
                    (user, score) => new
                    {
                        username = user.username,
                        score = score.score,
                        country = user.country
                    }).Where(d => d.country == country).OrderByDescending(d => d.score).Take(top);
            return Ok(data);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Scores score)
        {
            try
            {
                context.Scores.Add(score);
                context.SaveChanges();
                return Ok("Data uploaded");
            }
            catch (Exception ex)
            {
                return BadRequest("Bad data input");
            }

        }

    }
}
