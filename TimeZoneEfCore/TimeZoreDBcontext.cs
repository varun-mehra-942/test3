using Microsoft.EntityFrameworkCore;
using test3.Entity;

namespace test3.TimeZoneDBContext
{
    public class TimeZoreDBcontext:DbContext
    {
        public TimeZoreDBcontext(DbContextOptions dbContextOptions):base(dbContextOptions) { }

        public DbSet<Countries> timezones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>().HasKey(k => k.Id);
            base.OnModelCreating(modelBuilder);

        }
    }
}
