using psymed_platform.Appointment_managment.Domain.Models;

namespace psymed_platform.Appointment_Managment_Bc.Domain.Repositories;

public class IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAllAsync();
    Task<Appointment> GetByIdAsync(int id);
    Task AddAsync(Appointment appointment);
}