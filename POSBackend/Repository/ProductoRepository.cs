using Microsoft.EntityFrameworkCore;
using POSBackend.Data;
using POSShared.Entities;

namespace POSBackend.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly PostDBContext _context;
        public ProductoRepository(PostDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product producto)
        {
            await _context.Products.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            if (producto != null)
            {
                _context.Products.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoriaAsync(string categoria)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category != null && p.Category.Name == categoria)
                .ToListAsync();

        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> GetStockAsync(int productoId)
        {
            var producto = await _context.Products.FindAsync(productoId);
            return producto?.CurrentStock ?? 0;
            throw new NotImplementedException();
        }

        public async Task InsertarProductosAsync(IEnumerable<Product> productos)
        {
            await _context.Products.AddRangeAsync(productos);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product producto)
        {
            _context.Products.Update(producto);
            await _context.SaveChangesAsync();
        }
    }
}
