using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Get Product by Product Code
        public async Task<Product?> GetByCodeAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.ProductCode == code);
        }

        // Get Products by Brand
        public async Task<IEnumerable<Product>> GetByBrandAsync(string brand)
        {
            return await _dbSet
                .Where(x => x.Brand == brand && x.IsActive)
                .ToListAsync();
        }

        // Get Products by Category
        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
        {
            return await _dbSet
                .Where(x => x.Category == category && x.IsActive)
                .ToListAsync();
        }

        // Search by Code, Name, Brand, Category, HSN, Country
        public async Task<IEnumerable<Product>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet
                .Where(x =>
                    x.ProductCode.ToLower().Contains(keyword) ||
                    x.ProductName.ToLower().Contains(keyword) ||
                    x.Brand.ToLower().Contains(keyword) ||
                    x.Category.ToLower().Contains(keyword) ||
                    (x.Hsncode ?? "").ToLower().Contains(keyword) ||
                    x.CountryOfOrigin.ToLower().Contains(keyword))
                .ToListAsync();
        }

        // Get Active Products
        public async Task<IEnumerable<Product>> GetActiveAsync()
        {
            return await _dbSet
                .Where(x => x.IsActive)
                .ToListAsync();
        }

        // Get Inactive Products
        public async Task<IEnumerable<Product>> GetInactiveAsync()
        {
            return await _dbSet
                .Where(x => !x.IsActive)
                .ToListAsync();
        }

        // Get Products created between two dates
        public async Task<IEnumerable<Product>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _dbSet
                .Where(x => x.CreatedAt >= fromDate && x.CreatedAt <= toDate)
                .ToListAsync();
        }

        // Check duplicate Product Code
        public async Task<bool> IsProductCodeExistsAsync(string productCode)
        {
            return await _dbSet
                .AnyAsync(x => x.ProductCode == productCode);
        }

        // Get Export Products
        public async Task<IEnumerable<Product>> GetExportProductsAsync()
        {
            return await _dbSet
                .Where(x => x.IsExportProduct)
                .ToListAsync();
        }

        // Get Products requiring Health Warning
        public async Task<IEnumerable<Product>> GetHealthWarningProductsAsync()
        {
            return await _dbSet
                .Where(x => x.HealthWarningRequired)
                .ToListAsync();
        }

        // Get Discontinued Products
        public async Task<IEnumerable<Product>> GetDiscontinuedProductsAsync()
        {
            return await _dbSet
                .Where(x => x.DiscontinuedDate != null)
                .ToListAsync();
        }
    }
}