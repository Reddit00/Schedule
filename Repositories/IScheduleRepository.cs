using ScheduleWeb.Models;

namespace ScheduleWeb.Repositories;

public interface IScheduleRepository
{
    Task<IEnumerable<Schedule>> GetScheduleAsync(string? date, int? groupId);
    Task<Schedule?> GetByIdAsync(int id);
    Task AddAsync(Schedule schedule);
    Task UpdateAsync(Schedule schedule);
    Task DeleteAsync(int id);
}