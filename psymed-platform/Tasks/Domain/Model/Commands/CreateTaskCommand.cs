namespace PsymedPlatform.Tasks.Domain.Model.Commands
{
    public class CreateTaskCommand
    {
        public int IdPatient { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}