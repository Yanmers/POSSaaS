using POSShared.Entities;

namespace POSBackend.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Product>> ObtenerProductosAsync();
        Task<Product> ObtenerProductoPorIdAsync(int id);
        Task CrearProductoAsync(Product producto);
        Task ActualizarProductoAsync(Product producto);
        Task EliminarProductoAsync(int id);
        Task<IEnumerable<Product>> ObtenerPorCategoriaAsync(string categoria);
        Task<int> ObtenerStockAsync(int productoId);
        Task<bool> ActualizarStockAsync(int productoId, int cantidadVendida);
        Task InsertarProductosAsync(IEnumerable<Product> productos);
    }
}
