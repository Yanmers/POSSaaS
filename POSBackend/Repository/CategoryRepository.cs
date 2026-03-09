using Microsoft.EntityFrameworkCore;
using POSBackend.Data;
using POSShared.Entities;

namespace POSBackend.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PostDBContext _context;
        public CategoryRepository(PostDBContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await SaveChengesAsync();
            return category;
        }

        public async Task<bool> DeleAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            return await SaveChengesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<bool> SaveChengesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await SaveChengesAsync();
            return category;
        }


    }
}
