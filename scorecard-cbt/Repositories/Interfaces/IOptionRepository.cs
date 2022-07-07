using scorecard_cbt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories.Interfaces
{
    public interface IOptionRepository
    {
        Task<bool> CreateOptionAsync(string QuestionId, Option option);
        Task<bool> DeleteOption(Option request);
        Task<List<Option>> GetAllOptionsAsync();
        Task<Option> GetOptionByIdAsync(string id);
        Task<bool> UpdateOptionAsync(Option request);
        Task<ICollection<Option>> GetOptionByQuestionAsync(string QuestionId);
    }
}