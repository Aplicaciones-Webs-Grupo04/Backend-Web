namespace psymed_platform.Tasks.Domain.Model.Commands
{
    public class UpdateTaskCommand
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}