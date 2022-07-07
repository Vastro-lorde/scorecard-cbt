using scorecard_cbt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        Task<bool> CreateQuestionAsync(Question question);
        Task<bool> DeleteQuestion(Question request);
        Task<List<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(string id);
        Task<bool> UpdateQuestionAsync(Question request);
    }
}