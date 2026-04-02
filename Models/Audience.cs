public class Audience
{
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public string? Type { get; set; }
    public int? Capacity { get; set; }
    public int IsDeleted { get; set; } = 0;
}