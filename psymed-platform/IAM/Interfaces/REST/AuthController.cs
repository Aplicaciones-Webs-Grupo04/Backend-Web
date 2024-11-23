using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using psymed_platform.IAM.Appilcation.Internal.CommandServices;
using psymed_platform.IAM.Domain.Model.Commands;
using psymed_platform.IAM.Interfaces.REST.Resources;

namespace psymed_platform.IAM.Interfaces.REST
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthCommandService _authCommandService;

        public AuthController(AuthCommandService authCommandService)
        {
            _authCommandService = authCommandService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseResource>> Login(LoginResource resource)
        {
            var command = new LoginCommand
            {
                Username = resource.Username,
                Password = resource.Password
            };

            var (success, token) = await _authCommandService.LoginAsync(command);

            return Ok(new AuthResponseResource
            {
                Success = success,
                Token = token,
                Error = success ? null : "Invalid username or password"
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseResource>> Register(RegisterResource resource)
        {
            var command = new RegisterUserCommand
            {
                Username = resource.Username,
                Email = resource.Email,
                Password = resource.Password
            };

            var (success, error) = await _authCommandService.RegisterAsync(command);

            return Ok(new AuthResponseResource
            {
                Success = success,
                Error = error
            });
        }
    }
}