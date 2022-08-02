using System;
using System.Linq;
using _2.University_API_Backend.DataAccess;
using _2.University_API_Backend.Models.DataModels;
namespace _2.University_API_Backend.Services
{
    public class Services
    {
        
        private readonly UniversityDBContext _context;

        public IQueryable<User> getUserByMail(string email)
        {
            var user = _context.Users.Where(user => user.Email.Equals(email));
            return user;
        }

        public IQueryable<Student> getStudentsAdults()
        {
            var students = _context.Students.Where(student => (DateTime.Now.Year - student.Dob.Year) > 18);
            return students;
        }

        public IQueryable<Student> GetStudentsAtLeastUneCourse()
        {
            var students = _context.Students.Where(student => 
            student.Courses.Count() > 0
            );
            return students;
        }

        public IQueryable<Course> getCoursesAtLeastOneStudent(Enum lvl)
        {
            var courses = _context.Courses.Where(course =>
            course.Level.Equals(lvl) && course.Students.Count()>0
            );
            return courses;
        }

        public IQueryable<Course> getCoursesAtLeastOneStudent(Enum lvl, Category category)
        {
            var courses = _context.Courses.Where(course =>
            course.Level.Equals(lvl) && course.Categories.Any(category =>
            category.Equals(category)
            )
            );
            return courses;
        }

        public IQueryable<Course> getCourseWithoutStudents()
        {
            var courses = _context.Courses.Where( course =>
                course.Students.Count() == 0
            );
            return courses;
        }
    }
}

