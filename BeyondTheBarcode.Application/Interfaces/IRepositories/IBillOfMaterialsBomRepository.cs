using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IBillOfMaterialsBomRepository : IGenericRepository<BillOfMaterialsBom>
    {
        // Get BOM by BOM Version
        Task<BillOfMaterialsBom?> GetByVersionAsync(string version);

        // Get BOMs by Product
        Task<IEnumerable<BillOfMaterialsBom>> GetByProductAsync(int productId);

        // Get BOMs by Raw Material
        Task<IEnumerable<BillOfMaterialsBom>> GetByRawMaterialAsync(int rawMaterialId);

        // Search by Version, Status and UOM
        Task<IEnumerable<BillOfMaterialsBom>> SearchAsync(string keyword);

        // Get Active BOMs
        Task<IEnumerable<BillOfMaterialsBom>> GetActiveAsync();

        // Get BOMs Effective between dates
        Task<IEnumerable<BillOfMaterialsBom>> GetByEffectiveDateAsync(DateOnly fromDate, DateOnly toDate);

        // Check duplicate BOM Version
        Task<bool> IsBomVersionExistsAsync(string version);

        // Get Critical Components
        Task<IEnumerable<BillOfMaterialsBom>> GetCriticalComponentsAsync();

        // Get BOMs allowing Substitute Material
        Task<IEnumerable<BillOfMaterialsBom>> GetSubstituteAllowedAsync();
    }
}