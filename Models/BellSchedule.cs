namespace ScheduleWeb.Models;

public class BellSchedule
{
    public int Id { get; set; }
    public int LessonNumber { get; set; }
    public string StartTime { get; set; } = null!; // Наприклад, "08:30"
    public string EndTime { get; set; } = null!;   // Наприклад, "09:50"
    public int IsShortened { get; set; } = 0;      // 0 - звичайна, 1 - скорочена
}