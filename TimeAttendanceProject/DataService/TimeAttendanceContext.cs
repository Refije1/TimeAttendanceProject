using Microsoft.EntityFrameworkCore;
using TimeAttendanceProject.Models;

namespace TimeAttendanceProject.DataService
{
    public class TimeAttendanceContext : DbContext
    {
        public TimeAttendanceContext(DbContextOptions<TimeAttendanceContext> options) : base(options)
        {}
          
        public DbSet<User> Users { get; set; }
    }
}
