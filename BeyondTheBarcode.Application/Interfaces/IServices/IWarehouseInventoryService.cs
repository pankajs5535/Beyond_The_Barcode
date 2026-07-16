using BeyondTheBarcode.Application.DTOs.WarehouseInventoryDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IWarehouseInventoryService
    {
        // Get all Warehouse Inventory
        Task<IEnumerable<WarehouseInventoryDto>> GetAllAsync();

        // Get Warehouse Inventory by Id
        Task<WarehouseInventoryDto?> GetByIdAsync(int id);

        // Get Inventory by Product
        Task<IEnumerable<WarehouseInventoryDto>> GetByProductAsync(int productId);

        // Get Inventory by Raw Material
        Task<IEnumerable<WarehouseInventoryDto>> GetByRawMaterialAsync(int rawMaterialId);

        // Get Inventory by Warehouse Bin
        Task<IEnumerable<WarehouseInventoryDto>> GetByWarehouseBinAsync(int warehouseBinId);

        // Search Inventory
        Task<IEnumerable<WarehouseInventoryDto>> SearchAsync(string keyword);

        // Get Low Stock Inventory
        Task<IEnumerable<WarehouseInventoryDto>> GetLowStockAsync();

        // Get Expired Inventory
        Task<IEnumerable<WarehouseInventoryDto>> GetExpiredAsync();

        // Create Inventory
        Task CreateAsync(CreateWarehouseInventoryDto dto);

        // Update Inventory
        Task UpdateAsync(UpdateWarehouseInventoryDto dto);

        // Delete Inventory
        Task DeleteAsync(int id);
    }
}