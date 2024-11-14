using System;

namespace psymed_platform.Models
{
    /// <summary>
    /// Representa un diagnóstico asignado a un paciente.
    /// </summary>
    public class Diagnosis
    {
        // Identificador único del diagnóstico.
        public int Id { get; set; }

        // Identificador del paciente asociado a este diagnóstico.
        public int PatientId { get; set; }

        // Nombre del diagnóstico.
        public string DiagnosisName { get; set; }

        // Descripción del diagnóstico.
        public string Description { get; set; }

        // Fecha en que se realizó el diagnóstico.
        public DateTime DateDiagnosed { get; set; }
    }
}