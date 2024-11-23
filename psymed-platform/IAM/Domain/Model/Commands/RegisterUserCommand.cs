namespace psymed_platform.IAM.Domain.Model.Commands
{
    public class RegisterUserCommand
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}