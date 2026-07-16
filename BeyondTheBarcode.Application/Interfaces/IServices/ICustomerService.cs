using BeyondTheBarcode.Application.DTOs.CustomerDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        // Get all Customers
        Task<IEnumerable<CustomerDto>> GetAllAsync();

        // Get Customer by Id
        Task<CustomerDto?> GetByIdAsync(int id);

        // Get Customer by Customer Code
        Task<CustomerDto?> GetByCodeAsync(string code);

        // Get Customers by Type
        Task<IEnumerable<CustomerDto>> GetByTypeAsync(string type);

        // Search Customers
        Task<IEnumerable<CustomerDto>> SearchAsync(string keyword);

        // Get Active Customers
        Task<IEnumerable<CustomerDto>> GetActiveAsync();

        // Get Inactive Customers
        Task<IEnumerable<CustomerDto>> GetInactiveAsync();

        // Get Customers by Distribution Zone
        Task<IEnumerable<CustomerDto>> GetByZoneAsync(string zone);

        // Get Customers by Region
        Task<IEnumerable<CustomerDto>> GetByRegionAsync(string region);

        // Get Customers by Sales Representative
        Task<IEnumerable<CustomerDto>> GetBySalesRepAsync(int salesRepId);

        // Check Customer Code Exists
        Task<bool> IsCustomerCodeExistsAsync(string customerCode);

        // Create Customer
        Task CreateAsync(CreateCustomerDto dto);

        // Update Customer
        Task UpdateAsync(UpdateCustomerDto dto);

        // Delete Customer
        Task DeleteAsync(int id);
    }
}