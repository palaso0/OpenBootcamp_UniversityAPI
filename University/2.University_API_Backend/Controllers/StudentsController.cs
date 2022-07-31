using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2.University_API_Backend.DataAccess;
using _2.University_API_Backend.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2.University_API_Backend.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class StudentControllers : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public StudentControllers(UniversityDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> getStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> getStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostStudent(Student Student)
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetStudent", new { id = Student.Id }, Student); //Devuelve un 201, llama al método GetUser y retorna el user
        }

        [HttpPut]
        public async Task<IActionResult> PutStudent(int id, Student Student)
        {
            if (id != Student.Id)
            {
                return BadRequest();
            }
            _context.Entry(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent (int id)
        {
            var student= await _context.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(s => s.Id == id);
        }
    }
}

