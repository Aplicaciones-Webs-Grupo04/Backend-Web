namespace psymed_platform.IAM.Interfaces.REST.Resources
{
    public class LoginResource
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterResource
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponseResource
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}