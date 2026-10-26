using SportHub.API.Entities;

namespace SportHub.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> EmailExistsAsync(string email);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<Role?> GetRoleByNameAsync(string name);
        void Add(User user);
        Task SaveChangesAsync();
    }
}
