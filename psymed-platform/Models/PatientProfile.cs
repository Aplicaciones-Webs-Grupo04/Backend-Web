using System;
using System.Collections.Generic;

namespace psymed_platform.Models
{
    /// <summary>
    /// Representa el perfil de un paciente en la plataforma.
    /// Incluye datos personales y la asignación de diagnóstico y medicación.
    /// </summary>
    public class PatientProfile
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ContactInfo { get; set; }
        
        public string AssignedDoctor { get; set; }

        public List<Diagnosis> Diagnoses { get; set; }

        public List<Medication> Medications { get; set; }

        // Constructor para inicializar listas de diagnósticos y medicamentos.
        public PatientProfile()
        {
            Diagnoses = new List<Diagnosis>();
            Medications = new List<Medication>();
        }
    }
}