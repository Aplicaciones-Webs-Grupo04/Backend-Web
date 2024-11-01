using System.Collections.Generic;
using System.Linq;
using psymed_platform.Data;
using psymed_platform.Models;
using Microsoft.EntityFrameworkCore;

namespace psymed_platform.Services
{
    /// <summary>
    /// Servicio para manejar operaciones CRUD relacionadas con el perfil del paciente.
    /// Realiza la lógica de negocio para la creación, lectura, actualización y eliminación de perfiles de pacientes.
    /// </summary>
    public class PatientProfileService
    {
        private readonly ApplicationDbContextEntrys _context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">El contexto de base de datos de la aplicación</param>
        public PatientProfileService(ApplicationDbContextEntrys context)
        {
            _context = context;
        }
        
        public List<PatientProfile> GetAllPatients()
        {
            return _context.PatientProfiles.ToList();
        }

        /// <summary>
        /// Obtiene el perfil de un paciente por su ID.
        /// </summary>
        /// <param name="id">ID del paciente.</param>
        /// <returns>Perfil del paciente o null si no se encuentra.</returns>
        public PatientProfile GetPatientById(int id)
        {
            return _context.PatientProfiles.FirstOrDefault(p => p.Id == id);
        }
        
        public PatientProfile CreatePatient(PatientProfile patientProfile)
        {
            _context.PatientProfiles.Add(patientProfile);
            _context.SaveChanges();
            return patientProfile;
        }

        public PatientProfile UpdatePatient(int id, PatientProfile updatedPatientProfile)
        {
            var patientProfile = _context.PatientProfiles.FirstOrDefault(p => p.Id == id);
            if (patientProfile == null) return null;

            // Actualiza los datos del perfil del paciente
            patientProfile.FullName = updatedPatientProfile.FullName;
            patientProfile.DateOfBirth = updatedPatientProfile.DateOfBirth;
            patientProfile.ContactInfo = updatedPatientProfile.ContactInfo;
            patientProfile.AssignedDoctor = updatedPatientProfile.AssignedDoctor;

            _context.SaveChanges();
            return patientProfile;
        }

        /// <summary>
        /// Elimina un perfil de paciente por su ID.
        /// </summary>
        /// <param name="id">ID del paciente a eliminar.</param>
        /// <returns>True si el paciente fue eliminado, false si no se encontró.</returns>
        public bool DeletePatient(int id)
        {
            var patientProfile = _context.PatientProfiles.FirstOrDefault(p => p.Id == id);
            if (patientProfile == null) return false;

            // Elimina el perfil del paciente de la base de datos
            _context.PatientProfiles.Remove(patientProfile);
            _context.SaveChanges();
            return true;
        }
    }
}
