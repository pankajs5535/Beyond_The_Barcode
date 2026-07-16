using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class QualityControlLogRepository : GenericRepository<QualityControlLog>, IQualityControlLogRepository
    {
        public QualityControlLogRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<QualityControlLog?> GetByReferenceAsync(string reference)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.QcreferenceNumber == reference);
        }

        public async Task<IEnumerable<QualityControlLog>> GetByProductionOrderAsync(int productionOrderId)
        {
            return await _dbSet.Where(x => x.ProductionOrderId == productionOrderId).ToListAsync();
        }

        public async Task<IEnumerable<QualityControlLog>> GetByProductAsync(int productId)
        {
            return await _dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<QualityControlLog>> GetByRawMaterialAsync(int rawMaterialId)
        {
            return await _dbSet.Where(x => x.RawMaterialId == rawMaterialId).ToListAsync();
        }

        public async Task<IEnumerable<QualityControlLog>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.QcreferenceNumber.ToLower().Contains(keyword) ||
                x.BatchNumber.ToLower().Contains(keyword) ||
                (x.LotNumber ?? "").ToLower().Contains(keyword) ||
                x.OverallResult.ToLower().Contains(keyword) ||
                (x.Ncrnumber ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<QualityControlLog>> GetReleasedAsync()
        {
            return await _dbSet.Where(x => x.IsReleased).ToListAsync();
        }

        public async Task<IEnumerable<QualityControlLog>> GetPendingAsync()
        {
            return await _dbSet.Where(x => !x.IsReleased).ToListAsync();
        }

        public async Task<IEnumerable<QualityControlLog>> GetByResultAsync(string result)
        {
            return await _dbSet.Where(x => x.OverallResult == result).ToListAsync();
        }

        public async Task<bool> IsReferenceExistsAsync(string reference)
        {
            return await _dbSet.AnyAsync(x => x.QcreferenceNumber == reference);
        }
    }
}