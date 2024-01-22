using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeAttendanceProject.Models
{
    public class LoginRecord
    {
        [Key]
        public int RecordId { get; set; }   
        public DateTime LoginTime { get; set; } 
        public DateTime LogoutTime { get; set; }
        public DateTime Date {  get; set; }
        public int UserId { get; set; }
        [ForeignKey ("UserId")]
        public User User { get; set; }
    }
}
