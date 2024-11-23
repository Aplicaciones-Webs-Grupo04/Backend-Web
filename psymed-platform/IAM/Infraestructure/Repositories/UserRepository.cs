using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using psymed_platform.IAM.Domain.Model.Aggregates;
using psymed_platform.IAM.Domain.Model.Repositories;

namespace psymed_platform.IAM.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public async Task<User> GetByIdAsync(string id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return _users;
        }

        public async Task<User> AddAsync(User user)
        {
            _users.Add(user);
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var existingUser = await GetByIdAsync(user.Id);
            if (existingUser == null) return null;

            _users.Remove(existingUser);
            _users.Add(user);
            return user;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await GetByIdAsync(id);
            if (user == null) return false;

            return _users.Remove(user);
        }
    }
}