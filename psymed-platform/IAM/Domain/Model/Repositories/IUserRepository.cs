using System.Collections.Generic;
using System.Threading.Tasks;
using psymed_platform.IAM.Domain.Model.Aggregates;

namespace psymed_platform.IAM.Domain.Model.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(string id);
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(string id);
    }
}