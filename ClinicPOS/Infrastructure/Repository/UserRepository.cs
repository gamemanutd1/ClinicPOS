using ClinicPOS.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClinicPOS.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<User?> GetByUsernameAsync(string username) =>
            _context.User.FirstOrDefaultAsync(u => u.Username == username);

        public Task<User?> GetByIdAsync(Guid id) =>
            _context.User.FindAsync(id).AsTask();

        public Task<bool> UsernameExistsAsync(string username) =>
            _context.User.AnyAsync(u => u.Username == username);

        public async Task AddAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        public Task<List<User>> GetAllAsync() =>
            _context.User.Where(u => u.IsActive).OrderBy(u => u.Username).ToListAsync();

        public Task<Role?> GetRoleById(Guid roleId) =>
            _context.Role.FirstOrDefaultAsync(r => r.Id == roleId);
    }
}
