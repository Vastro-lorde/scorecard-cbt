using scorecard_cbt.DTOs;
using scorecard_cbt.Models;
using System.Threading.Tasks;

namespace scorecard_cbt.Interfaces
{
    public interface IExamService
    {
        Task<Response<Exam>> DeleteExamAsync(string examId);
        Task<ExamResponseDto> RegisterExamAsync(ExamRegistrationDto registrationRequest);
        Task<Response<ExamDetailResponseDto>> GetExamByIdAsync(string examId);
    }
}
