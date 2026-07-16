using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class ExciseStampRepository : GenericRepository<ExciseStamp>, IExciseStampRepository
    {
        public ExciseStampRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ExciseStamp?> GetBySerialNumberAsync(string serialNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.StampSerialNumber == serialNumber);
        }

        public async Task<IEnumerable<ExciseStamp>> GetByProductAsync(int productId)
        {
            return await _dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<ExciseStamp>> GetByProductionOrderAsync(int productionOrderId)
        {
            return await _dbSet.Where(x => x.AppliedToProductionOrderId == productionOrderId).ToListAsync();
        }

        public async Task<IEnumerable<ExciseStamp>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.StampSerialNumber.ToLower().Contains(keyword) ||
                (x.BatchNumber ?? "").ToLower().Contains(keyword) ||
                x.Status.ToLower().Contains(keyword) ||
                (x.LicenseNumber ?? "").ToLower().Contains(keyword) ||
                (x.GovernmentOrderRef ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<ExciseStamp>> GetByStatusAsync(string status)
        {
            return await _dbSet.Where(x => x.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<ExciseStamp>> GetAvailableAsync()
        {
            return await _dbSet.Where(x => x.RemainingQty > 0).ToListAsync();
        }

        public async Task<IEnumerable<ExciseStamp>> GetAppliedAsync()
        {
            return await _dbSet.Where(x => x.AppliedQty > 0).ToListAsync();
        }

        public async Task<IEnumerable<ExciseStamp>> GetByStorageBinAsync(int binId)
        {
            return await _dbSet.Where(x => x.StorageLocationBinId == binId).ToListAsync();
        }

        public async Task<bool> IsSerialNumberExistsAsync(string serialNumber)
        {
            return await _dbSet.AnyAsync(x => x.StampSerialNumber == serialNumber);
        }
    }
}   