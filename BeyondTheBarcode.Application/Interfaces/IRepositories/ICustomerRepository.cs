using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        // Get Customer by Customer Code
        Task<Customer?> GetByCodeAsync(string code);

        // Get Customers by Type
        Task<IEnumerable<Customer>> GetByTypeAsync(string type);

        // Search by Code, Name, GST, PAN, Phone and Contact Person
        Task<IEnumerable<Customer>> SearchAsync(string keyword);

        // Get Active Customers
        Task<IEnumerable<Customer>> GetActiveAsync();

        // Get Inactive Customers
        Task<IEnumerable<Customer>> GetInactiveAsync();

        // Get Customers by Distribution Zone
        Task<IEnumerable<Customer>> GetByZoneAsync(string zone);

        // Get Customers by Region
        Task<IEnumerable<Customer>> GetByRegionAsync(string region);

        // Get Customers by Sales Representative
        Task<IEnumerable<Customer>> GetBySalesRepAsync(int salesRepId);

        // Check duplicate Customer Code
        Task<bool> IsCustomerCodeExistsAsync(string customerCode);
    }
}