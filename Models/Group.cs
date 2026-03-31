namespace ScheduleWeb.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Course { get; set; }
    public string Specialty { get; set; } = null!;
    public int Shift { get; set; } = 1; // Додано
    public int IsDeleted { get; set; } = 0;
}