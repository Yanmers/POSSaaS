using POSShared.DTOs;

namespace POSBackend.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CreateCategory request);
        Task<CategoryDto> UpdateAsync(int id, EditCategory request);
        Task<bool> DeleteAsync(int id);
    }
}
