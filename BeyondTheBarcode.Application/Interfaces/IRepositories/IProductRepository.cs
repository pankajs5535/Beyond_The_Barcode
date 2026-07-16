using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Get Product by Product Code
        Task<Product?> GetByCodeAsync(string code);

        // Get Products by Brand
        Task<IEnumerable<Product>> GetByBrandAsync(string brand);

        // Get Products by Category
        Task<IEnumerable<Product>> GetByCategoryAsync(string category);

        // Enterprise Search
        // Search by Code, Name, Brand, Category, HSN, Country
        Task<IEnumerable<Product>> SearchAsync(string keyword);

        // Get Active Products
        Task<IEnumerable<Product>> GetActiveAsync();

        // Get Inactive Products
        Task<IEnumerable<Product>> GetInactiveAsync();

        // Get Products created between two dates
        Task<IEnumerable<Product>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);

        // Check duplicate Product Code
        Task<bool> IsProductCodeExistsAsync(string productCode);

        // Get Export Products
        Task<IEnumerable<Product>> GetExportProductsAsync();

        // Get Products requiring Health Warning
        Task<IEnumerable<Product>> GetHealthWarningProductsAsync();

        // Get Discontinued Products
        Task<IEnumerable<Product>> GetDiscontinuedProductsAsync();
    }
}