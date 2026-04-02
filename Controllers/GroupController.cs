using Microsoft.AspNetCore.Mvc; // Для ControllerBase, [ApiController], IActionResult
using Microsoft.EntityFrameworkCore; // Для ToListAsync
using ScheduleWeb.Data; // Для ApplicationDbContext
using ScheduleWeb.Models; // Про всяк випадок для моделі Group

namespace ScheduleWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GroupController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var groups = await _context.Groups
            .Where(g => g.IsDeleted == 0)
            .ToListAsync();
            
        return Ok(groups);
    }
}