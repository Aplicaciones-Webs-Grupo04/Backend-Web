using Microsoft.EntityFrameworkCore;
using psymed_platform.Models;

namespace psymed_platform.Data
{
    /// <summary>
    /// Contexto de base de datos para la plataforma PSYMED.
    /// Define las entidades y su configuración en la base de datos.
    /// </summary>
    public class ApplicationDbContextEntrys : DbContext
    {
        /// <summary>
        /// Constructor que acepta opciones de configuración para el contexto de base de datos.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ApplicationDbContextEntrys(DbContextOptions<ApplicationDbContextEntrys> options)
            : base(options)
        {
        }

        // DbSet para la entidad PatientProfile, que representa los perfiles de pacientes.
        public DbSet<PatientProfile> PatientProfiles { get; set; }

        // DbSet para la entidad MoodStatement, que representa los registros de estado de ánimo de los pacientes.
        public DbSet<MoodStatement> MoodStatements { get; set; }

        // DbSet para la entidad JournalEntry, que representa las entradas de diario de los pacientes.
        public DbSet<JournalEntry> JournalEntries { get; set; }

        // DbSet para la entidad Diagnosis, que representa los diagnósticos de los pacientes.
        public DbSet<Diagnosis> Diagnoses { get; set; }

        // DbSet para la entidad BiologicalFunction, que representa las funciones biológicas de los pacientes.
        public DbSet<BiologicalFunction> BiologicalFunctions { get; set; }

        // DbSet para la entidad Medication, que representa los medicamentos de los pacientes.
        public DbSet<Medication> Medications { get; set; }
    }
}