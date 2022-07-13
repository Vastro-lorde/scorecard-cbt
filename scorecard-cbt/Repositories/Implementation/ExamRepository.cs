using Microsoft.EntityFrameworkCore;
using scorecard_cbt.Context;
using scorecard_cbt.Models;
using scorecard_cbt.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories.Implementation
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Exam> _dbSet;
        public ExamRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Exam>();
        }
        public async Task<List<Exam>> CreateExamAsync(Exam exam)
        {
            _dbContext.Exams.Add(exam);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Exams.ToListAsync();
        }
        public async Task<bool> Delete(Exam request)
        {
            _dbSet.Remove(request);
            return await _dbContext.SaveChangesAsync() > 0;
        }
       
        public async Task<Exam> GetExamByIdAsync(string id)
        {
            var exam = await _dbContext.Exams.FindAsync(id);
            return exam;
        }

        public async Task<List<Exam>> GetAllExamAsync()
        {
            var exams = await _dbContext.Exams.ToListAsync();
            return exams;
        }
    }
}
