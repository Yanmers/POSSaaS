using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POSBackend.Data;
using POSShared.DTOs;
using POSShared.Entities;

namespace POSBackend.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PostDBContext _categoryContext;
        public CategoryRepository(PostDBContext categoryContext)
        {
            _categoryContext = categoryContext;
        }
        public async Task<CategoryDto> CreateAsync(CategoryDto category)
        {
            _categoryContext.Categories.Add(category);
            await SaveChangesAsync();
            return category;
        }


        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryContext.Categories.Where(n => n.Id == id).FirstOrDefaultAsync();
            return category!;
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto category)
        {
            _categoryContext.Categories.Update(category);
            await SaveChangesAsync();
            return category;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _categoryContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryContext.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _categoryContext.Categories.Remove(category);
            return await SaveChangesAsync();
        }


    }
}
