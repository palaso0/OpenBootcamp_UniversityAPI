using _2.University_API_Backend.Models.DataModels;

namespace _2.University_API_Backend.Services
{
    public interface ICoursesService
    {
            public IEnumerable<Course> GetCoursesByCategory(int categoryId);
            public IEnumerable<Course> GetCoursesWithoutTemarios();
            public IEnumerable<Course> GetCoursesFromStudentId(int studentId);
    }
}