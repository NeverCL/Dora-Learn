using Microsoft.EntityFrameworkCore;

namespace Timing
{
    public class TimingDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=wdora.com;database=TimingDb;uid=root;password=123123;");
        }

        public DbSet<TimerJob> TimerJob { get; set; }
    }
}