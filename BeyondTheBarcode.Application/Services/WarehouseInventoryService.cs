using BeyondTheBarcode.Application.DTOs.WarehouseInventoryDtos;
using BeyondTheBarcode.Application.Interfaces;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class WarehouseInventoryService : IWarehouseInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseInventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all Warehouse Inventory
        public async Task<IEnumerable<WarehouseInventoryDto>> GetAllAsync()
        {
            var inventories = await _unitOfWork.WarehouseInventories.GetAllAsync();
            return inventories.Select(MapToDto);
        }

        // Get Warehouse Inventory by Id
        public async Task<WarehouseInventoryDto?> GetByIdAsync(int id)
        {
            var inventory = await _unitOfWork.WarehouseInventories.GetByIdAsync(id);

            if (inventory == null)
                return null;

            return MapToDto(inventory);
        }

        // Get Inventory by Product
        public async Task<IEnumerable<WarehouseInventoryDto>> GetByProductAsync(int productId)
        {
            var inventories = await _unitOfWork.WarehouseInventories.GetByProductAsync(productId);
            return inventories.Select(MapToDto);
        }

        // Get Inventory by Raw Material
        public async Task<IEnumerable<WarehouseInventoryDto>> GetByRawMaterialAsync(int rawMaterialId)
        {
            var inventories = await _unitOfWork.WarehouseInventories.GetByRawMaterialAsync(rawMaterialId);
            return inventories.Select(MapToDto);
        }

        // Get Inventory by Warehouse Bin
        public async Task<IEnumerable<WarehouseInventoryDto>> GetByWarehouseBinAsync(int warehouseBinId)
        {
            var inventories = await _unitOfWork.WarehouseInventories.GetByBinAsync(warehouseBinId);
            return inventories.Select(MapToDto);
        }

        // Search Inventory
        public async Task<IEnumerable<WarehouseInventoryDto>> SearchAsync(string keyword)
        {
            var inventories = await _unitOfWork.WarehouseInventories.SearchAsync(keyword);
            return inventories.Select(MapToDto);
        }

        // Get Low Stock Inventory
        public async Task<IEnumerable<WarehouseInventoryDto>> GetLowStockAsync()
        {
            var inventories = await _unitOfWork.WarehouseInventories.GetLowStockAsync();
            return inventories.Select(MapToDto);
        }

        // Get Expired Inventory
        public async Task<IEnumerable<WarehouseInventoryDto>> GetExpiredAsync()
        {
            var inventories = await _unitOfWork.WarehouseInventories.GetExpiredInventoryAsync();
            return inventories.Select(MapToDto);
        }

        // Create Inventory
        public async Task CreateAsync(CreateWarehouseInventoryDto dto)
        {
            var inventory = new WarehouseInventory
            {
                // Map properties from your DTO
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.WarehouseInventories.AddAsync(inventory);
            await _unitOfWork.SaveAsync();
        }

        // Update Inventory
        public async Task UpdateAsync(UpdateWarehouseInventoryDto dto)
        {
            var inventory = await _unitOfWork.WarehouseInventories.GetByIdAsync(dto.InventoryId);

            if (inventory == null)
                throw new Exception("Inventory not found.");

            inventory.LastUpdatedAt = DateTime.UtcNow;

            // Map updated properties from your DTO

            _unitOfWork.WarehouseInventories.Update(inventory);
            await _unitOfWork.SaveAsync();
        }

        // Delete Inventory
        public async Task DeleteAsync(int id)
        {
            var inventory = await _unitOfWork.WarehouseInventories.GetByIdAsync(id);

            if (inventory == null)
                throw new Exception("Inventory not found.");

            _unitOfWork.WarehouseInventories.Delete(inventory);
            await _unitOfWork.SaveAsync();
        }

        // Map Entity to DTO
        private static WarehouseInventoryDto MapToDto(WarehouseInventory inventory)
        {
            return new WarehouseInventoryDto
            {
                // Map properties according to your WarehouseInventory entity & DTO
            };
        }
    }
}