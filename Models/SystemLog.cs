namespace ScheduleWeb.Models;

public class SystemLog
{
    public int Id { get; set; }
    public string Action { get; set; } = null!;    // Що зроблено (Login, Update, Delete)
    public string TableName { get; set; } = null!; // Яка таблиця зачеплена
    public int EntityId { get; set; }              // ID запису
    public int UserId { get; set; }                // Хто зробив
    public DateTime Timestamp { get; set; } = DateTime.Now;
}