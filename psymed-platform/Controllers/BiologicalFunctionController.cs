using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using psymed_platform.Models;
using psymed_platform.Services;

namespace psymed_platform.Controllers
{
    /// <summary>
    /// Controlador para manejar las solicitudes HTTP relacionadas con las funciones biológicas del paciente.
    /// Proporciona operaciones CRUD para las funciones biológicas.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BiologicalFunctionController : ControllerBase
    {
        private readonly BiologicalFunctionService _biologicalFunctionService;

        /// <summary>
        /// Constructor que inyecta el servicio de función biológica.
        /// </summary>
        public BiologicalFunctionController(BiologicalFunctionService biologicalFunctionService)
        {
            _biologicalFunctionService = biologicalFunctionService;
        }

        /// <summary>
        /// Obtiene todas las funciones biológicas de un paciente.
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public ActionResult<List<BiologicalFunction>> GetBiologicalFunctionsByPatient(int patientId)
        {
            return _biologicalFunctionService.GetBiologicalFunctionsByPatient(patientId);
        }

        /// <summary>
        /// Obtiene una función biológica por su ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<BiologicalFunction> GetBiologicalFunctionById(int id)
        {
            var biologicalFunction = _biologicalFunctionService.GetBiologicalFunctionById(id);
            if (biologicalFunction == null)
            {
                return NotFound();
            }
            return biologicalFunction;
        }

        /// <summary>
        /// Crea un nuevo registro de función biológica para un paciente.
        /// </summary>
        [HttpPost]
        public ActionResult<BiologicalFunction> CreateBiologicalFunction(BiologicalFunction biologicalFunction)
        {
            var createdBiologicalFunction = _biologicalFunctionService.CreateBiologicalFunction(biologicalFunction);
            return CreatedAtAction(nameof(GetBiologicalFunctionById), new { id = createdBiologicalFunction.Id }, createdBiologicalFunction);
        }

        /// <summary>
        /// Actualiza un registro de función biológica existente.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<BiologicalFunction> UpdateBiologicalFunction(int id, BiologicalFunction updatedBiologicalFunction)
        {
            var biologicalFunction = _biologicalFunctionService.UpdateBiologicalFunction(id, updatedBiologicalFunction);
            if (biologicalFunction == null)
            {
                return NotFound();
            }
            return biologicalFunction;
        }

        /// <summary>
        /// Elimina un registro de función biológica por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteBiologicalFunction(int id)
        {
            var success = _biologicalFunctionService.DeleteBiologicalFunction(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
