using Microsoft.EntityFrameworkCore;
using POSBackend.Data;
using POSShared.Entities;

namespace POSBackend.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly PostDBContext _context;

        public SaleRepository(PostDBContext context)
        {
            _context = context;
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _context.Sales
                .Include(s => s.SaleDetails)
                .ThenInclude(d => d.Product)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.Sales
                .Include(s => s.SaleDetails)
                .ToListAsync();
        }

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
