using POSBackend.Repository;
using POSShared.Entities;

namespace POSBackend.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task ActualizarProductoAsync(Product producto)
        {
            // Validación: no permitir stock negativo
            if (producto.CurrentStock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");

            await _productoRepository.UpdateAsync(producto);

        }

        public async Task<bool> ActualizarStockAsync(int productoId, int cantidadVendida)
        {

            var producto = await _productoRepository.GetByIdAsync(productoId);

            if (producto == null)
                return false;

            if (cantidadVendida <= 0)
                throw new ArgumentException("La cantidad vendida debe ser mayor que cero.");

            if (producto.CurrentStock < cantidadVendida)
                throw new InvalidOperationException("Stock insuficiente para la venta.");

            producto.CurrentStock -= cantidadVendida;
            await _productoRepository.UpdateAsync(producto);

            return true;
        }

        public async Task CrearProductoAsync(Product producto)
        {
            // Validación de negocio: precio y stock deben ser positivos

            if (producto.Price <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            if (producto.CurrentStock < 0)
                throw new ArgumentException("El stock no puede ser negativo.");

            await _productoRepository.AddAsync(producto);
        }

        public async Task EliminarProductoAsync(int id)
        {
            await _productoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> ObtenerPorCategoriaAsync(string categoria)
        {
            return await _productoRepository.GetByCategoriaAsync(categoria);
        }

        public async Task<Product> ObtenerProductoPorIdAsync(int id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> ObtenerProductosAsync()
        {
            return await _productoRepository.GetAllAsync();
        }

        public async Task<int> ObtenerStockAsync(int productoId)
        {
            return await _productoRepository.GetStockAsync(productoId);
        }
    }
}
