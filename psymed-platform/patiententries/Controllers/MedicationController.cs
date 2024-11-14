using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using psymed_platform.Models;
using psymed_platform.Services;

namespace psymed_platform.Controllers
{
    /// <summary>
    /// Controlador para manejar las solicitudes HTTP relacionadas con los medicamentos del paciente.
    /// Proporciona operaciones CRUD para los medicamentos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly MedicationService _medicationService;

        /// <summary>
        /// Constructor que inyecta el servicio de medicamentos.
        /// </summary>
        public MedicationController(MedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        /// <summary>
        /// Obtiene todos los medicamentos de un paciente.
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public ActionResult<List<Medication>> GetMedicationsByPatient(int patientId)
        {
            return _medicationService.GetMedicationsByPatient(patientId);
        }

        /// <summary>
        /// Obtiene un medicamento por su ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Medication> GetMedicationById(int id)
        {
            var medication = _medicationService.GetMedicationById(id);
            if (medication == null)
            {
                return NotFound();
            }
            return medication;
        }

        /// <summary>
        /// Crea un nuevo medicamento para un paciente.
        /// </summary>
        [HttpPost]
        public ActionResult<Medication> CreateMedication(Medication medication)
        {
            var createdMedication = _medicationService.CreateMedication(medication);
            return CreatedAtAction(nameof(GetMedicationById), new { id = createdMedication.Id }, createdMedication);
        }

        /// <summary>
        /// Actualiza un medicamento existente.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<Medication> UpdateMedication(int id, Medication updatedMedication)
        {
            var medication = _medicationService.UpdateMedication(id, updatedMedication);
            if (medication == null)
            {
                return NotFound();
            }
            return medication;
        }

        /// <summary>
        /// Elimina un medicamento por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteMedication(int id)
        {
            var success = _medicationService.DeleteMedication(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
