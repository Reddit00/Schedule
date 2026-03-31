using ScheduleWeb.Models;

namespace ScheduleWeb.Services;

public interface IValidationService
{
    // Повертає кортеж: (чи валідно, повідомлення про помилку)
    Task<(bool isValid, string message)> ValidateScheduleAsync(Schedule newLesson);
}