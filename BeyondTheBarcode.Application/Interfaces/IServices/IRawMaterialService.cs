using BeyondTheBarcode.Application.DTOs.RawMaterialDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IRawMaterialService
    {
        Task<IEnumerable<RawMaterialDto>> GetAllAsync();

        Task<RawMaterialDto?> GetByIdAsync(int id);

        Task<RawMaterialDto?> GetByCodeAsync(string code);

        Task<IEnumerable<RawMaterialDto>> GetByTypeAsync(string type);

        Task<IEnumerable<RawMaterialDto>> SearchAsync(string keyword);

        Task<IEnumerable<RawMaterialDto>> GetActiveAsync();

        Task<IEnumerable<RawMaterialDto>> GetInactiveAsync();

        Task<IEnumerable<RawMaterialDto>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);

        Task<IEnumerable<RawMaterialDto>> GetLowStockAsync();

        Task<IEnumerable<RawMaterialDto>> GetBySupplierAsync(int supplierId);

        Task<IEnumerable<RawMaterialDto>> GetControlledSubstancesAsync();

        Task<bool> IsMaterialCodeExistsAsync(string materialCode);

        Task CreateAsync(CreateRawMaterialDto dto);

        Task UpdateAsync(UpdateRawMaterialDto dto);

        Task DeleteAsync(int id);
    }
}