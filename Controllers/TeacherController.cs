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
    public async Task<IActionResult> GetAll() => 
        Ok(await _context.Teachers.Where(t => t.IsDeleted == 0).ToListAsync());
}