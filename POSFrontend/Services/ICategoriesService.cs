using POSFrontend.Models;
using POSFrontend.Providers;
using POSShared.DTOs;
using POSShared.Entities;

namespace POSFrontend.Services
{
    public interface ICategoriesService
    {
        Task<CategoryResponse?> ReadAsync(CategoriesViewModel category);
        Task<CategoryResponse?> CreateAsync(string Name, string Description);
    }
}
