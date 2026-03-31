using System.ComponentModel.DataAnnotations;

namespace ScheduleWeb.Models;

public class Role
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!; // Admin, Teacher, Student
}