using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using psymed_platform.IAM.Domain.Model.Commands;
using psymed_platform.IAM.Domain.Model.Repositories;
using BC = BCrypt.Net.BCrypt;

namespace psymed_platform.IAM.Application.Internal.CommandServices
{
    public class AuthCommandService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _jwtSecret;

        public AuthCommandService(IUserRepository userRepository, string jwtSecret)
        {
            _userRepository = userRepository;
            _jwtSecret = jwtSecret;
        }

        public async Task<(bool success, string token)> LoginAsync(LoginCommand command)
        {
            var user = await _userRepository.GetByUsernameAsync(command.Username);
            if (user == null) return (false, null);

            if (!BC.Verify(command.Password, user.PasswordHash))
                return (false, null);

            user.UpdateLastLogin();
            await _userRepository.UpdateAsync(user);

            var token = GenerateJwtToken(user);
            return (true, token);
        }

        public async Task<(bool success, string error)> RegisterAsync(RegisterUserCommand command)
        {
            if (await _userRepository.GetByUsernameAsync(command.Username) != null)
                return (false, "Username already exists");

            if (await _userRepository.GetByEmailAsync(command.Email) != null)
                return (false, "Email already exists");

            var passwordHash = BC.HashPassword(command.Password);
            var user = new Domain.Model.Aggregates.User(command.Username, command.Email, passwordHash);
            
            await _userRepository.AddAsync(user);
            return (true, null);
        }

        private string GenerateJwtToken(Domain.Model.Aggregates.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}