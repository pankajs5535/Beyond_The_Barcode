using BeyondTheBarcode.Application.DTOs.SalesOrderDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface ISalesOrderService
    {
        // Get all Sales Orders
        Task<IEnumerable<SalesOrderDto>> GetAllAsync();

        // Get Sales Order by Id
        Task<SalesOrderDto?> GetByIdAsync(int id);

        // Get Sales Order by Order Number
        Task<SalesOrderDto?> GetByOrderNumberAsync(string orderNumber);

        // Get Sales Orders by Customer
        Task<IEnumerable<SalesOrderDto>> GetByCustomerAsync(int customerId);

        // Get Sales Orders by Product
        Task<IEnumerable<SalesOrderDto>> GetByProductAsync(int productId);

        // Search Sales Orders
        Task<IEnumerable<SalesOrderDto>> SearchAsync(string keyword);

        // Get Sales Orders by Status
        Task<IEnumerable<SalesOrderDto>> GetByStatusAsync(string status);

        // Get Sales Orders by Payment Status
        Task<IEnumerable<SalesOrderDto>> GetByPaymentStatusAsync(string paymentStatus);

        // Get Sales Orders by Date Range
        Task<IEnumerable<SalesOrderDto>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate);

        // Get Approved Sales Orders
        Task<IEnumerable<SalesOrderDto>> GetApprovedOrdersAsync();

        // Check Order Number Exists
        Task<bool> IsOrderNumberExistsAsync(string orderNumber);

        // Create Sales Order
        Task CreateAsync(CreateSalesOrderDto dto);

        // Update Sales Order
        Task UpdateAsync(UpdateSalesOrderDto dto);

        // Delete Sales Order
        Task DeleteAsync(int id);
    }
}