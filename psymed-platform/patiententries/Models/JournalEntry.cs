using System;

namespace psymed_platform.Models
{
    /// <summary>
    /// Representa una entrada en el diario del paciente.
    /// </summary>
    public class JournalEntry
    {
        // Identificador único de la entrada del diario.
        public int Id { get; set; }

        // Identificador del paciente asociado a esta entrada.
        public int PatientId { get; set; }

        // Título de la entrada del diario.
        public string Title { get; set; }

        // Contenido de la entrada del diario.
        public string Content { get; set; }

        // Fecha en que se creó la entrada del diario.
        public DateTime DateCreated { get; set; }
    }
}