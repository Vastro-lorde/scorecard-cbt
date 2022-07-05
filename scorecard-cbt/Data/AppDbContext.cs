using Microsoft.EntityFrameworkCore;
using scorecard_cbt.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace scorecard_cbt.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(entry => entry.Entity is BaseEntity);

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((BaseEntity)entry.Entity).Id = Guid.NewGuid().ToString();
                        ((BaseEntity)entry.Entity).CreationTime = DateTime.Now;
                        break;   
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
