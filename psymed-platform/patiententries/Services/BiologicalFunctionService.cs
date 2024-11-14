using System;
using System.Collections.Generic;
using System.Linq;
using psymed_platform.Data;
using psymed_platform.Models;
using Microsoft.EntityFrameworkCore;

namespace psymed_platform.Services
{
    /// <summary>
    /// Servicio para manejar operaciones CRUD relacionadas con las funciones biológicas de los pacientes.
    /// Permite crear, obtener, actualizar y eliminar registros de funciones biológicas.
    /// </summary>
    public class BiologicalFunctionService
    {
        private readonly ApplicationDbContextEntrys _context;

        /// <summary>
        /// Constructor que inyecta el contexto de base de datos.
        /// </summary>
        /// <param name="context">El contexto de base de datos de la aplicación</param>
        public BiologicalFunctionService(ApplicationDbContextEntrys context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las funciones biológicas de un paciente específico.
        /// </summary>
        /// <param name="patientId">ID del paciente.</param>
        /// <returns>Lista de funciones biológicas del paciente.</returns>
        public List<BiologicalFunction> GetBiologicalFunctionsByPatient(int patientId)
        {
            return _context.BiologicalFunctions
                           .Where(b => b.PatientId == patientId)
                           .OrderByDescending(b => b.DateRecorded)
                           .ToList();
        }

        /// <summary>
        /// Obtiene una función biológica por su ID.
        /// </summary>
        /// <param name="id">ID de la función biológica.</param>
        /// <returns>Función biológica o null si no se encuentra.</returns>
        public BiologicalFunction GetBiologicalFunctionById(int id)
        {
            return _context.BiologicalFunctions.FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// Crea un nuevo registro de función biológica para un paciente.
        /// </summary>
        /// <param name="biologicalFunction">La función biológica a crear.</param>
        /// <returns>La función biológica creada.</returns>
        public BiologicalFunction CreateBiologicalFunction(BiologicalFunction biologicalFunction)
        {
            biologicalFunction.DateRecorded = DateTime.Now;
            _context.BiologicalFunctions.Add(biologicalFunction);
            _context.SaveChanges();
            return biologicalFunction;
        }

        /// <summary>
        /// Actualiza un registro de función biológica existente.
        /// </summary>
        /// <param name="id">ID de la función biológica a actualizar.</param>
        /// <param name="updatedBiologicalFunction">Función biológica actualizada.</param>
        /// <returns>La función biológica actualizada o null si no se encuentra.</returns>
        public BiologicalFunction UpdateBiologicalFunction(int id, BiologicalFunction updatedBiologicalFunction)
        {
            var biologicalFunction = _context.BiologicalFunctions.FirstOrDefault(b => b.Id == id);
            if (biologicalFunction == null) return null;

            // Actualiza los datos de la función biológica
            biologicalFunction.FunctionType = updatedBiologicalFunction.FunctionType;
            biologicalFunction.Value = updatedBiologicalFunction.Value;

            _context.SaveChanges();
            return biologicalFunction;
        }

        /// <summary>
        /// Elimina un registro de función biológica por su ID.
        /// </summary>
        /// <param name="id">ID de la función biológica a eliminar.</param>
        /// <returns>True si el registro fue eliminado, false si no se encontró.</returns>
        public bool DeleteBiologicalFunction(int id)
        {
            var biologicalFunction = _context.BiologicalFunctions.FirstOrDefault(b => b.Id == id);
            if (biologicalFunction == null) return false;

            // Elimina la función biológica de la base de datos
            _context.BiologicalFunctions.Remove(biologicalFunction);
            _context.SaveChanges();
            return true;
        }
    }
}
