using System;
using System.Linq;

using _2.University_API_Backend.Models.DataModels;
using _2.University_API_Backend.DataAccess;
namespace _2.University_API_Backend.Services
{
    public class StudentsService: IStudentsService
    {
        private readonly UniversityDBContext _context;

        public IEnumerable<Student> GetStudentsWithCourses()
        {
            var students = from student in _context.Students
                            where student.Courses.Count() > 0
                            select student;
            return students;
        }

        public IEnumerable<Student> GetStudentsWithNoCourses()
        {
            var students = from student in _context.Students
                            where student.Courses.Count() == 0
                            select student;
            return students;
        }
        public IEnumerable<Student> GetStudentsByCourseId(int courseId)
        {
            var students = from Course in _context.Courses
                            where Course.Id == courseId
                            select Course.Students;
            return (IEnumerable<Student>)students;

        }
    }
}

