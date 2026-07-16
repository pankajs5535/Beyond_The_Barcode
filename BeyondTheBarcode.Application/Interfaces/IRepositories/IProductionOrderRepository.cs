using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IProductionOrderRepository : IGenericRepository<ProductionOrder>
    {
        // Get Production Order by Order Number
        Task<ProductionOrder?> GetByOrderNumberAsync(string orderNumber);

        // Get Production Orders by Product
        Task<IEnumerable<ProductionOrder>> GetByProductAsync(int productId);

        // Get Production Orders by Machine
        Task<IEnumerable<ProductionOrder>> GetByMachineAsync(int machineId);

        // Search by Order Number, Batch Number, Lot Number, Order Type and Status
        Task<IEnumerable<ProductionOrder>> SearchAsync(string keyword);

        // Get Production Orders by Status
        Task<IEnumerable<ProductionOrder>> GetByStatusAsync(string status);

        // Get Production Orders by Priority
        Task<IEnumerable<ProductionOrder>> GetByPriorityAsync(byte priority);

        // Get Production Orders between Planned Dates
        Task<IEnumerable<ProductionOrder>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate);

        // Get Open Production Orders
        Task<IEnumerable<ProductionOrder>> GetOpenOrdersAsync();

        // Check duplicate Order Number
        Task<bool> IsOrderNumberExistsAsync(string orderNumber);
    }
}