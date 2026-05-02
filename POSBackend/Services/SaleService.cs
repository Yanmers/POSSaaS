using POSBackend.Repository;
using POSShared.Entities;

namespace POSBackend.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductoRepository _productRepository;

        public SaleService(ISaleRepository saleRepository, IProductoRepository productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            // Calcular subtotal, impuestos y total
            sale.Subtotal = sale.SaleDetails.Sum(d => d.UnitPrice * d.Quantity);
            sale.TaxAmount = sale.Subtotal * 0.16m; // IVA 16%
            sale.TotalAmount = sale.Subtotal + sale.TaxAmount;
            sale.SaleDate = DateTime.UtcNow;

            // Validar stock y actualizar productos
            foreach (var detail in sale.SaleDetails)
            {
                var product = await _productRepository.GetByIdAsync(detail.ProductId);
                if (product.CurrentStock < detail.Quantity)
                {
                    throw new Exception($"Stock insuficiente para el producto {product.Name}");
                }
                product.CurrentStock -= detail.Quantity;
            }

            await _saleRepository.AddAsync(sale);
            await _saleRepository.SaveChangesAsync();

            return sale;
        }

        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _saleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _saleRepository.GetAllAsync();
        }
    }
}
