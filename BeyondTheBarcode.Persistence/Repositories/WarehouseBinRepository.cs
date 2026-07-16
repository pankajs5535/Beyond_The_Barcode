    using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class WarehouseBinRepository : GenericRepository<WarehouseBin>, IWarehouseBinRepository
    {
        public WarehouseBinRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<WarehouseBin?> GetByCodeAsync(string binCode)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.BinCode == binCode);
        }

        public async Task<IEnumerable<WarehouseBin>> GetByTypeAsync(string binType)
        {
            return await _dbSet.Where(x => x.BinType == binType).ToListAsync();
        }

        public async Task<IEnumerable<WarehouseBin>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.WarehouseName.ToLower().Contains(keyword) ||
                x.Zone.ToLower().Contains(keyword) ||
                x.Row.ToLower().Contains(keyword) ||
                x.Level.ToLower().Contains(keyword) ||
                x.BinCode.ToLower().Contains(keyword) ||
                x.BinType.ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<WarehouseBin>> GetActiveAsync()
        {
            return await _dbSet.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<WarehouseBin>> GetInactiveAsync()
        {
            return await _dbSet.Where(x => !x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<WarehouseBin>> GetByStatusAsync(string status)
        {
            return await _dbSet.Where(x => x.BinStatus == status).ToListAsync();
        }

        public async Task<IEnumerable<WarehouseBin>> GetAvailableBinsAsync()
        {
            return await _dbSet.Where(x => x.BinStatus == "Available").ToListAsync();
        }

        public async Task<IEnumerable<WarehouseBin>> GetByWarehouseAsync(string warehouseName)
        {
            return await _dbSet.Where(x => x.WarehouseName == warehouseName).ToListAsync();
        }

        public async Task<bool> IsBinCodeExistsAsync(string binCode)
        {
            return await _dbSet.AnyAsync(x => x.BinCode == binCode);
        }
    }
}   