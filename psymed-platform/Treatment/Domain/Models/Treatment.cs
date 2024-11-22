namespace psymed_platform.Treatment.Domain.Models;

public class Treatment
{
    
    public int Id { get; set; }
    public string NombrePaciente { get; set; }
    public DateTime Fecha { get; set; }
    public string Tratamiento { get; set; }

}