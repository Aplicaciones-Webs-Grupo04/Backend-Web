using Microsoft.EntityFrameworkCore;
using psymed_platform.Application.Services;
using psymed_platform.Domain.Repositories;
using psymed_platform.Infrastructure.Data;
namespace psymed_platform.Appointment_Managment_Bc.WebApi;

public static class Configurations
{
    public static void ConfigureApi(this WebApplicationBuilder builder)
    {
        // Configura la conexión a la base de datos MySQL
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 23)))); // Cambia la versión según tu instalación

        // Registra el repositorio y el servicio
        builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        builder.Services.AddScoped<AppointmentService>();

        // Agrega Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void ConfigureEndpoints(this WebApplication app)
    {
        // Configure Swagger
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Endpoint para obtener todas las citas
        app.MapGet("/api/appointments", async (AppointmentService appointmentService) =>
            {
                var appointments = await appointmentService.GetAllAppointmentsAsync();
                return Results.Ok(appointments);
            })
            .WithName("GetAllAppointments")
            .WithOpenApi();

        // Endpoint para crear una nueva cita
        app.MapPost("/api/appointments", async (AppointmentService appointmentService, Appointment appointment) =>
            {
                await appointmentService.AddAppointmentAsync(appointment);
                return Results.Created($"/api/appointments/{appointment.Id}", appointment);
            })
            .WithName("CreateAppointment")
            .WithOpenApi();
    }
}