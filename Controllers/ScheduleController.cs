using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;
using ScheduleWeb.Models;
using ScheduleWeb.Repositories;

namespace ScheduleWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Отримання розкладу на ОДИН день
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetSchedule(
            [FromQuery] string date, 
            [FromQuery] int? groupId = null, 
            [FromQuery] int? teacherId = null)
        {
            var query = _context.Schedules
                .Include(s => s.Group).Include(s => s.Teacher)
                .Include(s => s.Subject).Include(s => s.Audience)
                .Where(s => s.Date == date);

            if (groupId.HasValue) query = query.Where(s => s.GroupId == groupId.Value);
            if (teacherId.HasValue) query = query.Where(s => s.TeacherId == teacherId.Value);

            return Ok(await query.OrderBy(s => s.LessonNumber).Select(s => new {
                s.Id, s.LessonNumber, s.LessonType, s.DayOfWeek, s.Date,
                GroupName = s.Group.Name, TeacherName = s.Teacher.FullName,
                SubjectName = s.Subject.Name, AudienceNumber = s.Audience.Number
            }).ToListAsync());
        }

        // 2. Отримання розкладу на ТИЖДЕНЬ
        [HttpGet("week")]
        public async Task<ActionResult<IEnumerable<object>>> GetWeeklySchedule(
            [FromQuery] string startDate, [FromQuery] string endDate,
            [FromQuery] int? groupId = null, [FromQuery] int? teacherId = null)
        {
            var query = _context.Schedules
                .Include(s => s.Group).Include(s => s.Teacher)
                .Include(s => s.Subject).Include(s => s.Audience)
                .Where(s => string.Compare(s.Date, startDate) >= 0 && string.Compare(s.Date, endDate) <= 0);

            if (groupId.HasValue) query = query.Where(s => s.GroupId == groupId.Value);
            if (teacherId.HasValue) query = query.Where(s => s.TeacherId == teacherId.Value);

            return Ok(await query.OrderBy(s => s.Date).ThenBy(s => s.LessonNumber).Select(s => new {
                s.Id, s.LessonNumber, s.LessonType, s.DayOfWeek, s.Date,
                GroupName = s.Group.Name, TeacherName = s.Teacher.FullName,
                SubjectName = s.Subject.Name, AudienceNumber = s.Audience.Number
            }).ToListAsync());
        }

        // 3. АВТО-ГЕНЕРАТОР на 2 тижні
        [HttpPost("generate-auto")]
        public async Task<ActionResult> GenerateAutoSchedule([FromQuery] string startMondayDate)
        {
            try {
                if (!DateTime.TryParse(startMondayDate, out DateTime monday)) return BadRequest("Дату не розпізнано");

                var groups = await _context.Groups.ToListAsync();
                var teachers = await _context.Teachers.ToListAsync();
                var subjects = await _context.Subjects.ToListAsync();
                var audiences = await _context.Audiences.ToListAsync();

                var random = new Random();
                var days = new[] { "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця" };
                var types = new[] { "Лекція", "Практика", "Лабораторна" };
                var generated = new List<Schedule>();

                for (int dayIdx = 0; dayIdx < 10; dayIdx++) {
                    int skip = (dayIdx / 5) * 2;
                    DateTime d = monday.AddDays(dayIdx + skip);
                    string dStr = d.ToString("yyyy-MM-dd");

                    foreach (var g in groups) {
                        int count = random.Next(3, 5);
                        for (int l = 1; l <= count; l++) {
                            var t = teachers[random.Next(teachers.Count)];
                            var s = subjects[random.Next(subjects.Count)];
                            var a = audiences[random.Next(audiences.Count)];

                            if (!generated.Any(x => x.Date == dStr && x.LessonNumber == l && (x.TeacherId == t.Id || x.AudienceId == a.Id))) {
                                generated.Add(new Schedule {
                                    GroupId = g.Id, TeacherId = t.Id, SubjectId = s.Id, AudienceId = a.Id,
                                    Date = dStr, DayOfWeek = days[dayIdx % 5], LessonNumber = l,
                                    LessonType = types[random.Next(types.Length)], IsEvenWeek = dayIdx >= 5 ? 1 : 0
                                });
                            }
                        }
                    }
                }
                _context.Schedules.AddRange(generated);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Розклад на 14 днів готовий!" });
            } catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}