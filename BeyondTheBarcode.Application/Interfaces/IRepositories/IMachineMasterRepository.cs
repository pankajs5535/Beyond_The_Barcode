using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IMachineMasterRepository : IGenericRepository<MachineMaster>
    {
        // Get Machine by Machine Code
        Task<MachineMaster?> GetByCodeAsync(string code);

        // Get Machines by Type
        Task<IEnumerable<MachineMaster>> GetByTypeAsync(string type);

        // Search by Code, Name, Type, Manufacturer, Model, Serial Number
        Task<IEnumerable<MachineMaster>> SearchAsync(string keyword);

        // Get Active Machines
        Task<IEnumerable<MachineMaster>> GetActiveAsync();

        // Get Inactive Machines
        Task<IEnumerable<MachineMaster>> GetInactiveAsync();

        // Get Machines by Current Status
        Task<IEnumerable<MachineMaster>> GetByStatusAsync(string status);

        // Get Machines due for Maintenance
        Task<IEnumerable<MachineMaster>> GetMaintenanceDueAsync();

        // Get Machines by Plant
        Task<IEnumerable<MachineMaster>> GetByPlantAsync(string plant);

        // Check duplicate Machine Code
        Task<bool> IsMachineCodeExistsAsync(string machineCode);
    }
}