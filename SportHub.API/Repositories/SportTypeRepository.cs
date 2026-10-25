using Microsoft.EntityFrameworkCore;
using SportHub.API.Data;
using SportHub.API.Entities;
using SportHub.API.Repositories.Interfaces;

namespace SportHub.API.Repositories
{
    public class SportTypeRepository : ISportTypeRepository
    {
        private readonly AppDbContext _context;

        public SportTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(SportType sportType) => _context.SportTypes.Add(sportType);

        public Task<bool> ExistsByNameAsync(string name, int? excludeId = null)
        {
            return _context.SportTypes.AnyAsync(s => s.Name == name && (excludeId == null || s.Id != excludeId));
        }

        public Task<List<SportType>> GetAllAsync()
        {
            return _context.SportTypes.AsNoTracking().OrderBy(s => s.Name).ToListAsync();
        }

        public Task<SportType?> GetByIdAsync(int id)
        {
            return _context.SportTypes.FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<bool> HasCourtsAsync(int id)
        {
            return _context.Courts.AnyAsync(c => c.SportTypeId == id);
        }

        public void Remove(SportType sportType) => _context.SportTypes.Remove(sportType);

        public Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
