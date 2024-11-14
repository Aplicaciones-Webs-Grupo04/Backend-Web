using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using psymed_platform.Models;
using psymed_platform.Services;

namespace psymed_platform.Controllers
{
    /// <summary>
    /// Controlador para manejar las solicitudes HTTP relacionadas con los diagnósticos del paciente.
    /// Proporciona operaciones CRUD para los diagnósticos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly DiagnosisService _diagnosisService;

        /// <summary>
        /// Constructor que inyecta el servicio de diagnóstico.
        /// </summary>
        public DiagnosisController(DiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
        }

        /// <summary>
        /// Obtiene todos los diagnósticos de un paciente.
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public ActionResult<List<Diagnosis>> GetDiagnosesByPatient(int patientId)
        {
            return _diagnosisService.GetDiagnosesByPatient(patientId);
        }

        /// <summary>
        /// Obtiene un diagnóstico por su ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Diagnosis> GetDiagnosisById(int id)
        {
            var diagnosis = _diagnosisService.GetDiagnosisById(id);
            if (diagnosis == null)
            {
                return NotFound();
            }
            return diagnosis;
        }

        /// <summary>
        /// Crea un nuevo diagnóstico para un paciente.
        /// </summary>
        [HttpPost]
        public ActionResult<Diagnosis> CreateDiagnosis(Diagnosis diagnosis)
        {
            var createdDiagnosis = _diagnosisService.CreateDiagnosis(diagnosis);
            return CreatedAtAction(nameof(GetDiagnosisById), new { id = createdDiagnosis.Id }, createdDiagnosis);
        }

        /// <summary>
        /// Actualiza un diagnóstico existente.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<Diagnosis> UpdateDiagnosis(int id, Diagnosis updatedDiagnosis)
        {
            var diagnosis = _diagnosisService.UpdateDiagnosis(id, updatedDiagnosis);
            if (diagnosis == null)
            {
                return NotFound();
            }
            return diagnosis;
        }

        /// <summary>
        /// Elimina un diagnóstico por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteDiagnosis(int id)
        {
            var success = _diagnosisService.DeleteDiagnosis(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
