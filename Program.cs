using Microsoft.EntityFrameworkCore;
using ScheduleWeb.Data;
using ScheduleWeb.Repositories;
using ScheduleWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. ДОДАВАННЯ СЕРВІСІВ (Контейнер залежностей)
builder.Services.AddControllers();

// Налаштування Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Налаштування підключення до SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Реєстрація твоїх власних репозиторіїв та сервісів
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IValidationService, ValidationService>();

// Налаштування CORS (щоб фронтенд не блокувався браузером)
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// 2. НАЛАШТУВАННЯ HTTP-КОНВЕЄРА (Порядок критично важливий!)

// Вмикаємо Swagger незалежно від середовища, щоб ти завжди міг перевірити API
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Розклад РФКІТ API v1");
});

// ПІДТРИМКА ФРОНТЕНДУ (wwwroot)
// Спочатку шукаємо index.html, потім дозволяємо роздавати статичні файли (css/js)
app.UseDefaultFiles(); 
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAll");

app.UseAuthorization();

// Мапінг контролерів API
app.MapControllers();

// Запуск сервера
app.Run();