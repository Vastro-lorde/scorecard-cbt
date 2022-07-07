using scorecard_cbt.DTOs;
using scorecard_cbt.Models;
using scorecard_cbt.Utilities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Interfaces
{
    public interface IQuestionService
    {
        Task<Response<Question>> CreateQuestionAsync(QuestionRequestDto createQuestion);
        Task<Response<Question>> DeleteQuestionAsync(string QuestionId);
        Task<Response<PaginationModel<IEnumerable<GetAllQuestionsResponseDto>>>> GetAllQuestionsAsync(int pageSize, int pageNumber);
        Task<Response<QuestionDetailResponseDto>> GetQuestionByIdAsync(string QuestionId);
        Task<Response<string>> UpdateQuestionDetails(string QuestionId, UpdateQuestionDto updateQuestionDto);
    }
}