using BeyondTheBarcode.Application.DTOs.ExciseStampDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IExciseStampService
    {
        // Get all Excise Stamps
        Task<IEnumerable<ExciseStampDto>> GetAllAsync();

        // Get Excise Stamp by Id
        Task<ExciseStampDto?> GetByIdAsync(int id);

        // Get Excise Stamp by Serial Number
        Task<ExciseStampDto?> GetBySerialNumberAsync(string serialNumber);

        // Get Excise Stamps by Product
        Task<IEnumerable<ExciseStampDto>> GetByProductAsync(int productId);

        // Get Excise Stamps by Production Order
        Task<IEnumerable<ExciseStampDto>> GetByProductionOrderAsync(int productionOrderId);

        // Search Excise Stamps
        Task<IEnumerable<ExciseStampDto>> SearchAsync(string keyword);

        // Get Excise Stamps by Status
        Task<IEnumerable<ExciseStampDto>> GetByStatusAsync(string status);

        // Get Available Excise Stamps
        Task<IEnumerable<ExciseStampDto>> GetAvailableAsync();

        // Get Applied Excise Stamps
        Task<IEnumerable<ExciseStampDto>> GetAppliedAsync();

        // Get Excise Stamps by Storage Bin
        Task<IEnumerable<ExciseStampDto>> GetByStorageBinAsync(int binId);

        // Check Serial Number Exists
        Task<bool> IsSerialNumberExistsAsync(string serialNumber);

        // Create Excise Stamp
        Task CreateAsync(CreateExciseStampDto dto);

        // Update Excise Stamp
        Task UpdateAsync(UpdateExciseStampDto dto);

        // Delete Excise Stamp
        Task DeleteAsync(int id);
    }
}