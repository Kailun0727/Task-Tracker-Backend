using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Data;
using TaskAPI.Entities;

namespace TaskAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskController(DataContext contex)
        {
            _context = contex;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoTask>>> GetAllTasks()
        {
            List<ToDoTask> tasks = await _context.Tasks.ToListAsync();

            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ToDoTask>> GetTask(int id)
        {
            // use ? to indicate nullable
            ToDoTask? task = await _context.Tasks.FindAsync(id);

            if (task is null) {
                return BadRequest("Task not found");
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<List<ToDoTask>>> AddTask([FromBody] ToDoTask task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tasks.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ToDoTask>>> UpdateTask([FromBody] ToDoTask task)
        {
            // use ? to indicate nullable
            ToDoTask? taskItem = await _context.Tasks.FindAsync(task.Id);

            if (taskItem is null)
            {
                return BadRequest("Task not found");
            }

            taskItem.Text = task.Text;
            taskItem.Day = task.Day;
            taskItem.Reminder = task.Reminder;

            await _context.SaveChangesAsync();

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ToDoTask>>> DeleteTask(int id)
        {
            // use ? to indicate nullable
            ToDoTask? taskItem = await _context.Tasks.FindAsync(id);

            if (taskItem is null)
            {
                return BadRequest("Task not found");
            }

            _context.Tasks.Remove(taskItem);
          
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
