using System.Reflection.Metadata.Ecma335;
using System;
using System.Linq;
using _2.University_API_Backend.Models.DataModels;
using _2.University_API_Backend.DataAccess;

namespace _2.University_API_Backend.Services
{
    public class ChapterService: IChaptersService
    {
        private readonly UniversityDBContext _context;
        public Chapter GetChaptersByCourseId(int courseId)
        {
            var chapterQuery = from chapter in _context.Chapters
                          where chapter.Course.Id == courseId  
                          select chapter;

            return (Chapter)chapterQuery;
        }
    }
}

