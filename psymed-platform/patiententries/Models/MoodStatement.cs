using System;

namespace psymed_platform.Models
{
    /// <summary>
    /// Representa un registro del estado de ánimo de un paciente.
    /// </summary>
    public class MoodStatement
    {
        // Identificador único del registro de estado de ánimo.
        public int Id { get; set; }

        // Identificador del paciente asociado a este registro.
        public int PatientId { get; set; }

        // Nivel de estado de ánimo del paciente (por ejemplo, en una escala del 1 al 5).
        public int MoodLevel { get; set; }

        // Comentarios opcionales sobre el estado de ánimo.
        public string Notes { get; set; }

        // Fecha y hora del registro de estado de ánimo.
        public DateTime DateRecorded { get; set; }
    }
}