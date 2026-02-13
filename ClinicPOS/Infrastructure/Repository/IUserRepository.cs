using ClinicPOS.Domain.Entity;

namespace ClinicPOS.Infrastructure.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByIdAsync(Guid id);
        Task<bool> UsernameExistsAsync(string username);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<Role?> GetRoleById(Guid roleId);
    }
}
