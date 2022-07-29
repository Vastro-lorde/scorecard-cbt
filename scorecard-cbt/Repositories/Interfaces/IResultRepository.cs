using scorecard_cbt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<bool> CreateResultAsync(Result result);
        Task<bool> DeleteResult(Result request);
        Task<List<Result>> GetAllResultsAsync();
        Task<ICollection<Result>> GetResultByUserIdAsync(string UserId);
        Task<ICollection<Result>> GetResultByExamAsync(string ExamId);
        Task<Result> GetResultByIdAsync(string id);
    }
}