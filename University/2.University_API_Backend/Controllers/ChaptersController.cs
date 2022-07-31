using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2.University_API_Backend.DataAccess;
using _2.University_API_Backend.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2.University_API_Backend.Properties;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2.University_API_Backend.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public ChaptersController(UniversityDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChapters()
        {
            return await _context.Chapters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> GetChapter(int id)
        {
            var chapter = await _context.Chapters.FindAsync(id);
            if(chapter == null)
            {
                return NotFound();
            }
            return chapter;
        }

        [HttpPost]
        public async Task<ActionResult<Chapter>> PostChapter(Chapter chapter)
        {
            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetChapter", new { id = chapter.Id }, chapter);
        }

        [HttpPut]
        public async Task<IActionResult> PutChapter(int id, Chapter chapter)
        {
            if(id != chapter.Id)
            {
                return BadRequest();
            }

            _context.Entry(chapter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!ChapterExist(id))
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

        [HttpDelete]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            var chapter = await _context.Chapters.FindAsync(id);

            if(chapter == null)
            {
                return NotFound();
            }
            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();
            return NoContent();
        }



        private bool ChapterExist(int id)
        {
            return _context.Chapters.Any(e => e.Id == id);
        }

    }
}

