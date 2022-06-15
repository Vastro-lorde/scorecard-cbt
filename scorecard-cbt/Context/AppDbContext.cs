using Microsoft.EntityFrameworkCore;
using scorecard_cbt.Models;

namespace scorecard_cbt.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Exam> Exams { get; set; }
    }
}
