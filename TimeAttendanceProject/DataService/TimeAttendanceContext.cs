using Microsoft.EntityFrameworkCore;
using TimeAttendanceProject.Models;

namespace TimeAttendanceProject.DataService
{
    public class TimeAttendanceContext : DbContext
    {
        public TimeAttendanceContext(DbContextOptions<TimeAttendanceContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<LoginRecord> LoginRecords {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Tasks (One-to-Many)
            modelBuilder.Entity<User>()
            .HasMany(u => u.Tasks)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            // User - LoginRecord (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.LoginRecords)
                .WithOne(lr => lr.User)
                .HasForeignKey(lr => lr.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
