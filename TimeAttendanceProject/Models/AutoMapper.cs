using AutoMapper;
using TimeAttendanceProject.DTOs;
using TimeAttendanceProject.Models;


namespace TimeAttendanceProject
{
 
        public class AutoMapper : Profile
        {
            public AutoMapper()
            {
                CreateMap<UserDTO, User>();
                CreateMap<TasksDTO, Tasks>();
                CreateMap<LoginRecordDTO, LoginRecord>();
            }
        }
}