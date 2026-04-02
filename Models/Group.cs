public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Course { get; set; }
    public string? Specialty { get; set; }
    public int Shift { get; set; }
    public int? NumberOfStudents { get; set; }
    public int IsDeleted { get; set; } = 0;
}