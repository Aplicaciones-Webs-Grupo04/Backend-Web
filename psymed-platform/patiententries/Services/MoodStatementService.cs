using System;
using System.Collections.Generic;
using System.Linq;

using psymed_platform.Data;
using psymed_platform.Models;

using Microsoft.EntityFrameworkCore;

namespace psymed_platform.Services
{
    /// <summary>
    /// Servicio para manejar operaciones CRUD relacionadas con el estado de ánimo del paciente.
    /// Permite crear, obtener, actualizar y eliminar registros de estado de ánimo.
    /// </summary>
    public class MoodStatementService
    {
        private readonly ApplicationDbContextEntrys _context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">El contexto de base de datos de la aplicación</param>
        public MoodStatementService(ApplicationDbContextEntrys context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los registros de estado de ánimo de un paciente específico.
        /// </summary>
        /// <param name="patientId">ID del paciente.</param>
        /// <returns>Lista de registros de estado de ánimo del paciente.</returns>
        public List<MoodStatement> GetMoodStatementsByPatient(int patientId)
        {
            return _context.MoodStatements
                           .Where(m => m.PatientId == patientId)
                           .OrderByDescending(m => m.DateRecorded)
                           .ToList();
        }

        /// <summary>
        /// Obtiene un registro de estado de ánimo por su ID.
        /// </summary>
        /// <param name="id">ID del registro de estado de ánimo.</param>
        /// <returns>Registro de estado de ánimo o null si no se encuentra.</returns>
        public MoodStatement GetMoodStatementById(int id)
        {
            return _context.MoodStatements.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Crea un nuevo registro de estado de ánimo.
        /// </summary>
        /// <param name="moodStatement">El registro de estado de ánimo a crear.</param>
        /// <returns>El registro de estado de ánimo creado.</returns>
        public MoodStatement CreateMoodStatement(MoodStatement moodStatement)
        {
            moodStatement.DateRecorded = DateTime.Now;
            _context.MoodStatements.Add(moodStatement);
            _context.SaveChanges();
            return moodStatement;
        }

        /// <summary>
        /// Actualiza un registro de estado de ánimo existente.
        /// </summary>
        /// <param name="id">ID del registro de estado de ánimo a actualizar.</param>
        /// <param name="updatedMoodStatement">Registro actualizado de estado de ánimo.</param>
        /// <returns>El registro de estado de ánimo actualizado o null si no se encuentra.</returns>
        public MoodStatement UpdateMoodStatement(int id, MoodStatement updatedMoodStatement)
        {
            var moodStatement = _context.MoodStatements.FirstOrDefault(m => m.Id == id);
            if (moodStatement == null) return null;

            // Actualiza los datos del registro de estado de ánimo
            moodStatement.MoodLevel = updatedMoodStatement.MoodLevel;
            moodStatement.Notes = updatedMoodStatement.Notes;

            _context.SaveChanges();
            return moodStatement;
        }

        /// <summary>
        /// Elimina un registro de estado de ánimo por su ID.
        /// </summary>
        /// <param name="id">ID del registro de estado de ánimo a eliminar.</param>
        /// <returns>True si el registro fue eliminado, false si no se encontró.</returns>
        public bool DeleteMoodStatement(int id)
        {
            var moodStatement = _context.MoodStatements.FirstOrDefault(m => m.Id == id);
            if (moodStatement == null) return false;

            // Elimina el registro de estado de ánimo de la base de datos
            _context.MoodStatements.Remove(moodStatement);
            _context.SaveChanges();
            return true;
        }
    }
}
        