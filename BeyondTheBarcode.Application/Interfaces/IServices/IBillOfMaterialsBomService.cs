using BeyondTheBarcode.Application.DTOs.BillOfMaterialsBomDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IBillOfMaterialsBomService
    {
        // Get all Bill of Materials (BOM) records
        Task<IEnumerable<BillOfMaterialsBomDto>> GetAllAsync();

        // Get a BOM by its unique ID
        Task<BillOfMaterialsBomDto?> GetByIdAsync(int id);

        // Get a BOM by its version number
        Task<BillOfMaterialsBomDto?> GetByVersionAsync(string version);

        // Get all BOMs associated with a specific finished product
        Task<IEnumerable<BillOfMaterialsBomDto>> GetByProductAsync(int productId);

        // Get all BOMs that use a specific raw material
        Task<IEnumerable<BillOfMaterialsBomDto>> GetByRawMaterialAsync(int rawMaterialId);

        // Search BOMs by version, product, raw material, or other relevant fields
        Task<IEnumerable<BillOfMaterialsBomDto>> SearchAsync(string keyword);

        // Get all active BOMs
        Task<IEnumerable<BillOfMaterialsBomDto>> GetActiveAsync();

        // Get BOMs effective within the specified date range
        Task<IEnumerable<BillOfMaterialsBomDto>> GetByEffectiveDateAsync(DateOnly fromDate, DateOnly toDate);

        // Get BOMs containing critical components
        Task<IEnumerable<BillOfMaterialsBomDto>> GetCriticalComponentsAsync();

        // Get BOMs where substitute materials are allowed
        Task<IEnumerable<BillOfMaterialsBomDto>> GetSubstituteAllowedAsync();

        // Check whether a BOM version already exists
        Task<bool> IsBomVersionExistsAsync(string version);

        // Create a new BOM
        Task CreateAsync(CreateBillOfMaterialsBomDto dto);

        // Update an existing BOM
        Task UpdateAsync(UpdateBillOfMaterialsBomDto dto);

        // Delete a BOM by its ID
        Task DeleteAsync(int id);
    }
}