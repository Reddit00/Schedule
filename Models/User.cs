using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleWeb.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string FullName { get; set; } = null!;
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }
    public int IsDeleted { get; set; } = 0;

    [ForeignKey("RoleId")]
    public Role? Role { get; set; }
}