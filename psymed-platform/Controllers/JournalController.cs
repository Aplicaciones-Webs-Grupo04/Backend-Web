using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using psymed_platform.Models;
using psymed_platform.Services;

namespace psymed_platform.Controllers
{
    /// <summary>
    /// Controlador para manejar las solicitudes HTTP relacionadas con las entradas de diario del paciente.
    /// Proporciona operaciones CRUD para las entradas de diario.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly JournalService _journalService;

        /// <summary>
        /// Constructor que inyecta el servicio de diario.
        /// </summary>
        public JournalController(JournalService journalService)
        {
            _journalService = journalService;
        }

        /// <summary>
        /// Obtiene todas las entradas de diario de un paciente.
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public ActionResult<List<JournalEntry>> GetJournalEntriesByPatient(int patientId)
        {
            return _journalService.GetJournalEntriesByPatient(patientId);
        }

        /// <summary>
        /// Obtiene una entrada de diario por su ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<JournalEntry> GetJournalEntryById(int id)
        {
            var journalEntry = _journalService.GetJournalEntryById(id);
            if (journalEntry == null)
            {
                return NotFound();
            }
            return journalEntry;
        }

        /// <summary>
        /// Crea una nueva entrada en el diario.
        /// </summary>
        [HttpPost]
        public ActionResult<JournalEntry> CreateJournalEntry(JournalEntry journalEntry)
        {
            var createdJournal = _journalService.CreateJournalEntry(journalEntry);
            return CreatedAtAction(nameof(GetJournalEntryById), new { id = createdJournal.Id }, createdJournal);
        }

        /// <summary>
        /// Actualiza una entrada de diario existente.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<JournalEntry> UpdateJournalEntry(int id, JournalEntry updatedJournalEntry)
        {
            var journalEntry = _journalService.UpdateJournalEntry(id, updatedJournalEntry);
            if (journalEntry == null)
            {
                return NotFound();
            }
            return journalEntry;
        }

        /// <summary>
        /// Elimina una entrada de diario por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteJournalEntry(int id)
        {
            var success = _journalService.DeleteJournalEntry(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
