namespace ScheduleWeb.DTOs;

public record ScheduleCreateDto(
    int GroupId, 
    int TeacherId, 
    int SubjectId, 
    int AudienceId, 
    string Date, 
    int LessonNumber, 
    string LessonType
);