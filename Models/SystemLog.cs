using System.ComponentModel.DataAnnotations;

namespace ScheduleWeb.Models;

public class SystemLog
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    [Required]
    public string ActionDescription { get; set; } = null!;
    public string Timestamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
}