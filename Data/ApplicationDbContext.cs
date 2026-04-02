using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Models;

namespace ScheduleWeb.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Group> Groups { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Audience> Audiences { get; set; }
    public DbSet<Curriculum> Curriculums { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<BellSchedule> BellSchedules { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<SystemLog> SystemLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // --- 1. РОЛІ ТА АДМІН ---
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Адміністратор" },
            new Role { Id = 2, Name = "Викладач" },
            new Role { Id = 3, Name = "Студент" }
        );
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FullName = "Головний Адміністратор", Username = "admin", PasswordHash = "admin", RoleId = 1, IsDeleted = 0 }
        );

        // --- 2. ДЗВІНКИ (Стандартні та Скорочені) ---
        modelBuilder.Entity<BellSchedule>().HasData(
            new BellSchedule { Id = 1, LessonNumber = 1, StartTime = "08:30", EndTime = "09:50", IsShortened = 0 },
            new BellSchedule { Id = 2, LessonNumber = 2, StartTime = "10:00", EndTime = "11:20", IsShortened = 0 },
            new BellSchedule { Id = 3, LessonNumber = 3, StartTime = "11:50", EndTime = "13:10", IsShortened = 0 },
            new BellSchedule { Id = 4, LessonNumber = 4, StartTime = "13:20", EndTime = "14:40", IsShortened = 0 },
            new BellSchedule { Id = 5, LessonNumber = 5, StartTime = "15:00", EndTime = "16:20", IsShortened = 0 },
            new BellSchedule { Id = 6, LessonNumber = 6, StartTime = "16:30", EndTime = "17:50", IsShortened = 0 },
            new BellSchedule { Id = 7, LessonNumber = 7, StartTime = "18:00", EndTime = "19:20", IsShortened = 0 },
            new BellSchedule { Id = 8, LessonNumber = 1, StartTime = "08:30", EndTime = "09:30", IsShortened = 1 },
            new BellSchedule { Id = 9, LessonNumber = 2, StartTime = "09:40", EndTime = "10:40", IsShortened = 1 }
        );

        // --- 3. АУДИТОРІЇ ---
        modelBuilder.Entity<Audience>().HasData(
            new Audience { Id = 1, Number = "28", Type = "Комп'ютерний клас", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 2, Number = "27", Type = "Комп'ютерний клас", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 3, Number = "26", Type = "Комп'ютерний клас", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 4, Number = "21", Type = "Комп'ютерний клас", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 5, Number = "8", Type = "Комп'ютерна лабораторія", Capacity = 20, IsDeleted = 0 },
            new Audience { Id = 6, Number = "9", Type = "Комп'ютерна лабораторія", Capacity = 20, IsDeleted = 0 },
            new Audience { Id = 7, Number = "с/з", Type = "Спортзал", Capacity = 60, IsDeleted = 0 },
            new Audience { Id = 8, Number = "тир", Type = "Тир", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 9, Number = "бібл.", Type = "Бібліотека", Capacity = 40, IsDeleted = 0 },
            new Audience { Id = 10, Number = "11", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 11, Number = "13", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 12, Number = "16", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 13, Number = "17", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 14, Number = "18", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 15, Number = "19", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 16, Number = "20", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 17, Number = "24", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 18, Number = "25", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 19, Number = "29", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 20, Number = "30", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 21, Number = "31", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 22, Number = "32", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 23, Number = "33", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 24, Number = "34", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 25, Number = "36", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 26, Number = "39", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 27, Number = "41", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 28, Number = "41А", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 29, Number = "43", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 30, Number = "44", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 31, Number = "45", Type = "Лекційна", Capacity = 30, IsDeleted = 0 },
            new Audience { Id = 32, Number = "к/з", Type = "Лекційна", Capacity = 30, IsDeleted = 0 }
        );

        // --- 4. ПРЕДМЕТИ ---
        modelBuilder.Entity<Subject>().HasData(
            new Subject { Id = 1, Name = "Історія України", IsDeleted = 0 },
            new Subject { Id = 2, Name = "Всесвітня історія", IsDeleted = 0 },
            new Subject { Id = 3, Name = "Математика", IsDeleted = 0 },
            new Subject { Id = 4, Name = "Підприємництво курс \"Компанія\"", IsDeleted = 0 },
            new Subject { Id = 5, Name = "Фізика і астрономія", IsDeleted = 0 },
            new Subject { Id = 6, Name = "Українська мова", IsDeleted = 0 },
            new Subject { Id = 7, Name = "Хімія", IsDeleted = 0 },
            new Subject { Id = 8, Name = "Іноземна мова", IsDeleted = 0 },
            new Subject { Id = 9, Name = "Біологія і екологія", IsDeleted = 0 },
            new Subject { Id = 10, Name = "Обробка інформації та ПЗ ПК", IsDeleted = 0 },
            new Subject { Id = 11, Name = "Захист України", IsDeleted = 0 },
            new Subject { Id = 12, Name = "Українська література", IsDeleted = 0 },
            new Subject { Id = 13, Name = "Зарубіжна література", IsDeleted = 0 },
            new Subject { Id = 14, Name = "Креслення", IsDeleted = 0 },
            new Subject { Id = 15, Name = "Фізична культура", IsDeleted = 0 },
            new Subject { Id = 16, Name = "Інформатика", IsDeleted = 0 }
        );

        // --- 5. ГРУПИ ---
        modelBuilder.Entity<Group>().HasData(
            new Group { Id = 1, Name = "ФБС-1/1", Course = 1, Specialty = "Фінанси, банківська справа", Shift = 1, IsDeleted = 0 },
            new Group { Id = 2, Name = "ОП-1/1", Course = 1, Specialty = "Облік і податки", Shift = 1, IsDeleted = 0 },
            new Group { Id = 3, Name = "ЕКР-1/1", Course = 1, Specialty = "Економіка", Shift = 1, IsDeleted = 0 },
            new Group { Id = 4, Name = "ІПЗ-1/1", Course = 1, Specialty = "Інженерія ПЗ", Shift = 1, IsDeleted = 0 },
            new Group { Id = 5, Name = "ІПЗ-1/2", Course = 1, Specialty = "Інженерія ПЗ", Shift = 1, IsDeleted = 0 },
            new Group { Id = 6, Name = "КН-1/1", Course = 1, Specialty = "Комп'ютерні науки", Shift = 1, IsDeleted = 0 },
            new Group { Id = 7, Name = "М-1/1", Course = 1, Specialty = "Менеджмент", Shift = 1, IsDeleted = 0 },
            new Group { Id = 8, Name = "М-1/2", Course = 1, Specialty = "Менеджмент", Shift = 1, IsDeleted = 0 },
            new Group { Id = 9, Name = "ГРС-1/1", Course = 1, Specialty = "Готельно-ресторанна справа", Shift = 1, IsDeleted = 0 },
            new Group { Id = 10, Name = "ГРС-1/2", Course = 1, Specialty = "Готельно-ресторанна справа", Shift = 1, IsDeleted = 0 },
            new Group { Id = 11, Name = "ХТ-1/1", Course = 1, Specialty = "Харчові технології", Shift = 1, IsDeleted = 0 },
            new Group { Id = 12, Name = "ХТ-1/2", Course = 1, Specialty = "Харчові технології", Shift = 1, IsDeleted = 0 },
            new Group { Id = 13, Name = "ФБС-2/1", Course = 2, Specialty = "Фінанси, банківська справа", Shift = 1, IsDeleted = 0 },
            new Group { Id = 14, Name = "ФБС-2/2", Course = 2, Specialty = "Фінанси, банківська справа", Shift = 1, IsDeleted = 0 },
            new Group { Id = 15, Name = "ОП-2/1", Course = 2, Specialty = "Облік і податки", Shift = 2, IsDeleted = 0 },
            new Group { Id = 16, Name = "ІПЗ-2/1", Course = 2, Specialty = "Інженерія ПЗ", Shift = 1, IsDeleted = 0 },
            new Group { Id = 17, Name = "ІПЗ-2/2", Course = 2, Specialty = "Інженерія ПЗ", Shift = 1, IsDeleted = 0 },
            new Group { Id = 18, Name = "КН-2/1", Course = 2, Specialty = "Комп'ютерні науки", Shift = 1, IsDeleted = 0 },
            new Group { Id = 19, Name = "КН-2/2", Course = 2, Specialty = "Комп'ютерні науки", Shift = 1, IsDeleted = 0 },
            new Group { Id = 20, Name = "ПТ-2/1", Course = 2, Specialty = "Підприємництво та торгівля", Shift = 1, IsDeleted = 0 },
            new Group { Id = 21, Name = "ГРС-2/1", Course = 2, Specialty = "Готельно-ресторанна справа", Shift = 1, IsDeleted = 0 },
            new Group { Id = 22, Name = "ГРС-2/2", Course = 2, Specialty = "Готельно-ресторанна справа", Shift = 1, IsDeleted = 0 },
            new Group { Id = 23, Name = "ХТ-2/1", Course = 2, Specialty = "Харчові технології", Shift = 1, IsDeleted = 0 },
            new Group { Id = 24, Name = "ХТ-2/2", Course = 2, Specialty = "Харчові технології", Shift = 1, IsDeleted = 0 },
            new Group { Id = 25, Name = "ХТ-2/3", Course = 2, Specialty = "Харчові технології", Shift = 1, IsDeleted = 0 },
            new Group { Id = 26, Name = "ФБС-3/1", Course = 3, Specialty = "Фінанси, банківська справа", Shift = 1, IsDeleted = 0 },
            new Group { Id = 27, Name = "ОП-3/1", Course = 3, Specialty = "Облік і податки", Shift = 1, IsDeleted = 0 },
            new Group { Id = 28, Name = "ХТ-3/1", Course = 3, Specialty = "Харчові технології", Shift = 1, IsDeleted = 0 },
            new Group { Id = 29, Name = "ХТ-3/2", Course = 3, Specialty = "Харчові технології", Shift = 1, IsDeleted = 0 },
            new Group { Id = 30, Name = "ХТ-3/3", Course = 3, Specialty = "Харчові технології", Shift = 1, IsDeleted = 0 },
            new Group { Id = 31, Name = "ГРС-3/1", Course = 3, Specialty = "Готельно-ресторанна справа", Shift = 1, IsDeleted = 0 },
            new Group { Id = 32, Name = "ТР-3/1", Course = 3, Specialty = "Туризм і рекреація", Shift = 1, IsDeleted = 0 },
            new Group { Id = 33, Name = "ПТ-3/1", Course = 3, Specialty = "Підприємництво та торгівля", Shift = 1, IsDeleted = 0 },
            new Group { Id = 34, Name = "ПТ-3/2", Course = 3, Specialty = "Підприємництво та торгівля", Shift = 1, IsDeleted = 0 },
            new Group { Id = 35, Name = "ІПЗ-3/1", Course = 3, Specialty = "Інженерія ПЗ", Shift = 1, IsDeleted = 0 },
            new Group { Id = 36, Name = "ІПЗ-3/2", Course = 3, Specialty = "Інженерія ПЗ", Shift = 1, IsDeleted = 0 },
            new Group { Id = 37, Name = "КН-3/1", Course = 3, Specialty = "Комп'ютерні науки", Shift = 1, IsDeleted = 0 },
            new Group { Id = 38, Name = "ІПЗ-4/1", Course = 4, Specialty = "Інженерія ПЗ", Shift = 1, IsDeleted = 0 }
        );

        // --- 6. ВИКЛАДАЧІ ---
        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 1, FullName = "Кадубець Д. З.", ContactInfo = "dkadubets@...", IsDeleted = 0 },
            new Teacher { Id = 2, FullName = "Меркушева І. В.", ContactInfo = "imerkusheva@...", IsDeleted = 0 },
            new Teacher { Id = 3, FullName = "Ковальчук С. К.", ContactInfo = "skovalchuk@...", IsDeleted = 0 },
            new Teacher { Id = 4, FullName = "Камінська С. М.", ContactInfo = "kaminska@...", IsDeleted = 0 },
            new Teacher { Id = 5, FullName = "Конончук І. М.", ContactInfo = "ikononchuk@...", IsDeleted = 0 },
            new Teacher { Id = 6, FullName = "Криволисова К. А.", ContactInfo = "kkryvolysova@...", IsDeleted = 0 },
            new Teacher { Id = 7, FullName = "Музика Н. І.", ContactInfo = "nmuzyka@...", IsDeleted = 0 },
            new Teacher { Id = 8, FullName = "Власова М. В.", ContactInfo = "mvlasova@...", IsDeleted = 0 },
            new Teacher { Id = 9, FullName = "Оніщук К. І.", ContactInfo = "konishchuk@...", IsDeleted = 0 },
            new Teacher { Id = 10, FullName = "Антоневич Ю. А.", ContactInfo = "yuantonevych@...", IsDeleted = 0 },
            new Teacher { Id = 11, FullName = "Бойчук М. М.", ContactInfo = "boichuk@...", IsDeleted = 0 },
            new Teacher { Id = 12, FullName = "Погодіна Н. В.", ContactInfo = "npohodina@...", IsDeleted = 0 },
            new Teacher { Id = 13, FullName = "Шевчук К. В.", ContactInfo = "kshevchuk@...", IsDeleted = 0 },
            new Teacher { Id = 14, FullName = "Гонтар В. Є.", ContactInfo = "vhontar@...", IsDeleted = 0 },
            new Teacher { Id = 15, FullName = "Єфімчук С. О.", ContactInfo = "syefimchuk@...", IsDeleted = 0 },
            new Teacher { Id = 16, FullName = "Федорчук Р. Ю.", ContactInfo = "rfedorchuk@...", IsDeleted = 0 },
            new Teacher { Id = 17, FullName = "Курчик О. Ю.", ContactInfo = "okurchyk@...", IsDeleted = 0 },
            new Teacher { Id = 18, FullName = "Качан О. В.", ContactInfo = "oprokopchuk@...", IsDeleted = 0 },
            new Teacher { Id = 19, FullName = "Репута І. А.", ContactInfo = "i.a.reputa@...", IsDeleted = 0 },
            new Teacher { Id = 20, FullName = "Сухецька А. С.", ContactInfo = "asukhetska@...", IsDeleted = 0 },
            new Teacher { Id = 21, FullName = "Рицко О. В.", ContactInfo = "olricko@...", IsDeleted = 0 },
            new Teacher { Id = 22, FullName = "Артемюк О. А.", ContactInfo = "oartemiuk@...", IsDeleted = 0 },
            new Teacher { Id = 23, FullName = "Багнюк А. В.", ContactInfo = "abahniuk@...", IsDeleted = 0 },
            new Teacher { Id = 24, FullName = "Данилов В. В.", ContactInfo = "vdanylov@...", IsDeleted = 0 },
            new Teacher { Id = 25, FullName = "Чуприна Н. Я.", ContactInfo = "nchupryna@...", IsDeleted = 0 },
            new Teacher { Id = 26, FullName = "Шпортько О.В.", ContactInfo = "oshportko@...", IsDeleted = 0 },
            new Teacher { Id = 27, FullName = "Бодова Т. В.", ContactInfo = "bodova@...", IsDeleted = 0 },
            new Teacher { Id = 28, FullName = "Кривошеєва І. Д.", ContactInfo = "kryvosheeva@...", IsDeleted = 0 },
            new Teacher { Id = 29, FullName = "Рожко В. В.", ContactInfo = "rozhko@...", IsDeleted = 0 },
            new Teacher { Id = 30, FullName = "Ойцюсь А. М.", ContactInfo = "aoitsius@...", IsDeleted = 0 },
            new Teacher { Id = 31, FullName = "Мельник А. І.", ContactInfo = "andriymelnik@...", IsDeleted = 0 },
            new Teacher { Id = 32, FullName = "Козлинець Л. І.", ContactInfo = "lkozlynets@...", IsDeleted = 0 },
            new Teacher { Id = 33, FullName = "Козлинець О. Ю.", ContactInfo = "okozlynets@...", IsDeleted = 0 },
            new Teacher { Id = 34, FullName = "Веремчук Ю. В.", ContactInfo = "u.v.veremchuk@...", IsDeleted = 0 },
            new Teacher { Id = 35, FullName = "Колодич Ю. М.", ContactInfo = "yukolodych@...", IsDeleted = 0 },
            new Teacher { Id = 36, FullName = "В'юн М. І.", ContactInfo = "mviun@...", IsDeleted = 0 },
            new Teacher { Id = 37, FullName = "Печенюк С. М.", ContactInfo = "specheniuk@...", IsDeleted = 0 },
            new Teacher { Id = 38, FullName = "Мельниченко С. А.", ContactInfo = "smelnychenko@...", IsDeleted = 0 },
            new Teacher { Id = 39, FullName = "Лагоднюк Д. О.", ContactInfo = "d.o.lahodniuk@...", IsDeleted = 0 },
            new Teacher { Id = 40, FullName = "Бойко М. В.", ContactInfo = "m.v.boiko@...", IsDeleted = 0 },
            new Teacher { Id = 41, FullName = "Жадан В. В.", ContactInfo = "vzhadan@...", IsDeleted = 0 },
            new Teacher { Id = 42, FullName = "Подерня Т. П.", ContactInfo = "tpodernia@...", IsDeleted = 0 },
            new Teacher { Id = 43, FullName = "Вербило Т. В.", ContactInfo = "tverbylo@...", IsDeleted = 0 },
            new Teacher { Id = 44, FullName = "Опанасик А. В.", ContactInfo = "aopanasyk@...", IsDeleted = 0 },
            new Teacher { Id = 45, FullName = "Гусевик Г. М.", ContactInfo = "hhusevyk@...", IsDeleted = 0 },
            new Teacher { Id = 46, FullName = "Назаров А. Л.", ContactInfo = "admin@...", IsDeleted = 0 },
            new Teacher { Id = 47, FullName = "Зиль Н. Ф.", ContactInfo = "nadzyl@...", IsDeleted = 0 },
            new Teacher { Id = 48, FullName = "Комончук О. І.", ContactInfo = "okomonchuk@...", IsDeleted = 0 },
            new Teacher { Id = 49, FullName = "Гурса О. В.", ContactInfo = "o.v.gursa@...", IsDeleted = 0 },
            new Teacher { Id = 50, FullName = "Скора О. М.", ContactInfo = "oskora@...", IsDeleted = 0 },
            new Teacher { Id = 51, FullName = "Степанченко О. М.", ContactInfo = "o.m.stepanchenko@...", IsDeleted = 0 },
            new Teacher { Id = 52, FullName = "Целюк Ю. Б.", ContactInfo = "iu.b.tseliuk@...", IsDeleted = 0 },
            new Teacher { Id = 53, FullName = "Шапірко В. М.", ContactInfo = "v.m.shapirko@...", IsDeleted = 0 },
            new Teacher { Id = 54, FullName = "Бондарець М. І.", ContactInfo = "mariiabondarec@...", IsDeleted = 0 },
            new Teacher { Id = 55, FullName = "Шапілова К. П.", ContactInfo = "k.p.shapilova@...", IsDeleted = 0 },
            new Teacher { Id = 56, FullName = "Артемюк В. П.", ContactInfo = "vartemiuk@...", IsDeleted = 0 },
            new Teacher { Id = 57, FullName = "Якимчук В. Л.", ContactInfo = "v.l.yakimchuk@...", IsDeleted = 0 },
            new Teacher { Id = 58, FullName = "Шостак Л. В.", ContactInfo = "l.v.shostak@...", IsDeleted = 0 },
            new Teacher { Id = 59, FullName = "Навчальна частина", ContactInfo = "navchalna@...", IsDeleted = 0 },
            new Teacher { Id = 60, FullName = "Бойко В. В.", ContactInfo = "v.v.boiko@...", IsDeleted = 0 },
            new Teacher { Id = 61, FullName = "Бубнов О. В.", ContactInfo = "o.v.bubnov@...", IsDeleted = 0 },
            new Teacher { Id = 62, FullName = "Ніколаєнко А. І.", ContactInfo = "a.i.nikolaienko@...", IsDeleted = 0 },
            new Teacher { Id = 63, FullName = "Уксусов І. С.", ContactInfo = "i.s.uksusov@...", IsDeleted = 0 },
            new Teacher { Id = 64, FullName = "Филипюк О. С.", ContactInfo = "fylypuk_o@...", IsDeleted = 0 },
            new Teacher { Id = 65, FullName = "Бібліотека РФКІТ", ContactInfo = "library@...", IsDeleted = 0 },
            new Teacher { Id = 66, FullName = "Мельник Я. А.", ContactInfo = "melnyk.ia.a@...", IsDeleted = 0 },
            new Teacher { Id = 67, FullName = "Кушнір Р. І.", ContactInfo = "r.i.kushnir@...", IsDeleted = 0 },
            new Teacher { Id = 68, FullName = "Пермяков А. Г.", ContactInfo = "permiakov.a.h@...", IsDeleted = 0 },
            new Teacher { Id = 69, FullName = "Мельничук А. О.", ContactInfo = "melnychuk.a.o@...", IsDeleted = 0 },
            new Teacher { Id = 70, FullName = "Бялик М. В.", ContactInfo = "m.v.bialyk@...", IsDeleted = 0 },
            new Teacher { Id = 71, FullName = "Шпак Т. Ю.", ContactInfo = "shpak.t.iu@...", IsDeleted = 0 },
            new Teacher { Id = 72, FullName = "Свирид Н. Р.", ContactInfo = "svyryd.n.r@...", IsDeleted = 0 }
        );

        // --- 7. РОЗКЛАД ЗАПЛАНОВАНИХ ПАР ---
        modelBuilder.Entity<Schedule>().HasData(
            // ПОНЕДІЛОК
            new Schedule { Id = 1, GroupId = 6, TeacherId = 37, SubjectId = 1, AudienceId = 17, Date = "2026-03-30", LessonNumber = 1, LessonType = "Лекція", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 2, GroupId = 6, TeacherId = 9, SubjectId = 2, AudienceId = 30, Date = "2026-03-30", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 3, GroupId = 6, TeacherId = 60, SubjectId = 3, AudienceId = 24, Date = "2026-03-30", LessonNumber = 3, LessonType = "Лекція", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 4, GroupId = 6, TeacherId = 50, SubjectId = 4, AudienceId = 10, Date = "2026-03-30", LessonNumber = 4, LessonType = "Практика", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 5, GroupId = 7, TeacherId = 6, SubjectId = 5, AudienceId = 18, Date = "2026-03-30", LessonNumber = 1, LessonType = "Лекція", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 6, GroupId = 7, TeacherId = 12, SubjectId = 6, AudienceId = 15, Date = "2026-03-30", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 7, GroupId = 7, TeacherId = 16, SubjectId = 7, AudienceId = 25, Date = "2026-03-30", LessonNumber = 3, LessonType = "Лекція", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 8, GroupId = 7, TeacherId = 9, SubjectId = 1, AudienceId = 30, Date = "2026-03-30", LessonNumber = 4, LessonType = "Лекція", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 9, GroupId = 8, TeacherId = 8, SubjectId = 8, AudienceId = 23, Date = "2026-03-30", LessonNumber = 2, LessonType = "Практика", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 10, GroupId = 8, TeacherId = 8, SubjectId = 8, AudienceId = 23, Date = "2026-03-30", LessonNumber = 3, LessonType = "Практика", DayOfWeek = "Понеділок", IsEvenWeek = 0 },
            new Schedule { Id = 11, GroupId = 8, TeacherId = 23, SubjectId = 9, AudienceId = 24, Date = "2026-03-30", LessonNumber = 4, LessonType = "Лекція", DayOfWeek = "Понеділок", IsEvenWeek = 0 },

            // ВІВТОРОК
            new Schedule { Id = 12, GroupId = 6, TeacherId = 9, SubjectId = 2, AudienceId = 16, Date = "2026-03-31", LessonNumber = 1, LessonType = "Лекція", DayOfWeek = "Вівторок", IsEvenWeek = 0 },
            new Schedule { Id = 13, GroupId = 6, TeacherId = 68, SubjectId = 8, AudienceId = 13, Date = "2026-03-31", LessonNumber = 2, LessonType = "Практика", DayOfWeek = "Вівторок", IsEvenWeek = 0 },
            new Schedule { Id = 14, GroupId = 6, TeacherId = 46, SubjectId = 10, AudienceId = 3, Date = "2026-03-31", LessonNumber = 3, LessonType = "Лабораторна", DayOfWeek = "Вівторок", IsEvenWeek = 0 },
            new Schedule { Id = 15, GroupId = 6, TeacherId = 10, SubjectId = 3, AudienceId = 15, Date = "2026-03-31", LessonNumber = 4, LessonType = "Лекція", DayOfWeek = "Вівторок", IsEvenWeek = 0 },
            new Schedule { Id = 16, GroupId = 7, TeacherId = 15, SubjectId = 5, AudienceId = 24, Date = "2026-03-31", LessonNumber = 1, LessonType = "Лекція", DayOfWeek = "Вівторок", IsEvenWeek = 0 },
            new Schedule { Id = 17, GroupId = 7, TeacherId = 64, SubjectId = 11, AudienceId = 8, Date = "2026-03-31", LessonNumber = 2, LessonType = "Практика", DayOfWeek = "Вівторок", IsEvenWeek = 0 },
            new Schedule { Id = 18, GroupId = 7, TeacherId = 10, SubjectId = 3, AudienceId = 22, Date = "2026-03-31", LessonNumber = 3, LessonType = "Лекція", DayOfWeek = "Вівторок", IsEvenWeek = 0 },
            new Schedule { Id = 19, GroupId = 8, TeacherId = 10, SubjectId = 16, AudienceId = 3, Date = "2026-03-31", LessonNumber = 1, LessonType = "Лабораторна", DayOfWeek = "Вівторок", IsEvenWeek = 0 },
            new Schedule { Id = 20, GroupId = 8, TeacherId = 15, SubjectId = 5, AudienceId = 1, Date = "2026-03-31", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "Вівторок", IsEvenWeek = 0 },
            new Schedule { Id = 21, GroupId = 8, TeacherId = 16, SubjectId = 7, AudienceId = 25, Date = "2026-03-31", LessonNumber = 3, LessonType = "Лекція", DayOfWeek = "Вівторок", IsEvenWeek = 0 },

            // СЕРЕДА
            new Schedule { Id = 22, GroupId = 6, TeacherId = 9, SubjectId = 2, AudienceId = 30, Date = "2026-04-01", LessonNumber = 1, LessonType = "Лекція", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 23, GroupId = 6, TeacherId = 43, SubjectId = 12, AudienceId = 11, Date = "2026-04-01", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 24, GroupId = 6, TeacherId = 72, SubjectId = 11, AudienceId = 8, Date = "2026-04-01", LessonNumber = 3, LessonType = "Практика", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 25, GroupId = 6, TeacherId = 30, SubjectId = 9, AudienceId = 30, Date = "2026-04-01", LessonNumber = 4, LessonType = "Лекція", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 26, GroupId = 7, TeacherId = 56, SubjectId = 1, AudienceId = 20, Date = "2026-04-01", LessonNumber = 1, LessonType = "Лекція", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 27, GroupId = 7, TeacherId = 6, SubjectId = 5, AudienceId = 25, Date = "2026-04-01", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 28, GroupId = 7, TeacherId = 44, SubjectId = 8, AudienceId = 19, Date = "2026-04-01", LessonNumber = 3, LessonType = "Практика", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 29, GroupId = 7, TeacherId = 43, SubjectId = 12, AudienceId = 11, Date = "2026-04-01", LessonNumber = 4, LessonType = "Лекція", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 30, GroupId = 8, TeacherId = 14, SubjectId = 8, AudienceId = 29, Date = "2026-04-01", LessonNumber = 1, LessonType = "Практика", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 31, GroupId = 8, TeacherId = 12, SubjectId = 6, AudienceId = 15, Date = "2026-04-01", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 32, GroupId = 8, TeacherId = 6, SubjectId = 5, AudienceId = 17, Date = "2026-04-01", LessonNumber = 3, LessonType = "Лекція", DayOfWeek = "Середа", IsEvenWeek = 0 },
            new Schedule { Id = 33, GroupId = 8, TeacherId = 54, SubjectId = 13, AudienceId = 29, Date = "2026-04-01", LessonNumber = 4, LessonType = "Лекція", DayOfWeek = "Середа", IsEvenWeek = 0 },

            // ЧЕТВЕР
            new Schedule { Id = 34, GroupId = 6, TeacherId = 6, SubjectId = 14, AudienceId = 30, Date = "2026-04-02", LessonNumber = 1, LessonType = "Практика", DayOfWeek = "Четвер", IsEvenWeek = 0 },
            new Schedule { Id = 35, GroupId = 6, TeacherId = 55, SubjectId = 6, AudienceId = 32, Date = "2026-04-02", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "Четвер", IsEvenWeek = 0 },
            new Schedule { Id = 36, GroupId = 6, TeacherId = 68, SubjectId = 3, AudienceId = 19, Date = "2026-04-02", LessonNumber = 3, LessonType = "Лекція", DayOfWeek = "Четвер", IsEvenWeek = 0 },
            new Schedule { Id = 37, GroupId = 6, TeacherId = 5, SubjectId = 15, AudienceId = 7, Date = "2026-04-02", LessonNumber = 4, LessonType = "Практика", DayOfWeek = "Четвер", IsEvenWeek = 0 },
            new Schedule { Id = 38, GroupId = 7, TeacherId = 10, SubjectId = 3, AudienceId = 24, Date = "2026-04-02", LessonNumber = 1, LessonType = "Лекція", DayOfWeek = "Четвер", IsEvenWeek = 0 },
            new Schedule { Id = 39, GroupId = 7, TeacherId = 56, SubjectId = 1, AudienceId = 20, Date = "2026-04-02", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "Четвер", IsEvenWeek = 0 },
            new Schedule { Id = 40, GroupId = 7, TeacherId = 10, SubjectId = 3, AudienceId = 16, Date = "2026-04-02", LessonNumber = 3, LessonType = "Лекція", DayOfWeek = "Четвер", IsEvenWeek = 0 },
            new Schedule { Id = 41, GroupId = 7, TeacherId = 23, SubjectId = 9, AudienceId = 24, Date = "2026-04-02", LessonNumber = 4, LessonType = "Лекція", DayOfWeek = "Четвер", IsEvenWeek = 0 },
            new Schedule { Id = 42, GroupId = 8, TeacherId = 11, SubjectId = 16, AudienceId = 1, Date = "2026-04-02", LessonNumber = 1, LessonType = "Лабораторна", DayOfWeek = "Четвер", IsEvenWeek = 0 },

            // П'ЯТНИЦЯ
            new Schedule { Id = 43, GroupId = 6, TeacherId = 10, SubjectId = 3, AudienceId = 3, Date = "2026-04-03", LessonNumber = 1, LessonType = "Лекція", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 44, GroupId = 6, TeacherId = 50, SubjectId = 4, AudienceId = 10, Date = "2026-04-03", LessonNumber = 2, LessonType = "Практика", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 45, GroupId = 6, TeacherId = 9, SubjectId = 1, AudienceId = 30, Date = "2026-04-03", LessonNumber = 3, LessonType = "Лекція", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 46, GroupId = 6, TeacherId = 12, SubjectId = 12, AudienceId = 15, Date = "2026-04-03", LessonNumber = 4, LessonType = "Лекція", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 47, GroupId = 7, TeacherId = 6, SubjectId = 5, AudienceId = 18, Date = "2026-04-03", LessonNumber = 1, LessonType = "Лекція", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 48, GroupId = 7, TeacherId = 15, SubjectId = 5, AudienceId = 29, Date = "2026-04-03", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 49, GroupId = 7, TeacherId = 15, SubjectId = 5, AudienceId = 1, Date = "2026-04-03", LessonNumber = 3, LessonType = "Лекція", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 50, GroupId = 7, TeacherId = 72, SubjectId = 11, AudienceId = 23, Date = "2026-04-03", LessonNumber = 4, LessonType = "Практика", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 51, GroupId = 8, TeacherId = 11, SubjectId = 16, AudienceId = 2, Date = "2026-04-03", LessonNumber = 1, LessonType = "Лабораторна", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 52, GroupId = 8, TeacherId = 10, SubjectId = 3, AudienceId = 2, Date = "2026-04-03", LessonNumber = 2, LessonType = "Лекція", DayOfWeek = "П'ятниця", IsEvenWeek = 0 },
            new Schedule { Id = 53, GroupId = 8, TeacherId = 21, SubjectId = 15, AudienceId = 7, Date = "2026-04-03", LessonNumber = 3, LessonType = "Практика", DayOfWeek = "П'ятниця", IsEvenWeek = 0 }
        );
    }
}