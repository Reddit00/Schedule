using System.ComponentModel.DataAnnotations;

namespace ScheduleWeb.Models;

public class Audience
{
    public int Id { get; set; }
    [Required]
    public string Number { get; set; } = null!; // Номер кабінету (напр. "205")
    [Required]
    public string Type { get; set; } = null!;   // Лекційна, Лабораторія...
    public int Capacity { get; set; }
    public int IsDeleted { get; set; } = 0;
}