using System;

namespace psymed_platform.Tasks.Interfaces.REST.Resources
{
    public class TaskResource
    {
        public string Id { get; set; }
        public int IdPatient { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateTaskResource
    {
        public int IdPatient { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }

    public class UpdateTaskResource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}