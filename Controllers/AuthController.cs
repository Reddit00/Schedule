using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;
using ScheduleWeb.DTOs;

namespace ScheduleWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AuthController(ApplicationDbContext context) => _context = context;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username.ToLower() == dto.Username.ToLower() 
                                  && u.PasswordHash == dto.Password);

        if (user == null) return Unauthorized("Невірний логін або пароль");

        return Ok(new { success = true, roleId = user.RoleId, fullName = user.FullName });
    }
}