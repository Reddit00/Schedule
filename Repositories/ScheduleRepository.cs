using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;
using ScheduleWeb.Models;

namespace ScheduleWeb.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationDbContext _context;

    public ScheduleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Schedule>> GetFilteredScheduleAsync(int? groupId, string? date)
    {
        return await _context.Schedules
            .Include(s => s.Group)
            .Include(s => s.Teacher)
            .Include(s => s.Subject)
            .Include(s => s.Audience)
            .Where(s => (!groupId.HasValue || s.GroupId == groupId) && 
                        (string.IsNullOrEmpty(date) || s.Date == date))
            .OrderBy(s => s.Date)
            .ThenBy(s => s.LessonNumber)
            .ToListAsync();
    }

    public async Task<int> GetTotalHoursBySubjectAsync(int groupId, int subjectId)
    {
        return await _context.Schedules
            .CountAsync(s => s.GroupId == groupId && s.SubjectId == subjectId) * 2;
    }

    public async Task AddAsync(Schedule schedule)
    {
        await _context.Schedules.AddAsync(schedule);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) >= 0;
    }
}