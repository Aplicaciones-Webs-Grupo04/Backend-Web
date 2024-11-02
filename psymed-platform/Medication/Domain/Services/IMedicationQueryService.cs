﻿using psymed_platform.Medication.Domain.Model.Queries;
using psymed_platform.Medication.Domain.Model.Aggregates;
namespace psymed_platform.Medication.Domain.Services;


public interface IMedicationQueryService
{
    Task<IEnumerable<Model.Aggregates.Medication>> Handle(GetAllMedicationsQuery query);
    
    
}