using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;
using ScheduleWeb.Models;

namespace ScheduleWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurriculumController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CurriculumController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var curriculums = await _context.Curriculums
            .Include(c => c.Group)
            .Include(c => c.Subject)
            .Include(c => c.Teacher)
            .ToListAsync();
        return Ok(curriculums);
    }

    [HttpGet("group/{groupId}")]
    public async Task<IActionResult> GetByGroup(int groupId)
    {
        var plans = await _context.Curriculums
            .Include(c => c.Subject)
            .Include(c => c.Teacher)
            .Where(c => c.GroupId == groupId)
            .ToListAsync();
        return Ok(plans);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Curriculum curriculum)
    {
        _context.Curriculums.Add(curriculum);
        await _context.SaveChangesAsync();
        return Ok(curriculum);
    }
}