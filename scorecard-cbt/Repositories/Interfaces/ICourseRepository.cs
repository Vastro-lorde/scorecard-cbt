using scorecard_cbt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(string id);
        Task<List<Course>> CreateCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course request);
        Task<bool> Delete(Course request);
    }
}
