﻿using Microsoft.EntityFrameworkCore;
using scorecard_cbt.Context;
using scorecard_cbt.Models;
using scorecard_cbt.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories.Implementation
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Question> _dbSet;
        public QuestionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Question>();
        }
        public async Task<bool> CreateQuestionAsync(string ExamId, Question question)
        {
            var Exam = await _dbContext.Exams.FindAsync(ExamId);
            if (Exam != null)
            {
                question.ExamId = Exam.Id;
                _dbContext.Questions.Add(question);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else { return false; };
        }
        public async Task<bool> DeleteQuestion(Question request)
        {
            _dbSet.Remove(request);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _dbContext.Questions.ToListAsync();
        }
        public async Task<Question> GetQuestionByIdAsync(string id)
        {
            var user = await _dbContext.Questions.FindAsync(id);
            return user;
        }
        public async Task<bool> UpdateQuestionAsync(Question request)
        {
            _dbSet.Update(request);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<ICollection<Question>> GetQuestionstionByExamAsync(string ExamId)
        {
            var questions = await _dbContext.Questions.Where(x => x.ExamId == ExamId).ToListAsync();
            return questions;
        }
    }
}
