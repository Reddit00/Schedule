using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleWeb.Models;

public class Curriculum
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    
    [Range(1, 2)]
    public int Semester { get; set; }
    public int TotalHours { get; set; }

    // Навігаційні властивості (для JOIN-ів)
    [ForeignKey("GroupId")]
    public Group? Group { get; set; }
    [ForeignKey("SubjectId")]
    public Subject? Subject { get; set; }
}