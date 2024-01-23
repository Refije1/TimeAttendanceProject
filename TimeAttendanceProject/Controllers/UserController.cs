using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeAttendanceProject.DataService;
using TimeAttendanceProject.DTOs;
using TimeAttendanceProject.Models;

namespace TimeAttendanceProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly TimeAttendanceContext _context;
        private readonly IMapper _mapper;

        public UserController(TimeAttendanceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            var newUser = _mapper.Map<User>(user);

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok();
        }

       

    }
}