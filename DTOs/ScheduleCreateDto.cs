namespace ScheduleWeb.DTOs;

public class ScheduleCreateDto
{
    public int GroupId { get; set; }
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
    public int AudienceId { get; set; }
    public int LessonNumber { get; set; }
    public string LessonType { get; set; } = "Лекція"; // Лекція/Практика
    public string DayOfWeek { get; set; } = null!;    // Понеділок...
    public int IsEvenWeek { get; set; }               // 0 або 1
    public string? Date { get; set; }                 // "2026-04-02"
}