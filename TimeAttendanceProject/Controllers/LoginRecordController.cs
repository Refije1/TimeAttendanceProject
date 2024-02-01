using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeAttendanceProject.DataService;
using TimeAttendanceProject.DTOs;
using TimeAttendanceProject.Models;


namespace TimeAttendanceProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginRecordController : Controller
    {
        private readonly TimeAttendanceContext _context;
        private readonly IMapper _mapper;

        public LoginRecordController(TimeAttendanceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddLoginRecord([FromBody] LoginRecordDTO loginRecord)
        {
            if (loginRecord == null)
            {
                return BadRequest("Invalid user data");
            }
            var newLoginRecord = _mapper.Map<LoginRecord>(loginRecord);

            _context.LoginRecords.Add(newLoginRecord);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetLoginRecord(int id)
        {
            var loginRecord = _context.LoginRecords.Find(id);

            if (loginRecord  == null)
            {
                return NotFound();
            }
            return Ok(loginRecord);

        }

        [HttpGet("user/{userId}")]
        public IActionResult GetLoginRecordByUserId(int userId)
        {
            var loginRecords = _context.LoginRecords.Where(lr => lr.UserId == userId).ToList();

            if (loginRecords == null || loginRecords.Count == 0)
            {
                return NotFound();
            }

            return Ok(loginRecords);
        }

        [HttpPut("{update-id}")]
        public async Task<IActionResult> UpdateLoginRecord(int id, [FromBody] LoginRecordDTO updatedLoginRecordDTO)
        {
            if (updatedLoginRecordDTO == null)
            {
                return BadRequest("Invalid data or mismatched id");
            }
            var existingLoginRecord = _context.LoginRecords.Find(id);
            if (existingLoginRecord == null)
            {
                return NotFound();

            }

            _mapper.Map(updatedLoginRecordDTO, existingLoginRecord);

            _context.LoginRecords.Update(existingLoginRecord);
            await _context.SaveChangesAsync();
            return Ok(existingLoginRecord);

        }

        [HttpDelete("delete-id")]
        public async Task<IActionResult> DeleteLoginRecord(int id)
        {
            var loginRecord = _context.LoginRecords.Find(id);

            if (loginRecord == null)
            {
                return NotFound();
            }
            _context.LoginRecords.Remove(loginRecord);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
