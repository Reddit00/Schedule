namespace ScheduleWeb.DTOs;

public record ScheduleResponseDto(
    int Id, 
    string GroupName, 
    string TeacherName, 
    string SubjectName, 
    string AudienceNumber, 
    string Date, 
    int LessonNumber, 
    string LessonType
);