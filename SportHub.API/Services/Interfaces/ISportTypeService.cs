using SportHub.API.DTOs.SportTypes;

namespace SportHub.API.Services.Interfaces
{
    public interface ISportTypeService
    {
        Task<List<SportTypeDto>> GetAllAsync();
        Task<SportTypeDto> GetByIdAsync(int id);
        Task<SportTypeDto> CreateAsync(SportTypeRequest request);
        Task<SportTypeDto> UpdateAsync(int id, SportTypeRequest request);
        Task DeleteAsync(int id);
    }
}
