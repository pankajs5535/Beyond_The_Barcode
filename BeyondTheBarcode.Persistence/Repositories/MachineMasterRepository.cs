using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class MachineMasterRepository : GenericRepository<MachineMaster>, IMachineMasterRepository
    {
        public MachineMasterRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<MachineMaster?> GetByCodeAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.MachineCode == code);
        }

        public async Task<IEnumerable<MachineMaster>> GetByTypeAsync(string type)
        {
            return await _dbSet.Where(x => x.MachineType == type && x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<MachineMaster>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.MachineCode.ToLower().Contains(keyword) ||
                x.MachineName.ToLower().Contains(keyword) ||
                x.MachineType.ToLower().Contains(keyword) ||
                (x.Manufacturer ?? "").ToLower().Contains(keyword) ||
                (x.ModelNumber ?? "").ToLower().Contains(keyword) ||
                (x.SerialNumber ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<MachineMaster>> GetActiveAsync()
        {
            return await _dbSet.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<MachineMaster>> GetInactiveAsync()
        {
            return await _dbSet.Where(x => !x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<MachineMaster>> GetByStatusAsync(string status)
        {
            return await _dbSet.Where(x => x.CurrentStatus == status).ToListAsync();
        }

        public async Task<IEnumerable<MachineMaster>> GetMaintenanceDueAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            return await _dbSet
                .Where(x => x.NextMaintenanceDate != null && x.NextMaintenanceDate <= today)
                .ToListAsync();
        }

        public async Task<IEnumerable<MachineMaster>> GetByPlantAsync(string plant)
        {
            return await _dbSet.Where(x => x.PlantName == plant).ToListAsync();
        }

        public async Task<bool> IsMachineCodeExistsAsync(string machineCode)
        {
            return await _dbSet.AnyAsync(x => x.MachineCode == machineCode);
        }
    }
}