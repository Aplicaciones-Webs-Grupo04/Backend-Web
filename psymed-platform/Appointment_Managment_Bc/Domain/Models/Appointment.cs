namespace psymed_platform.Appointment_managment.Domain.Models;

public class Appointment {
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Patient { get; set; }
    public string Asunto { get; set; }

    public Appointment(int id, DateTime appointmentDate, string patient, string asunto) {
        Id = id;
        AppointmentDate = appointmentDate;
        Patient = patient;
        Asunto = "therapy";
    }
}