using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2.University_API_Backend.DataAccess;
using _2.University_API_Backend.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2.University_API_Backend.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public CoursesController(UniversityDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> getCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> getCourse(int id)
        {
            var course= await _context.Courses.FindAsync();
            if(course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        [HttpPut]
        public async Task<IActionResult> PutCourse(int id, Category category)
        {
            if(id != category.Id)
            {
                return BadRequest();
            }
            _context.Entry(category).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!CourseExist(id))
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
        public async Task<IActionResult> DeleteCourse (int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if(course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool CourseExist(int id)
        {
            return _context.Courses.Any(c => c.Id == id);
        }
    }
}

