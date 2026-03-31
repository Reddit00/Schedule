using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;
using ScheduleWeb.Models;

namespace ScheduleWeb.Services;

public class ValidationService : IValidationService
{
    private readonly ApplicationDbContext _context;

    public ValidationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(bool isValid, string message)> ValidateScheduleAsync(Schedule newLesson)
    {
        // 1. Перевірка ліміту годин (Вичитка)
        var plan = await _context.Curriculums
            .FirstOrDefaultAsync(c => c.GroupId == newLesson.GroupId && c.SubjectId == newLesson.SubjectId);

        if (plan != null)
        {
            // Рахуємо фактично проведені години (1 пара = 2 години)
            int usedHours = await _context.Schedules
                .CountAsync(s => s.GroupId == newLesson.GroupId && s.SubjectId == newLesson.SubjectId) * 2;

            if (usedHours >= plan.TotalHours)
            {
                return (false, $"Помилка: Вичерпано ліміт годин за планом ({plan.TotalHours} год.)");
            }
        }

        // 2. Перевірка фізичних накладок (SQL UNIQUE констрейнти спрацюють у БД, 
        // але краще перевірити тут для гарної відповіді користувачу)
        bool isBusy = await _context.Schedules.AnyAsync(s => 
            s.Date == newLesson.Date && 
            s.LessonNumber == newLesson.LessonNumber && 
            (s.TeacherId == newLesson.TeacherId || s.GroupId == newLesson.GroupId || s.AudienceId == newLesson.AudienceId));

        if (isBusy)
        {
            return (false, "Конфлікт: Викладач, Група або Аудиторія вже зайняті в цей час!");
        }

        return (true, string.Empty);
    }
}