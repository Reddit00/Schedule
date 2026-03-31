using System.ComponentModel.DataAnnotations;

namespace ScheduleWeb.Models;

public class BellSchedule
{
    public int Id { get; set; }
    public int LessonNumber { get; set; }
    [Required]
    public string StartTime { get; set; } = null!; // Напр. "08:30"
    [Required]
    public string EndTime { get; set; } = null!;
    public int IsShortened { get; set; } = 0;      // 0 - звичайна, 1 - скорочена
}