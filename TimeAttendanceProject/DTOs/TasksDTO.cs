namespace TimeAttendanceProject.DTOs
{
    public class TasksDTO
    {
        public int TaskId { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
