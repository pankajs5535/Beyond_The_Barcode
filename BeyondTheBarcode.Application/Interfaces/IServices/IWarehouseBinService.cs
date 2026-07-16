using BeyondTheBarcode.Application.DTOs.WarehouseBinDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IWarehouseBinService
    {
        // Get all Warehouse Bins
        Task<IEnumerable<WarehouseBinDto>> GetAllAsync();

        // Get Warehouse Bin by Id
        Task<WarehouseBinDto?> GetByIdAsync(int id);

        // Get Warehouse Bin by Code
        Task<WarehouseBinDto?> GetByCodeAsync(string binCode);

        // Get Warehouse Bins by Warehouse
        Task<IEnumerable<WarehouseBinDto>> GetByWarehouseAsync(string warehouse);

        // Search Warehouse Bins
        Task<IEnumerable<WarehouseBinDto>> SearchAsync(string keyword);

        // Get Active Warehouse Bins
        Task<IEnumerable<WarehouseBinDto>> GetActiveAsync();

        // Get Inactive Warehouse Bins
        Task<IEnumerable<WarehouseBinDto>> GetInactiveAsync();

        // Check Bin Code Exists
        Task<bool> IsBinCodeExistsAsync(string binCode);

        // Create Warehouse Bin
        Task CreateAsync(CreateWarehouseBinDto dto);

        // Update Warehouse Bin
        Task UpdateAsync(UpdateWarehouseBinDto dto);

        // Delete Warehouse Bin
        Task DeleteAsync(int id);
    }
}