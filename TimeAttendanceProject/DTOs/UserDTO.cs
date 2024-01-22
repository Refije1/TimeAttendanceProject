
using TimeAttendanceProject.Models;

namespace TimeAttendanceProject.DTOs
{
    public class UserDTO
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
        public ICollection<LoginRecordDTO> LoginRecords { get; set; }
        public ICollection<TasksDTO> Tasks { get; set; }
    }
}
