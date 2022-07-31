using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2.University_API_Backend.DataAccess;
using _2.University_API_Backend.Models.DataModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2.University_API_Backend.Controllers
{
    [Route("v1/api/[controller]")] //localhost:7297/api/Users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public UsersController(UniversityDBContext context)
        {
            _context = context;
        }


        //GET 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.Id }, user); //Devuelve un 201, llama al método GetUser y retorna el user
        }

        //PUT
        [HttpPut]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent(); 
        }

        //PATCH
        [HttpPatch]
        public async Task<IActionResult> PatchUser(int id,[FromBody] JsonPatchDocument<User> userPatch)
        {
            
            var user = await _context.Users.FindAsync(id);
            if (userPatch != null)
            {
                userPatch.ApplyTo(user);
                return Ok(user);
            }
            return BadRequest();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

       
    }
}

