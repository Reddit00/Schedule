using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;

namespace ScheduleWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public SubjectController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Subjects.Where(s => s.IsDeleted == 0).ToListAsync());
    }
}