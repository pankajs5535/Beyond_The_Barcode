using BeyondTheBarcode.Application.DTOs.QualityControlLogDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IQualityControlLogService
    {
        // Get all QC Records
        Task<IEnumerable<QualityControlLogDto>> GetAllAsync();

        // Get QC Record by Id
        Task<QualityControlLogDto?> GetByIdAsync(int id);

        // Get QC by Reference Number
        Task<QualityControlLogDto?> GetByReferenceAsync(string reference);

        // Get QC by Production Order
        Task<IEnumerable<QualityControlLogDto>> GetByProductionOrderAsync(int productionOrderId);

        // Get QC by Product
        Task<IEnumerable<QualityControlLogDto>> GetByProductAsync(int productId);

        // Get QC by Raw Material
        Task<IEnumerable<QualityControlLogDto>> GetByRawMaterialAsync(int rawMaterialId);

        // Search QC Records
        Task<IEnumerable<QualityControlLogDto>> SearchAsync(string keyword);

        // Get Released QC Records
        Task<IEnumerable<QualityControlLogDto>> GetReleasedAsync();

        // Get Pending QC Records
        Task<IEnumerable<QualityControlLogDto>> GetPendingAsync();

        // Get QC by Result
        Task<IEnumerable<QualityControlLogDto>> GetByResultAsync(string result);

        // Check QC Reference Exists
        Task<bool> IsReferenceExistsAsync(string reference);

        // Create QC Record
        Task CreateAsync(CreateQualityControlLogDto dto);

        // Update QC Record
        Task UpdateAsync(UpdateQualityControlLogDto dto);

        // Delete QC Record
        Task DeleteAsync(int id);
    }
}