using POSFrontend.Models;
using POSFrontend.Providers;
using POSShared.DTOs;
using POSShared.Entities;

namespace POSFrontend.Services
{
    public interface ICategoriesService
    {
        Task<CategoryResponse?> ReadAsync(string name, string description);
        Task<CategoryResponse?> CreateAsync(CategoriesViewModel model);
    }
}
