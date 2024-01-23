using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeAttendanceProject.DataService;
using TimeAttendanceProject.DTOs;
using TimeAttendanceProject.Models;


namespace TimeAttendanceProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : Controller
    {
        private readonly TimeAttendanceContext _context;
        private readonly IMapper _mapper;

        public TasksController(TimeAttendanceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddTasks([FromBody] TasksDTO tasks)
        {
            if (tasks == null)
            {
                return BadRequest("Invalid user data");
            }
            var newTasks = _mapper.Map<Tasks>(tasks);

            _context.Tasks.Add(newTasks);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTasks(int id)
        {
            var tasks = _context.Tasks.Find(id);

            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);

        }

        [HttpPut("{update-id}")]
        public async Task<IActionResult> UpdateTasks(int id, [FromBody] TasksDTO updatedTasksDTO)
        {
            if (updatedTasksDTO == null) {
                return BadRequest("Invalid data or mismatched id");
            }   
            var existingTasks = _context.Tasks.Find(id);
            if (existingTasks == null) {
                return NotFound();
                        
            }

            _mapper.Map(updatedTasksDTO, existingTasks);

            _context.Tasks.Update(existingTasks);
            await _context.SaveChangesAsync();
            return Ok(existingTasks);

        }

        [HttpDelete("delete-id")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            var tasks = _context.Tasks.Find(id);

            if (tasks == null) {
                return NotFound();
                 }
            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
