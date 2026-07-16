using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IQualityControlLogRepository : IGenericRepository<QualityControlLog>
    {
        // Get QC by Reference Number
        Task<QualityControlLog?> GetByReferenceAsync(string reference);

        // Get QC by Production Order
        Task<IEnumerable<QualityControlLog>> GetByProductionOrderAsync(int productionOrderId);

        // Get QC by Product
        Task<IEnumerable<QualityControlLog>> GetByProductAsync(int productId);

        // Get QC by Raw Material
        Task<IEnumerable<QualityControlLog>> GetByRawMaterialAsync(int rawMaterialId);

        // Search by Reference, Batch, Lot, Result and NCR
        Task<IEnumerable<QualityControlLog>> SearchAsync(string keyword);

        // Get Released QC Records
        Task<IEnumerable<QualityControlLog>> GetReleasedAsync();

        // Get Pending QC Records
        Task<IEnumerable<QualityControlLog>> GetPendingAsync();

        // Get QC by Result
        Task<IEnumerable<QualityControlLog>> GetByResultAsync(string result);

        // Check duplicate QC Reference
        Task<bool> IsReferenceExistsAsync(string reference);
    }
}