using System;
using System.Collections.Generic;
using System.Linq;
using psymed_platform.Data;
using psymed_platform.Models;
using Microsoft.EntityFrameworkCore;

namespace psymed_platform.Services
{
    /// <summary>
    /// Servicio para manejar operaciones CRUD relacionadas con las entradas del diario del paciente.
    /// Permite crear, obtener, actualizar y eliminar entradas de diario.
    /// </summary>
    public class JournalService
    {
        private readonly ApplicationDbContextEntrys _context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">El contexto de base de datos de la aplicación</param>
        public JournalService(ApplicationDbContextEntrys context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las entradas de diario de un paciente específico.
        /// </summary>
        /// <param name="patientId">ID del paciente.</param>
        /// <returns>Lista de entradas de diario del paciente.</returns>
        public List<JournalEntry> GetJournalEntriesByPatient(int patientId)
        {
            return _context.JournalEntries
                           .Where(j => j.PatientId == patientId)
                           .OrderByDescending(j => j.DateCreated)
                           .ToList();
        }

        /// <summary>
        /// Obtiene una entrada de diario por su ID.
        /// </summary>
        /// <param name="id">ID de la entrada de diario.</param>
        /// <returns>Entrada de diario o null si no se encuentra.</returns>
        public JournalEntry GetJournalEntryById(int id)
        {
            return _context.JournalEntries.FirstOrDefault(j => j.Id == id);
        }

        /// <summary>
        /// Crea una nueva entrada en el diario.
        /// </summary>
        /// <param name="journalEntry">La entrada de diario a crear.</param>
        /// <returns>La entrada de diario creada.</returns>
        public JournalEntry CreateJournalEntry(JournalEntry journalEntry)
        {
            journalEntry.DateCreated = DateTime.Now;
            _context.JournalEntries.Add(journalEntry);
            _context.SaveChanges();
            return journalEntry;
        }

        /// <summary>
        /// Actualiza una entrada de diario existente.
        /// </summary>
        /// <param name="id">ID de la entrada de diario a actualizar.</param>
        /// <param name="updatedJournalEntry">Entrada de diario actualizada.</param>
        /// <returns>La entrada de diario actualizada o null si no se encuentra.</returns>
        public JournalEntry UpdateJournalEntry(int id, JournalEntry updatedJournalEntry)
        {
            var journalEntry = _context.JournalEntries.FirstOrDefault(j => j.Id == id);
            if (journalEntry == null) return null;

            // Actualiza los datos de la entrada de diario
            journalEntry.Title = updatedJournalEntry.Title;
            journalEntry.Content = updatedJournalEntry.Content;

            _context.SaveChanges();
            return journalEntry;
        }

        /// <summary>
        /// Elimina una entrada de diario por su ID.
        /// </summary>
        /// <param name="id">ID de la entrada de diario a eliminar.</param>
        /// <returns>True si la entrada fue eliminada, false si no se encontró.</returns>
        public bool DeleteJournalEntry(int id)
        {
            var journalEntry = _context.JournalEntries.FirstOrDefault(j => j.Id == id);
            if (journalEntry == null) return false;

            // Elimina la entrada de diario de la base de datos
            _context.JournalEntries.Remove(journalEntry);
            _context.SaveChanges();
            return true;
        }
    }
}
