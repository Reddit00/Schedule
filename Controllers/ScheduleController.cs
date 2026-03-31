using Microsoft.AspNetCore.Mvc;
using ScheduleWeb.DTOs;
using ScheduleWeb.Models;
using ScheduleWeb.Repositories;
using ScheduleWeb.Services;
using ScheduleWeb.Data;

namespace ScheduleWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleRepository _repo;
    private readonly IValidationService _validator;
    private readonly ApplicationDbContext _context;

    public ScheduleController(IScheduleRepository repo, IValidationService validator, ApplicationDbContext context)
    {
        _repo = repo;
        _validator = validator;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int? groupId, string? date)
    {
        var schedule = await _repo.GetFilteredScheduleAsync(groupId, date);
        var result = schedule.Select(s => new ScheduleResponseDto(
            s.Id, s.Group?.Name ?? "---", s.Teacher?.FullName ?? "---",
            s.Subject?.Name ?? "---", s.Audience?.Number ?? "---",
            s.Date, s.LessonNumber, s.LessonType
        ));
        return Ok(result);
    }
}