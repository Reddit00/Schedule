using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;
using ScheduleWeb.Repositories;
using ScheduleWeb.Services;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// 1. ФІКСУЄМО АБСОЛЮТНИЙ ШЛЯХ ДО БАЗИ
string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "school.db");

Console.WriteLine("\n==========================================");
Console.WriteLine($"ШЛЯХ ДО БАЗИ ДАНИХ: {dbPath}");
Console.WriteLine("==========================================\n");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// 2. Реєстрація сервісів
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IValidationService, ValidationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. ПЕРЕСТВОРЕННЯ БАЗИ (Адмін додасться автоматично з ApplicationDbContext)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
    // Видаляємо старий глючний файл
    context.Database.EnsureDeleted();
    
    // Створюємо нову базу (всі таблиці + адмін з твого DbContext)
    context.Database.EnsureCreated();
    Console.WriteLine(">>> База даних успішно ПЕРЕСТВОРЕНА з нуля!");
}

// 4. Налаштування Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();