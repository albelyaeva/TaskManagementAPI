using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TaskController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
    {
        if (string.IsNullOrEmpty(task.Title))
        {
            return BadRequest("Title is required.");
        }
        
        if (task.DueDate.HasValue)
            task.DueDate = task.DueDate.Value.ToUniversalTime();

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TaskItem updatedTask)
    {
        if (id != updatedTask.Id)
            return BadRequest();

        _context.Entry(updatedTask).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tasks.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return Ok(updatedTask);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}