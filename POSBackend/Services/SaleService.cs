using POSBackend.Repository;
using POSShared.DTOs;
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

            sale.Subtotal = sale.SaleDetails.Sum(d => d.UnitPrice * d.Quantity);
            sale.TaxAmount = sale.Subtotal * 0.16m;
            sale.TotalAmount = sale.Subtotal + sale.TaxAmount;
            sale.SaleDate = DateTime.UtcNow;

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


        public async Task<SaleResponseDto> CreateSaleAsync(SaleDto dto)
        {
            var sale = new Sale
            {
                CustomerName = dto.CustomerName,
                PaymentMethod = dto.PaymentMethod,
                UserId = dto.UserId,
                SaleDate = DateTime.UtcNow,
                SaleDetails = dto.SaleDetails.Select(d => new SaleDetail
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    TotalPrice = d.UnitPrice * d.Quantity
                }).ToList()
            };

            sale.Subtotal = sale.SaleDetails.Sum(d => d.TotalPrice);
            sale.TaxAmount = sale.Subtotal * 0.16m;
            sale.TotalAmount = sale.Subtotal + sale.TaxAmount;

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

            return MapToResponseDto(sale);
        }

        public async Task<SaleResponseDto?> GetSaleByIdAsync(int id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null) return null;
            return MapToResponseDto(sale);
        }

        public async Task<IEnumerable<SaleResponseDto>> GetAllSalesAsync()
        {
            var sales = await _saleRepository.GetAllAsync();
            return sales.Select(s => MapToResponseDto(s));
        }


        private SaleResponseDto MapToResponseDto(Sale sale)
        {
            return new SaleResponseDto
            {
                Id = sale.Id,
                CustomerName = sale.CustomerName,
                PaymentMethod = sale.PaymentMethod,
                Subtotal = sale.Subtotal,
                TaxAmount = sale.TaxAmount,
                TotalAmount = sale.TotalAmount,
                UserId = sale.UserId,
                SaleDate = sale.SaleDate,
                SaleDetails = sale.SaleDetails.Select(d => new SaleDetailResponseDto
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    TotalPrice = d.TotalPrice
                }).ToList()
            };
        }
    }
}

