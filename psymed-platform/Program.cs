using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using psymed_platform.Tasks.Domain.Model.Repositories;
using psymed_platform.Tasks.Infrastructure.Repositories;
using psymed_platform.Tasks.Application.Internal.CommandServices;
using psymed_platform.Tasks.Application.Internal.QueryServices;

var builder = WebApplication.CreateBuilder(args);

//TODO: falta Configurar la conexión con el MySQL 
//Nota de sihuar no se logró me sale un error con el mysql :( y en el properties ya configuré el puerto eso falta cambiarlo

// Agrega controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agrega los servicios de tareas
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskCommandService>();
builder.Services.AddScoped<TaskQueryService>();

var app = builder.Build();

// Habilita Swagger en modo de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();