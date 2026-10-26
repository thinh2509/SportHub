using Microsoft.EntityFrameworkCore;
using SportHub.API.Data;
using SportHub.API.Entities;
using SportHub.API.Repositories.Interfaces;

namespace SportHub.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user) => _context.Add(user);

        public Task<bool> EmailExistsAsync(string email)
        {
            return _context.Users.AnyAsync(u => u.Email == email);
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User?> GetByIdAsync(int id)
        {
            return _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<Role?> GetRoleByNameAsync(string name)
        {
            return _context.Roles.FirstOrDefaultAsync(u => u.Name == name);
        }

        public Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
