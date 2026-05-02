using POSShared.Entities;

namespace POSBackend.Repository
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product producto);
        Task UpdateAsync(Product producto);
        Task DeleteAsync(int id);
        Task<IEnumerable<Product>> GetByCategoriaAsync(string categoria);
        Task<int> GetStockAsync(int productoId);
        Task InsertarProductosAsync(IEnumerable<Product> productos);
    }
}
