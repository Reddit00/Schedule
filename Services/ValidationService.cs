using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;

namespace ScheduleWeb.Services;

public class ValidationService : IValidationService
{
    private readonly ApplicationDbContext _context;
    public ValidationService(ApplicationDbContext context) => _context = context;

    public async Task<bool> IsAudienceFreeAsync(int audienceId, int lessonNumber, string dayOfWeek, string? date)
    {
        return !await _context.Schedules.AnyAsync(s => 
            s.AudienceId == audienceId && 
            s.LessonNumber == lessonNumber && 
            (s.Date == date || s.DayOfWeek == dayOfWeek));
    }

    public async Task<bool> IsTeacherFreeAsync(int teacherId, int lessonNumber, string dayOfWeek, string? date)
    {
        return !await _context.Schedules.AnyAsync(s => 
            s.TeacherId == teacherId && 
            s.LessonNumber == lessonNumber && 
            (s.Date == date || s.DayOfWeek == dayOfWeek));
    }
}