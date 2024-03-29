﻿using scorecard_cbt.DTOs;
using scorecard_cbt.Models;
using scorecard_cbt.Utilities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Interfaces
{
    public interface IQuestionService
    {
        Task<Response<Question>> CreateQuestionAsync(string ExamId, QuestionRequestDto createQuestion);
        Task<Response<Question>> DeleteQuestionAsync(string QuestionId);
        Task<Response<PaginationModel<IEnumerable<GetAllQuestionResponseDto>>>> GetAllQuestionsAsync(int pageSize, int pageNumber);
        Task<Response<QuestionDetailResponseDto>> GetQuestionByIdAsync(string QuestionId);
        Task<Response<string>> UpdateQuestionDetails(string QuestionId, UpdateQuestionDto updateQuestionDto);
        Task<Response<ICollection<Question>>> GetQuestionsByExamAsync(string ExamId);
    }
}