public class Schedule
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
    public int AudienceId { get; set; }
    public int LessonNumber { get; set; }
    public string LessonType { get; set; } = null!;
    public string DayOfWeek { get; set; } = null!;
    public int IsEvenWeek { get; set; } // 0 - ні, 1 - так
    public string? Date { get; set; }

    public Group? Group { get; set; }
    public Teacher? Teacher { get; set; }
    public Subject? Subject { get; set; }
    public Audience? Audience { get; set; }
}