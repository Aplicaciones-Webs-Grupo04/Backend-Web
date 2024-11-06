using psymed_platform.Medication.Domain.Model.ValueObjects;
using psymed_platform.Medication.Domain.ValueObjects;

namespace psymed_platform.Medication.Domain.Model.Aggregates;

public class Medication {
    
    public int Id { get; }
    
    public MedicationName Name { get; private set; }
    
    public LifeCycleMedication LifeCycleMedication { get; private set; }
    
    public Prescription Prescription { get; private set; }
    
    public string MedicalPrescription => Prescription.MedicalPrescription;

    public Medication()
    {
        Name = new MedicationName();
        LifeCycleMedication = new LifeCycleMedication();
        Prescription = new Prescription();
    }

    public Medication(string name, string frequency, string quantity, string startedDate, string endedDate)
    {
        Name = new MedicationName(name);
        LifeCycleMedication = new LifeCycleMedication(startedDate, endedDate);
        Prescription = new Prescription(quantity, startedDate);
    }
    
    
    
}