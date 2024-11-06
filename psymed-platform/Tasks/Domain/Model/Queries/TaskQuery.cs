using System;

namespace psymed_platform.Tasks.Domain.Model.Queries
{
    public class TaskQuery
    {
        public string Id { get; set; }
        public int IdPatient { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}