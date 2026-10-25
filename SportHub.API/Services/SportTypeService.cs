using SportHub.API.DTOs.SportTypes;
using SportHub.API.Entities;
using SportHub.API.Exceptions;
using SportHub.API.Repositories.Interfaces;
using SportHub.API.Services.Interfaces;

namespace SportHub.API.Services
{
    public class SportTypeService : ISportTypeService
    {
        private readonly ISportTypeRepository _repository;

        public SportTypeService(ISportTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<SportTypeDto> CreateAsync(SportTypeRequest request)
        {
            var name = request.Name.Trim();

            if (await _repository.ExistsByNameAsync(name))
                throw new ConflictException($"Môn thể thao '{name}' đã tồn tại");
            var sportType = new SportType { Name = name };
            _repository.Add(sportType);
            await _repository.SaveChangesAsync();
            return Dto(sportType);
        }

        public async Task DeleteAsync(int id)
        {
            var sportType = await GetExistingAsync(id);
            if(await _repository.HasCourtsAsync(id))
            {
                throw new ConflictException("Không thể xóa môn thể thao đang có sân sử dụng");
            }
            _repository.Remove(sportType);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<SportTypeDto>> GetAllAsync()
        {
            var sportTypes = await _repository.GetAllAsync();
            return sportTypes.Select(Dto).ToList();
        }

        public async Task<SportTypeDto> GetByIdAsync(int id)
        {
            var sportType = await GetExistingAsync(id);
            return Dto(sportType);
        }

        public async Task<SportTypeDto> UpdateAsync(int id, SportTypeRequest request)
        {
            var sportType = await GetExistingAsync(id);
            var name = request.Name;
            if(await _repository.ExistsByNameAsync(name, excludeId: id))
            {
                throw new ConflictException($"Môn thể thao '{name}' đã tồn tại");
            }
            sportType.Name = name;
            await _repository.SaveChangesAsync();

            return Dto(sportType);
        }

        private static SportTypeDto Dto(SportType sportTypes) => new(sportTypes.Id, sportTypes.Name);

        private async Task<SportType> GetExistingAsync(int id)
        {
            return await _repository.GetByIdAsync(id) ?? throw new NotFoundException($"Không tìm thấy môn thể thao có Id = {id}");
        }
    }
}
