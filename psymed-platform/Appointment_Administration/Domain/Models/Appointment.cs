namespace psymed_platform.Appoiment_Administration.Domain.Models;

public class Appointment
{
    
    public int Id { get; set; }
    public string NombrePaciente { get; set; }
    public DateTime Fecha { get; set; }
    public string Motivo { get; set; }

}