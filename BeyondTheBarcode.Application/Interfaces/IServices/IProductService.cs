using BeyondTheBarcode.Application.DTOs.ProductDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDto?> GetByIdAsync(int id);

        Task<ProductDto?> GetByCodeAsync(string code);

        Task<IEnumerable<ProductDto>> GetByBrandAsync(string brand);

        Task<IEnumerable<ProductDto>> GetByCategoryAsync(string category);

        Task<IEnumerable<ProductDto>> SearchAsync(string keyword);

        Task<IEnumerable<ProductDto>> GetActiveAsync();

        Task<IEnumerable<ProductDto>> GetInactiveAsync();

        Task<IEnumerable<ProductDto>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);

        Task<IEnumerable<ProductDto>> GetExportProductsAsync();

        Task<IEnumerable<ProductDto>> GetHealthWarningProductsAsync();

        Task<IEnumerable<ProductDto>> GetDiscontinuedProductsAsync();

        Task<bool> IsProductCodeExistsAsync(string productCode);

        Task CreateAsync(CreateProductDto dto);

        Task UpdateAsync(UpdateProductDto dto);

        Task DeleteAsync(int id);
    }
}   