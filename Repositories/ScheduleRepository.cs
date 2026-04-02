using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;
using ScheduleWeb.Models;

namespace ScheduleWeb.Repositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly ApplicationDbContext _context;
    public ScheduleRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Schedule>> GetScheduleAsync(string? date, int? groupId)
    {
        var query = _context.Schedules
            .Include(s => s.Group)
            .Include(s => s.Teacher)
            .Include(s => s.Subject)
            .Include(s => s.Audience)
            .AsQueryable();

        if (!string.IsNullOrEmpty(date))
            query = query.Where(s => s.Date == date);
        
        if (groupId.HasValue)
            query = query.Where(s => s.GroupId == groupId);

        return await query.OrderBy(s => s.LessonNumber).ToListAsync();
    }

    public async Task<Schedule?> GetByIdAsync(int id) => await _context.Schedules.FindAsync(id);

    public async Task AddAsync(Schedule schedule) 
    { 
        await _context.Schedules.AddAsync(schedule); 
        await _context.SaveChangesAsync(); 
    }

    public async Task UpdateAsync(Schedule schedule)
    {
        _context.Schedules.Update(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);
        if (item != null)
        {
            _context.Schedules.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}