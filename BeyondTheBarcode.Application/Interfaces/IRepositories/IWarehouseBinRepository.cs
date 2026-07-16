using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IWarehouseBinRepository : IGenericRepository<WarehouseBin>
    {
        // Get Bin by Bin Code
        Task<WarehouseBin?> GetByCodeAsync(string binCode);

        // Get Bins by Type
        Task<IEnumerable<WarehouseBin>> GetByTypeAsync(string binType);

        // Search by Warehouse, Zone, Row, Level, Bin Code and Bin Type
        Task<IEnumerable<WarehouseBin>> SearchAsync(string keyword);

        // Get Active Bins
        Task<IEnumerable<WarehouseBin>> GetActiveAsync();

        // Get Inactive Bins
        Task<IEnumerable<WarehouseBin>> GetInactiveAsync();

        // Get Bins by Status
        Task<IEnumerable<WarehouseBin>> GetByStatusAsync(string status);

        // Get Available Bins
        Task<IEnumerable<WarehouseBin>> GetAvailableBinsAsync();

        // Get Bins by Warehouse
        Task<IEnumerable<WarehouseBin>> GetByWarehouseAsync(string warehouseName);

        // Check duplicate Bin Code
        Task<bool> IsBinCodeExistsAsync(string binCode);
    }
}