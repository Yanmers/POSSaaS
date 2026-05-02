using POSShared.Entities;

namespace POSBackend.Repository
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(int id);
        Task<IEnumerable<Sale>> GetAllAsync();
        Task AddAsync(Sale sale);
        Task SaveChangesAsync();
    }
}
