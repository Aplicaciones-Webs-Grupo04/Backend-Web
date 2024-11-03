using System;

namespace psymed_platform.Tasks.Domain.Model.Aggregates
{
    public class Task
    {
        public string Id { get; private set; }
        public int IdPatient { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Task(int idPatient, string title, string description, int status)
        {
            Id = Guid.NewGuid().ToString();
            IdPatient = idPatient;
            Title = title;
            Description = description;
            Status = status;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string title, string description, int status)
        {
            Title = title;
            Description = description;
            Status = status;
            UpdatedAt = DateTime.Now;
        }
    }
}