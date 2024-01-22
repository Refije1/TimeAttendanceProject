using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeAttendanceProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
       
        public ICollection<LoginRecord> LoginRecords { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
    }
}
