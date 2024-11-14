using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using psymed_platform.Models;
using psymed_platform.Services;

namespace psymed_platform.Controllers
{
    /// <summary>
    /// Controlador para manejar las solicitudes HTTP relacionadas con el perfil del paciente.
    /// Permite realizar operaciones CRUD sobre el perfil de paciente.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PatientProfileController : ControllerBase
    {
        private readonly PatientProfileService _patientService;
        
        public PatientProfileController(PatientProfileService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Obtiene todos los perfiles de pacientes.
        /// </summary>
        [HttpGet]
        public ActionResult<List<PatientProfile>> GetAll()
        {
            return _patientService.GetAllPatients();
        }

        /// <summary>
        /// Obtiene un perfil de paciente por su ID.
        ///
        /// Cambiar la obtencion en base a la implementacion que se ponga a la hora del merge ///
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<PatientProfile> Get(int id)
        {
            var patientProfile = _patientService.GetPatientById(id);
            if (patientProfile == null)
            {
                return NotFound();
            }
            return patientProfile;
        }

        /// <summary>
        /// Crea un nuevo perfil de paciente.
        /// </summary>
        [HttpPost]
        public ActionResult<PatientProfile> Create(PatientProfile patientProfile)
        {
            var createdPatient = _patientService.CreatePatient(patientProfile);
            return CreatedAtAction(nameof(Get), new { id = createdPatient.Id }, createdPatient);
        }

        /// <summary>
        /// Actualiza un perfil de paciente existente.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<PatientProfile> Update(int id, PatientProfile updatedPatientProfile)
        {
            var patientProfile = _patientService.UpdatePatient(id, updatedPatientProfile);
            if (patientProfile == null)
            {
                return NotFound();
            }
            return patientProfile;
        }

        /// <summary>
        /// Elimina un perfil de paciente por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _patientService.DeletePatient(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
