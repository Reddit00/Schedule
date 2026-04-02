namespace ScheduleWeb.Services;

public interface IValidationService
{
    Task<bool> IsAudienceFreeAsync(int audienceId, int lessonNumber, string dayOfWeek, string? date);
    Task<bool> IsTeacherFreeAsync(int teacherId, int lessonNumber, string dayOfWeek, string? date);
}