using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleWeb.Models;

public class Curriculum
{
    [Key]
    public int Id { get; set; }

    public int GroupId { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }

    public int? Semester { get; set; }
    public int? TotalHours { get; set; }

    [ForeignKey("GroupId")]
    public Group? Group { get; set; }

    [ForeignKey("SubjectId")]
    public Subject? Subject { get; set; }

    [ForeignKey("TeacherId")]
    public Teacher? Teacher { get; set; }
}