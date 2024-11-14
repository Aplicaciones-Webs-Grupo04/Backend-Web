using System;

namespace psymed_platform.Models
{
    /// <summary>
    /// Representa un medicamento asignado a un paciente.
    /// </summary>
    public class Medication
    {
        // Identificador único del medicamento.
        public int Id { get; set; }

        // Identificador del paciente asociado a este medicamento.
        public int PatientId { get; set; }

        // Nombre del medicamento.
        public string Name { get; set; }

        // Dosificación del medicamento (por ejemplo, "500 mg").
        public string Dosage { get; set; }

        // Frecuencia de administración del medicamento (por ejemplo, "2 veces al día").
        public string Frequency { get; set; }

        // Fecha en que se prescribió el medicamento.
        public DateTime DatePrescribed { get; set; }
    }
}