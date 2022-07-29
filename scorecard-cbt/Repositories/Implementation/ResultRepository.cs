using Microsoft.EntityFrameworkCore;
using scorecard_cbt.Context;
using scorecard_cbt.Models;
using scorecard_cbt.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories.Implementation
{
    public class ResultRepository : IResultRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Result> _dbSet;
        public ResultRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Result>();
        }
        public async Task<bool> CreateResultAsync(Result result)
        {
            _dbContext.Results.Add(result);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteResult(Result request)
        {
            _dbSet.Remove(request);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<Result> GetResultByIdAsync(string id)
        {
            var result = await _dbContext.Results.FindAsync(id);
            return result;
        }
        public async Task<List<Result>> GetAllResultsAsync()
        {
            var results = await _dbContext.Results.ToListAsync();
            return results = await _dbContext.Results.ToListAsync();
        }
        public async Task<ICollection<Result>> GetResultByUserIdAsync(string UserId)
        {
            var results = await _dbContext.Results.Where(x => x.UserId == UserId).ToListAsync();
            return results;
        }
        public async Task<ICollection<Result>> GetResultByExamAsync(string ExamId)
        {
            var results = await _dbContext.Results.Where(x => x.ExamId == ExamId).ToListAsync();
            return results;
        }
    }
}
