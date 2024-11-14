using System;

namespace psymed_platform.Models
{
    /// <summary>
    /// Representa una función biológica registrada para un paciente.
    /// </summary>
    public class BiologicalFunction
    {
        // Identificador único de la función biológica.
        public int Id { get; set; }

        // Identificador del paciente asociado a esta función biológica.
        public int PatientId { get; set; }

        // Tipo de función biológica (por ejemplo, "Sueño", "Hambre", "Energía").
        public string FunctionType { get; set; }

        // Valor de la función biológica (por ejemplo, en una escala del 1 al 10).
        public int Value { get; set; }

        // Fecha y hora en que se registró la función biológica.
        public DateTime DateRecorded { get; set; }
    }
}