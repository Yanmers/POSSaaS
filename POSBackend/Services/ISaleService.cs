using POSShared.Entities;

namespace POSBackend.Services
{
    public interface ISaleService
    {
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<Sale> GetSaleByIdAsync(int id);
        Task<IEnumerable<Sale>> GetAllSalesAsync();
    }
}
