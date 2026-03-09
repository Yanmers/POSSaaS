using POSShared.DTOs;
using POSShared.Entities;

namespace POSBackend.Repository
{
    public interface ICategoryRepository
    {
        Task<CategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> CreateAsync(CategoryDto category);
        Task<CategoryDto> UpdateAsync(CategoryDto category);
        Task<bool> SaveChangesAsync();
        Task<bool> DeleteAsync(int id);
    }
}
