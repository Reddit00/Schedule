namespace ScheduleWeb.DTOs;

public class ScheduleResponseDto
{
    public int Id { get; set; }
    public int LessonNumber { get; set; }
    public string SubjectName { get; set; } = null!;
    public string TeacherName { get; set; } = null!;
    public string GroupName { get; set; } = null!;
    public string AudienceNumber { get; set; } = null!;
    public string LessonType { get; set; } = null!;
    public string StartTime { get; set; } = null!;
    public string EndTime { get; set; } = null!;
}