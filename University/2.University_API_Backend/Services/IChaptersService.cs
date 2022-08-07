using _2.University_API_Backend.Models.DataModels;

namespace _2.University_API_Backend.Services
{
    public interface IChaptersService
    {
            public Chapter GetChaptersByCourseId(int courseId);
    }
}