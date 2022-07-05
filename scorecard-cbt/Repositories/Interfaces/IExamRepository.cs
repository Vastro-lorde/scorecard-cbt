using scorecard_cbt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories.Interfaces
{
    public interface IExamRepository
    {
        Task<Exam> GetExamByIdAsync(string id);
        Task<List<Exam>> CreateExamAsync(Exam exam);
        Task<bool> Delete(Exam request);
    }
}
