using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IRawMaterialRepository : IGenericRepository<RawMaterial>
    {
        // Get Raw Material by Material Code
        Task<RawMaterial?> GetByCodeAsync(string code);

        // Get Raw Materials by Material Type
        Task<IEnumerable<RawMaterial>> GetByTypeAsync(string type);

        // Search by Code, Name, Grade, Specification, HSN, Country, Quality Standard
        Task<IEnumerable<RawMaterial>> SearchAsync(string keyword);

        // Get Active Raw Materials
        Task<IEnumerable<RawMaterial>> GetActiveAsync();

        // Get Inactive Raw Materials
        Task<IEnumerable<RawMaterial>> GetInactiveAsync();

        // Get Raw Materials created between two dates
        Task<IEnumerable<RawMaterial>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);

        // Check duplicate Material Code
        Task<bool> IsMaterialCodeExistsAsync(string materialCode);

        // Get Raw Materials below Reorder Point
        Task<IEnumerable<RawMaterial>> GetLowStockAsync();

        // Get Raw Materials supplied by a specific Supplier
        Task<IEnumerable<RawMaterial>> GetBySupplierAsync(int supplierId);

        // Get Controlled Substance Raw Materials
        Task<IEnumerable<RawMaterial>> GetControlledSubstancesAsync();
    }
}