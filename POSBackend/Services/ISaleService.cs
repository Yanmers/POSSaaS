using POSShared.DTOs;
using POSShared.Entities;

namespace POSBackend.Services
{
    public interface ISaleService
    {
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<SaleResponseDto> CreateSaleAsync(SaleDto dto);
        Task<SaleResponseDto?> GetSaleByIdAsync(int id);
        Task<IEnumerable<SaleResponseDto>> GetAllSalesAsync();
    }
}
