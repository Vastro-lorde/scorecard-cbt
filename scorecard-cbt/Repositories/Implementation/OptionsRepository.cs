using Microsoft.EntityFrameworkCore;
using scorecard_cbt.Context;
using scorecard_cbt.Models;
using scorecard_cbt.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories.Implementation
{
    public class OptionRepository : IOptionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Option> _dbSet;
        public OptionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Option>();
        }
        public async Task<bool> CreateOptionAsync(string QuestionId, Option option)
        {
            var Question = await _dbContext.Questions.FindAsync(QuestionId);
            if (Question != null)
            {
                option.Question = Question;
                _dbContext.Options.Add(option);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else { return false; };
        }
        public async Task<bool> DeleteOption(Option request)
        {
            _dbSet.Remove(request);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<List<Option>> GetAllOptionsAsync()
        {
            return await _dbContext.Options.ToListAsync();
        }
        public async Task<Option> GetOptionByIdAsync(string id)
        {
            var option = await _dbContext.Options.FindAsync(id);
            return option;
        }
        public async Task<bool> UpdateOptionAsync(Option request)
        {
            _dbSet.Update(request);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<ICollection<Option>> GetOptionByQuestionAsync(string QuestionId)
        {
            var option = await _dbContext.Options.Where(x => x.Question.Id == QuestionId).ToListAsync();
            return option;
        }
    }
}
