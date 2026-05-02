using POSShared.Entities;

namespace POSBackend.Services
{
    public interface IProductoService
    {
        // Obtener todos los productos
        Task<IEnumerable<Product>> ObtenerProductosAsync();

        // Obtener producto por Id
        Task<Product> ObtenerProductoPorIdAsync(int id);

        // Crear un nuevo producto con validaciones
        Task CrearProductoAsync(Product producto);

        // Actualizar producto existente
        Task ActualizarProductoAsync(Product producto);

        // Eliminar producto
        Task EliminarProductoAsync(int id);

        // Consultar productos por categoría
        Task<IEnumerable<Product>> ObtenerPorCategoriaAsync(string categoria);

        // Verificar stock disponible
        Task<int> ObtenerStockAsync(int productoId);

        // Actualizar stock después de una venta
        Task<bool> ActualizarStockAsync(int productoId, int cantidadVendida);
    }
}
