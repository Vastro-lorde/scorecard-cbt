using scorecard_cbt.DTOs;
using scorecard_cbt.Models;
using scorecard_cbt.Utilities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Interfaces
{
    public interface ICourseService
    {
        Task<Response<CourseDetailResponseDto>> GetCourseByIdAsync(string courseId);
        Task<Response<string>> UpdateCourseDetails(string Id, UpdateCourseDto updateCourseDto);
        Task<Response<PaginationModel<IEnumerable<GetAllCourseResponseDto>>>> GetAllCoursesAsync(int pageSize, int pageNumber);
        Task<Response<Course>> DeleteCourseAsync(string courseId);
        Task<CourseResponseDto> RegisterCourseAsync(CourseRegistrationDto registrationRequest);
    }
}
