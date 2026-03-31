namespace ScheduleWeb.Models;

public class Schedule
{
    public int Id { get; set; }
    
    public int GroupId { get; set; }
    public Group? Group { get; set; } // Навігаційна властивість для Include

    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }

    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public int AudienceId { get; set; }
    public Audience? Audience { get; set; }

    public string Date { get; set; } = null!;
    public int LessonNumber { get; set; }
    public string LessonType { get; set; } = null!;
    public string CreatedAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
}