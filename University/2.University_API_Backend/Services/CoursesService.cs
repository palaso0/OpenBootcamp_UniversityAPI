using System.Reflection.Metadata.Ecma335;
using System;
using System.Linq;
using _2.University_API_Backend.Models.DataModels;
using _2.University_API_Backend.DataAccess;

namespace _2.University_API_Backend.Services
{
    public class CoursesService: ICoursesService
    {
        private readonly UniversityDBContext _context;
        public IEnumerable<Course> GetCoursesByCategory(int categoryId)
        {

            IEnumerable<Course> coursesFromCategory = (IEnumerable<Course>)(from category in _context.Categories
                                    where category.Id == categoryId
                                    select category.Courses);

            return coursesFromCategory;
        }
        public IEnumerable<Course> GetCoursesWithoutTemarios()
        {
            IEnumerable<Course> coursesFromCategory = from course in _context.Courses
                                                      where course.Chapter.List == null
                                                      select course;
            return coursesFromCategory;
        }
        public IEnumerable<Course> GetCoursesFromStudentId(int studentId)
        {
            var courses = from student in _context.Students
                          where student.Id == studentId
                          select student.Courses;
            return (IEnumerable<Course>)courses;
        }
    }
}

