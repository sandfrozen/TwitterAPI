using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TwitterAPI.Models;
using System.Linq;

namespace TwitterAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly TwitterAPIContext _context;

        public UserController(TwitterAPIContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { name = "Sample Adam", email = "sample@email.com" });
                _context.SaveChanges();
            }
        }

        [HttpGet("/api/users")]
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
            var item = _context.Users.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Users.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = item.id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] User item)
        {
            if (item == null || item.id != id)
            {
                return BadRequest();
            }

            var user = _context.Users.FirstOrDefault(t => t.id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.name = item.name;
            user.email = item.email;

            _context.Users.Update(user);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _context.Users.FirstOrDefault(t => t.id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return new NoContentResult();
        }


    }
}