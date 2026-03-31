using ScheduleWeb.Models;

namespace ScheduleWeb.Repositories;

public interface IScheduleRepository
{
    Task<IEnumerable<Schedule>> GetFilteredScheduleAsync(int? groupId, string? date);
    Task<int> GetTotalHoursBySubjectAsync(int groupId, int subjectId);
    Task AddAsync(Schedule schedule);
    Task<bool> SaveChangesAsync();
}