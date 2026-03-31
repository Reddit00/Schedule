using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Models;

namespace ScheduleWeb.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Role> Roles => Set<Role>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Subject> SubjectEntities => Set<Subject>(); // Перейменовано для уникнення конфліктів
    public DbSet<Audience> Audiences => Set<Audience>();
    public DbSet<Schedule> Schedules => Set<Schedule>();
    public DbSet<BellSchedule> BellSchedules => Set<BellSchedule>();
    public DbSet<Curriculum> Curriculums => Set<Curriculum>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Унікальні індекси (Захист від накладок як у SQL UNIQUE)
        modelBuilder.Entity<Schedule>()
            .HasIndex(s => new { s.GroupId, s.Date, s.LessonNumber }).IsUnique();
        modelBuilder.Entity<Schedule>()
            .HasIndex(s => new { s.TeacherId, s.Date, s.LessonNumber }).IsUnique();
        modelBuilder.Entity<Schedule>()
            .HasIndex(s => new { s.AudienceId, s.Date, s.LessonNumber }).IsUnique();

        // 2. ЗАПОВНЕННЯ ДАНИМИ (SEED DATA)
        
        // Ролі
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Адміністратор" },
            new Role { Id = 2, Name = "Викладач" },
            new Role { Id = 3, Name = "Студент" }
        );

        // Групи (фрагмент з твого списку)
        modelBuilder.Entity<Group>().HasData(
            new Group { Id = 1, Name = "ІПЗ-1/1", Course = 1, Specialty = "Інженерія ПЗ", Shift = 1 },
            new Group { Id = 2, Name = "ІПЗ-1/2", Course = 1, Specialty = "Інженерія ПЗ", Shift = 1 },
            new Group { Id = 3, Name = "КН-1/1", Course = 1, Specialty = "Комп'ютерні науки", Shift = 1 },
            new Group { Id = 4, Name = "ІПЗ-4/1", Course = 4, Specialty = "Інженерія ПЗ", Shift = 1 }
            // Додай інші групи за аналогією
        );

        // Розклад дзвінків
        modelBuilder.Entity<BellSchedule>().HasData(
            new BellSchedule { Id = 1, LessonNumber = 1, StartTime = "08:30", EndTime = "09:50", IsShortened = 0 },
            new BellSchedule { Id = 2, LessonNumber = 2, StartTime = "10:00", EndTime = "11:20", IsShortened = 0 },
            new BellSchedule { Id = 3, LessonNumber = 3, StartTime = "11:50", EndTime = "13:10", IsShortened = 0 }
        );

        // Предмети
        modelBuilder.Entity<Subject>().HasData(
            new Subject { Id = 1, Name = "Математика", MaxPerDay = 2 },
            new Subject { Id = 2, Name = "Програмування", MaxPerDay = 2 },
            new Subject { Id = 3, Name = "Історія України", MaxPerDay = 1 }
        );
        
        // Аудиторії
        modelBuilder.Entity<Audience>().HasData(
            new Audience { Id = 1, Number = "26", Type = "Комп'ютерний клас", Capacity = 30 },
            new Audience { Id = 2, Number = "с/з", Type = "Спортзал", Capacity = 60 }
        );
    }
}