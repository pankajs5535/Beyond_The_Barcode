using BeyondTheBarcode.Application.DTOs.MachineMasterDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IMachineMasterService
    {
        Task<IEnumerable<MachineMasterDto>> GetAllAsync();

        Task<MachineMasterDto?> GetByIdAsync(int id);

        Task<MachineMasterDto?> GetByCodeAsync(string code);

        Task<IEnumerable<MachineMasterDto>> GetByTypeAsync(string type);

        Task<IEnumerable<MachineMasterDto>> SearchAsync(string keyword);

        Task<IEnumerable<MachineMasterDto>> GetActiveAsync();

        Task<IEnumerable<MachineMasterDto>> GetInactiveAsync();

        Task<IEnumerable<MachineMasterDto>> GetByStatusAsync(string status);

        Task<IEnumerable<MachineMasterDto>> GetMaintenanceDueAsync();

        Task<IEnumerable<MachineMasterDto>> GetByPlantAsync(string plant);

        Task<bool> IsMachineCodeExistsAsync(string machineCode);

        Task CreateAsync(CreateMachineMasterDto dto);

        Task UpdateAsync(UpdateMachineMasterDto dto);

        Task DeleteAsync(int id);
    }
}