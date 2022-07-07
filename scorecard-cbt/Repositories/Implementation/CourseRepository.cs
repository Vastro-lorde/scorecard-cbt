using Microsoft.EntityFrameworkCore;
using scorecard_cbt.Context;
using scorecard_cbt.Models;
using scorecard_cbt.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scorecard_cbt.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Course> _dbSet;
        public CourseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Course>();
        }
        public async Task<List<Course>> CreateCourseAsync(Course course)
        {
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Courses.ToListAsync();
        }
        public async Task<bool> Delete(Course request)
        {
            _dbSet.Remove(request);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _dbContext.Courses.ToListAsync();
        }
        public async Task<Course> GetCourseByIdAsync(string id)
        {
            var user = await _dbContext.Courses.FindAsync(id);
            return user;
        }
        public async Task<bool> UpdateCourseAsync(Course request)
        {
            _dbSet.Update(request);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
