using System;
using System.Collections.Generic;
using System.Linq;
using psymed_platform.Data;
using psymed_platform.Models;
using Microsoft.EntityFrameworkCore;

namespace psymed_platform.Services
{
    /// <summary>
    /// Servicio para manejar operaciones CRUD relacionadas con los medicamentos de los pacientes.
    /// Permite crear, obtener, actualizar y eliminar registros de medicamentos.
    /// </summary>
    public class MedicationService
    {
        private readonly ApplicationDbContextEntrys _context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">El contexto de base de datos de la aplicación</param>
        public MedicationService(ApplicationDbContextEntrys context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los medicamentos de un paciente específico.
        /// </summary>
        /// <param name="patientId">ID del paciente.</param>
        /// <returns>Lista de medicamentos del paciente.</returns>
        public List<Medication> GetMedicationsByPatient(int patientId)
        {
            return _context.Medications
                           .Where(m => m.PatientId == patientId)
                           .OrderByDescending(m => m.DatePrescribed)
                           .ToList();
        }

        /// <summary>
        /// Obtiene un medicamento por su ID.
        /// </summary>
        /// <param name="id">ID del medicamento.</param>
        /// <returns>Medicamento o null si no se encuentra.</returns>
        public Medication GetMedicationById(int id)
        {
            return _context.Medications.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Crea un nuevo medicamento para un paciente.
        /// </summary>
        /// <param name="medication">El medicamento a crear.</param>
        /// <returns>El medicamento creado.</returns>
        public Medication CreateMedication(Medication medication)
        {
            medication.DatePrescribed = DateTime.Now;
            _context.Medications.Add(medication);
            _context.SaveChanges();
            return medication;
        }

        /// <summary>
        /// Actualiza un medicamento existente.
        /// </summary>
        /// <param name="id">ID del medicamento a actualizar.</param>
        /// <param name="updatedMedication">Medicamento actualizado.</param>
        /// <returns>El medicamento actualizado o null si no se encuentra.</returns>
        public Medication UpdateMedication(int id, Medication updatedMedication)
        {
            var medication = _context.Medications.FirstOrDefault(m => m.Id == id);
            if (medication == null) return null;

            // Actualiza los datos del medicamento
            medication.Name = updatedMedication.Name;
            medication.Dosage = updatedMedication.Dosage;
            medication.Frequency = updatedMedication.Frequency;

            _context.SaveChanges();
            return medication;
        }

        /// <summary>
        /// Elimina un medicamento por su ID.
        /// </summary>
        /// <param name="id">ID del medicamento a eliminar.</param>
        /// <returns>True si el medicamento fue eliminado, false si no se encontró.</returns>
        public bool DeleteMedication(int id)
        {
            var medication = _context.Medications.FirstOrDefault(m => m.Id == id);
            if (medication == null) return false;

            // Elimina el medicamento de la base de datos
            _context.Medications.Remove(medication);
            _context.SaveChanges();
            return true;
        }
    }
}
