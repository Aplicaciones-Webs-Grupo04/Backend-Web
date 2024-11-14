using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using psymed_platform.Models;
using psymed_platform.Services;

namespace psymed_platform.Controllers
{
    /// <summary>
    /// Controlador para manejar las solicitudes HTTP relacionadas con el estado de ánimo del paciente.
    /// Proporciona operaciones CRUD para los registros de estado de ánimo.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MoodStatementController : ControllerBase
    {
        private readonly MoodStatementService _moodService;

        
        public MoodStatementController(MoodStatementService moodService)
        {
            _moodService = moodService;
        }
        
        /// Obtiene todos los registros de estado de ánimo de un paciente.

        [HttpGet("patient/{patientId}")]
        public ActionResult<List<MoodStatement>> GetMoodStatementsByPatient(int patientId)
        {
            return _moodService.GetMoodStatementsByPatient(patientId);
        }


        /// Obtiene un registro de estado de ánimo por su ID.
 
        [HttpGet("{id}")]
        public ActionResult<MoodStatement> GetMoodStatementById(int id)
        {
            var moodStatement = _moodService.GetMoodStatementById(id);
            if (moodStatement == null)
            {
                return NotFound();
            }
            return moodStatement;
        }
        
        /// Crea un nuevo registro de estado de ánimo.

        [HttpPost]
        public ActionResult<MoodStatement> CreateMoodStatement(MoodStatement moodStatement)
        {
            var createdMood = _moodService.CreateMoodStatement(moodStatement);
            return CreatedAtAction(nameof(GetMoodStatementById), new { id = createdMood.Id }, createdMood);
        }
        
        /// Actualiza un registro de estado de ánimo existente.
        
        [HttpPut("{id}")]
        public ActionResult<MoodStatement> UpdateMoodStatement(int id, MoodStatement updatedMoodStatement)
        {
            var moodStatement = _moodService.UpdateMoodStatement(id, updatedMoodStatement);
            if (moodStatement == null)
            {
                return NotFound();
            }
            return moodStatement;
        }

        /// <summary>
        /// Elimina un registro de estado de ánimo por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteMoodStatement(int id)
        {
            var success = _moodService.DeleteMoodStatement(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
