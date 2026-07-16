using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IExciseStampRepository : IGenericRepository<ExciseStamp>
    {
        // Get Stamp by Serial Number
        Task<ExciseStamp?> GetBySerialNumberAsync(string serialNumber);

        // Get Stamps by Product
        Task<IEnumerable<ExciseStamp>> GetByProductAsync(int productId);

        // Get Stamps by Production Order
        Task<IEnumerable<ExciseStamp>> GetByProductionOrderAsync(int productionOrderId);

        // Search by Serial Number, Batch, Status, License and Government Order
        Task<IEnumerable<ExciseStamp>> SearchAsync(string keyword);

        // Get Stamps by Status
        Task<IEnumerable<ExciseStamp>> GetByStatusAsync(string status);

        // Get Available Stamps
        Task<IEnumerable<ExciseStamp>> GetAvailableAsync();

        // Get Applied Stamps
        Task<IEnumerable<ExciseStamp>> GetAppliedAsync();

        // Get Stamps by Storage Bin
        Task<IEnumerable<ExciseStamp>> GetByStorageBinAsync(int binId);

        // Check duplicate Stamp Serial Number
        Task<bool> IsSerialNumberExistsAsync(string serialNumber);
    }
}