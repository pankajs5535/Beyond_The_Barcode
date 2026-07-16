using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface ISalesOrderRepository : IGenericRepository<SalesOrder>
    {
        // Get Sales Order by Order Number
        Task<SalesOrder?> GetByOrderNumberAsync(string orderNumber);

        // Get Sales Orders by Customer
        Task<IEnumerable<SalesOrder>> GetByCustomerAsync(int customerId);

        // Get Sales Orders by Product
        Task<IEnumerable<SalesOrder>> GetByProductAsync(int productId);

        // Search by Order Number, Invoice, PO Number and Status
        Task<IEnumerable<SalesOrder>> SearchAsync(string keyword);

        // Get Sales Orders by Status
        Task<IEnumerable<SalesOrder>> GetByStatusAsync(string status);

        // Get Sales Orders by Payment Status
        Task<IEnumerable<SalesOrder>> GetByPaymentStatusAsync(string paymentStatus);

        // Get Sales Orders between dates
        Task<IEnumerable<SalesOrder>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate);

        // Get Approved Sales Orders
        Task<IEnumerable<SalesOrder>> GetApprovedOrdersAsync();

        // Check duplicate Order Number
        Task<bool> IsOrderNumberExistsAsync(string orderNumber);
    }
}