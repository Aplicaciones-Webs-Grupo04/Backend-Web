using System.ComponentModel.DataAnnotations;

namespace psymed_platform.Models;

public class Treatment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PatientId { get; set; }

    [Required]
    public int PsychiatristId { get; set; }

    [Required]
    [StringLength(500)]
    public string Diagnosis { get; set; }

    public List<Medication> Medications { get; set; }

    public List<TherapySession> TherapySessions { get; set; }

    [Required]
    public string Status { get; set; } = "active";

    public DateTime StartDate { get; set; } = DateTime.Now;

    public DateTime? EndDate { get; set; }
}

public class Medication
{
    public string Name { get; set; }
    public string Dosage { get; set; }
    public string Frequency { get; set; }
}

public class TherapySession
{
    public DateTime Date { get; set; }
    public string Notes { get; set; }
}