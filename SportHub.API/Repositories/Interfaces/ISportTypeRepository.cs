using SportHub.API.Entities;

namespace SportHub.API.Repositories.Interfaces
{
    public interface ISportTypeRepository
    {
        Task<List<SportType>> GetAllAsync();
        Task<SportType?> GetByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name, int? excludeId = null);
        Task<bool> HasCourtsAsync(int id);
        void Add(SportType sportType);
        void Remove(SportType sportType);
        Task SaveChangesAsync();
    }
}
