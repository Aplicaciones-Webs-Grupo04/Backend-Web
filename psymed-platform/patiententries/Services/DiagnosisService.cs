using System;
using System.Collections.Generic;
using System.Linq;
using psymed_platform.Data;
using psymed_platform.Models;
using Microsoft.EntityFrameworkCore;

namespace psymed_platform.Services
{
    /// <summary>
    /// Servicio para manejar operaciones CRUD relacionadas con los diagnósticos de los pacientes.
    /// Permite crear, obtener, actualizar y eliminar diagnósticos.
    /// </summary>
    public class DiagnosisService
    {
        private readonly ApplicationDbContextEntrys _context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">El contexto de base de datos de la aplicación</param>
        public DiagnosisService(ApplicationDbContextEntrys context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los diagnósticos de un paciente específico.
        /// </summary>
        /// <param name="patientId">ID del paciente.</param>
        /// <returns>Lista de diagnósticos del paciente.</returns>
        public List<Diagnosis> GetDiagnosesByPatient(int patientId)
        {
            return _context.Diagnoses
                           .Where(d => d.PatientId == patientId)
                           .OrderByDescending(d => d.DateDiagnosed)
                           .ToList();
        }

        /// <summary>
        /// Obtiene un diagnóstico por su ID.
        /// </summary>
        /// <param name="id">ID del diagnóstico.</param>
        /// <returns>Diagnóstico o null si no se encuentra.</returns>
        public Diagnosis GetDiagnosisById(int id)
        {
            return _context.Diagnoses.FirstOrDefault(d => d.Id == id);
        }

        /// <summary>
        /// Crea un nuevo diagnóstico para un paciente.
        /// </summary>
        /// <param name="diagnosis">El diagnóstico a crear.</param>
        /// <returns>El diagnóstico creado.</returns>
        public Diagnosis CreateDiagnosis(Diagnosis diagnosis)
        {
            diagnosis.DateDiagnosed = DateTime.Now;
            _context.Diagnoses.Add(diagnosis);
            _context.SaveChanges();
            return diagnosis;
        }

        /// <summary>
        /// Actualiza un diagnóstico existente.
        /// </summary>
        /// <param name="id">ID del diagnóstico a actualizar.</param>
        /// <param name="updatedDiagnosis">Diagnóstico actualizado.</param>
        /// <returns>El diagnóstico actualizado o null si no se encuentra.</returns>
        public Diagnosis UpdateDiagnosis(int id, Diagnosis updatedDiagnosis)
        {
            var diagnosis = _context.Diagnoses.FirstOrDefault(d => d.Id == id);
            if (diagnosis == null) return null;

            // Actualiza los datos del diagnóstico
            diagnosis.DiagnosisName = updatedDiagnosis.DiagnosisName;
            diagnosis.Description = updatedDiagnosis.Description;

            _context.SaveChanges();
            return diagnosis;
        }

        /// <summary>
        /// Elimina un diagnóstico por su ID.
        /// </summary>
        /// <param name="id">ID del diagnóstico a eliminar.</param>
        /// <returns>True si el diagnóstico fue eliminado, false si no se encontró.</returns>
        public bool DeleteDiagnosis(int id)
        {
            var diagnosis = _context.Diagnoses.FirstOrDefault(d => d.Id == id);
            if (diagnosis == null) return false;

            // Elimina el diagnóstico de la base de datos
            _context.Diagnoses.Remove(diagnosis);
            _context.SaveChanges();
            return true;
        }
    }
}
