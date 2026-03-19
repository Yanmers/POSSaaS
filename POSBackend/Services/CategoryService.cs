using Microsoft.EntityFrameworkCore.Storage;
using POSBackend.Repository;
using POSShared.DTOs;
using POSShared.Entities;

namespace POSBackend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategory request)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            var addedCategory = await _categoryRepository.CreateAsync(category);
            return new CategoryDto
            {
                Id = addedCategory.Id,
                Name = addedCategory.Name,
                Description = addedCategory.Description
            };
        }



        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var category = await _categoryRepository.GetAllAsync();
            return category.Select(d => new CategoryDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            });
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null!;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description

            };
        }

        public async Task<CategoryDto> UpdateAsync(int id, EditCategory request)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return null!;

            category.Name = request.Name;
            category.Description = request.Description;
            category.IsActive = request.IsActive;

            var updateCategory = await _categoryRepository.UpdateAsync(category);
            return new CategoryDto
            {
                Id = updateCategory.Id,
                Name = updateCategory.Name,
                Description = updateCategory.Description,
                IsActive = updateCategory.IsActive
            };
        }
    }
}
