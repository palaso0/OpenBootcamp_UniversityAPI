using _2.University_API_Backend.Models.DataModels;

namespace _2.University_API_Backend.Services
{
    public interface IStudentsService
    {
            IEnumerable<Student> GetStudentsWithCourses();
            IEnumerable<Student> GetStudentsWithNoCourses();   
            IEnumerable<Student> GetStudentsByCourseId(int courseId);
            
    }
}