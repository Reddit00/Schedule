public class Teacher
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string? ContactInfo { get; set; }
    public int IsDeleted { get; set; } = 0;
}