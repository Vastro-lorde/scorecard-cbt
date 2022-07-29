using scorecard_cbt.DTOs;
using scorecard_cbt.Models;
using scorecard_cbt.Utilities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Interfaces
{
    public interface IResultServices
    {
        Task<Response<Result>> CreateResultAsync(CreateResultDto createResult);
        Task<Response<Result>> DeleteResultAsync(string ResultId);
        Task<Response<PaginationModel<IEnumerable<ResultResponseDto>>>> GetAllResultsAsync(int pageSize, int pageNumber);
        Task<Response<ResultResponseDto>> GetResultByIdAsync(string ResultId);
        Task<Response<PaginationModel<IEnumerable<ResultResponseDto>>>> GetResultsByExamAsync(int pageSize, int pageNumber, string ExamId);
        Task<Response<PaginationModel<IEnumerable<ResultResponseDto>>>> GetResultsByUserIdAsync(int pageSize, int pageNumber, string UserId);
    }
}