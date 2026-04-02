using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;

namespace ScheduleWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public TeacherController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teachers = await _context.Teachers
            .Where(t => t.IsDeleted == 0)
            .OrderBy(t => t.FullName)
            .ToListAsync();
        return Ok(teachers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null) return NotFound();
        return Ok(teacher);
    }
}