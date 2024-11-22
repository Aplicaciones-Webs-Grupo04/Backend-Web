using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using psymed_platform.Tasks.Domain.Model.Repositories;
using psymed_platform.Tasks.Infrastructure.Repositories;
using psymed_platform.Tasks.Application.Internal.CommandServices;
using psymed_platform.Tasks.Application.Internal.QueryServices;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using psymed_platform.Profiles.Domain.Repositories;
using psymed_platform.Profiles.Application.Internal.CommandServices;
using psymed_platform.Profiles.Domain.Services;
using psymed_platform.Profiles.Infrastructure.Persistence.EFC.Repositories;
using psymed_platform.Shared.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión con MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

// Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agrega los servicios de tareas
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskCommandService>();
builder.Services.AddScoped<TaskQueryService>();

// Registrar UnitOfWork y repositorios
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

// Registrar servicios de aplicación
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();

var app = builder.Build();

// Aplicar migraciones al iniciar la aplicación
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

// Habilitar Swagger en modo de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.MapControllers();
app.Run();

