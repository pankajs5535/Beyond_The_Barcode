using BeyondTheBarcode.Application.DTOs.ProductionOrderDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IProductionOrderService
    {
        // Get all Production Orders
        Task<IEnumerable<ProductionOrderDto>> GetAllAsync();

        // Get Production Order by Id
        Task<ProductionOrderDto?> GetByIdAsync(int id);

        // Get Production Order by Order Number
        Task<ProductionOrderDto?> GetByOrderNumberAsync(string orderNumber);

        // Get Production Orders by Product
        Task<IEnumerable<ProductionOrderDto>> GetByProductAsync(int productId);

        // Get Production Orders by Machine
        Task<IEnumerable<ProductionOrderDto>> GetByMachineAsync(int machineId);

        // Search Production Orders
        Task<IEnumerable<ProductionOrderDto>> SearchAsync(string keyword);

        // Get Production Orders by Status
        Task<IEnumerable<ProductionOrderDto>> GetByStatusAsync(string status);

        // Get Production Orders by Priority
        Task<IEnumerable<ProductionOrderDto>> GetByPriorityAsync(byte priority);

        // Get Production Orders by Date Range
        Task<IEnumerable<ProductionOrderDto>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate);

        // Get Open Production Orders
        Task<IEnumerable<ProductionOrderDto>> GetOpenOrdersAsync();

        // Check Order Number Exists
        Task<bool> IsOrderNumberExistsAsync(string orderNumber);

        // Create Production Order
        Task CreateAsync(CreateProductionOrderDto dto);

        // Update Production Order
        Task UpdateAsync(UpdateProductionOrderDto dto);

        // Delete Production Order
        Task DeleteAsync(int id);
    }
}