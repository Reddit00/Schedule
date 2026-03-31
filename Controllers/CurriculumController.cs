using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;

namespace ScheduleWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurriculumController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CurriculumController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetByGroup(int groupId) => 
        Ok(await _context.Curriculums.Where(c => c.GroupId == groupId).ToListAsync());
}