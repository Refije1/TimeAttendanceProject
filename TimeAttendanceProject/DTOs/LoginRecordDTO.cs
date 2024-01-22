namespace TimeAttendanceProject.DTOs
{
    public class LoginRecordDTO
    {
        public int RecordId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
