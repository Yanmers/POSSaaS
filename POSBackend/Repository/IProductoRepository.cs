using POSShared.Entities;

namespace POSBackend.Repository
{
    public interface IProductoRepository
    {
        // Obtener todos los productos
        Task<IEnumerable<Product>> GetAllAsync();

        // Obtener producto por Id
        Task<Product> GetByIdAsync(int id);

        // Agregar un nuevo producto
        Task AddAsync(Product producto);

        // Actualizar producto existente
        Task UpdateAsync(Product producto);

        // Eliminar producto por Id
        Task DeleteAsync(int id);

        // Consultas adicionales (ejemplo: buscar por categoría)
        Task<IEnumerable<Product>> GetByCategoriaAsync(string categoria);

        // Verificar stock disponible
        Task<int> GetStockAsync(int productoId);
    }
}
