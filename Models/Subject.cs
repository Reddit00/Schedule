namespace ScheduleWeb.Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int MaxPerDay { get; set; } = 1; // Додано
    public int IsDeleted { get; set; } = 0;
}