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

            //User newUser = new User
            //{
            //    UserName = user.UserName,
            //    Password = user.Password
            //};


            var newUser = _mapper.Map<User>(user);

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();

            }
            return Ok(user);
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPut("update(id)")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO updateUserDTO)
        {
            if (updateUserDTO == null || id != updateUserDTO.UserId) {
                return BadRequest("Invalid data or mismatched id");

            }
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null) {
                return NotFound();
            }

            _mapper.Map(updateUserDTO, existingUser);
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete(id)")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) { 
            return NotFound();  
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent(); 
        }
    }
}