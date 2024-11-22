namespace psymed_platform.patiententries.Domain.Model.Entities;

public class Session
{
    public int Id { get; private set; }
    public DateTime AppointmentDate { get; private set; }
    public TimeSpan SessionTime { get; private set; }
    public int NoteId { get; private set; }
    public int PatientId { get; private set; }
    public int ProfessionalId { get; private set; }

    public Session(DateTime appointmentDate, TimeSpan sessionTime, int noteId, int patientId, int professionalId)
    {
        AppointmentDate = appointmentDate;
        SessionTime = sessionTime;
        NoteId = noteId;
        PatientId = patientId;
        ProfessionalId = professionalId;
    }
}