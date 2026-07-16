using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IWarehouseInventoryRepository : IGenericRepository<WarehouseInventory>
    {
        // Get Inventory by Batch Number
        Task<WarehouseInventory?> GetByBatchAsync(string batchNumber);

        // Get Inventory by Product
        Task<IEnumerable<WarehouseInventory>> GetByProductAsync(int productId);

        // Get Inventory by Raw Material
        Task<IEnumerable<WarehouseInventory>> GetByRawMaterialAsync(int rawMaterialId);

        // Get Inventory by Bin
        Task<IEnumerable<WarehouseInventory>> GetByBinAsync(int binId);

        // Search by Batch, Lot, Item Type, Status and GRN
        Task<IEnumerable<WarehouseInventory>> SearchAsync(string keyword);

        // Get Inventory by Status
        Task<IEnumerable<WarehouseInventory>> GetByStatusAsync(string status);

        // Get Expired Inventory
        Task<IEnumerable<WarehouseInventory>> GetExpiredInventoryAsync();

        // Get Low Stock Inventory
        Task<IEnumerable<WarehouseInventory>> GetLowStockAsync();

        // Check duplicate Batch Number
        Task<bool> IsBatchNumberExistsAsync(string batchNumber);
    }
}