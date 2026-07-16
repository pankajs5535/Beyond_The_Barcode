using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class WarehouseInventoryRepository : GenericRepository<WarehouseInventory>, IWarehouseInventoryRepository
    {
        public WarehouseInventoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<WarehouseInventory?> GetByBatchAsync(string batchNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.BatchNumber == batchNumber);
        }

        public async Task<IEnumerable<WarehouseInventory>> GetByProductAsync(int productId)
        {
            return await _dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<WarehouseInventory>> GetByRawMaterialAsync(int rawMaterialId)
        {
            return await _dbSet.Where(x => x.RawMaterialId == rawMaterialId).ToListAsync();
        }

        public async Task<IEnumerable<WarehouseInventory>> GetByBinAsync(int binId)
        {
            return await _dbSet.Where(x => x.BinId == binId).ToListAsync();
        }

        public async Task<IEnumerable<WarehouseInventory>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.BatchNumber.ToLower().Contains(keyword) ||
                (x.LotNumber ?? "").ToLower().Contains(keyword) ||
                x.ItemType.ToLower().Contains(keyword) ||
                x.InventoryStatus.ToLower().Contains(keyword) ||
                (x.Grnreference ?? "").ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<WarehouseInventory>> GetByStatusAsync(string status)
        {
            return await _dbSet.Where(x => x.InventoryStatus == status).ToListAsync();
        }

        public async Task<IEnumerable<WarehouseInventory>> GetExpiredInventoryAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            return await _dbSet.Where(x =>
                x.ExpiryDate != null &&
                x.ExpiryDate < today)
                .ToListAsync();
        }

        public async Task<IEnumerable<WarehouseInventory>> GetLowStockAsync()
        {
            return await _dbSet.Where(x =>
                x.AvailableQty != null &&
                x.AvailableQty <= 0)
                .ToListAsync();
        }

        public async Task<bool> IsBatchNumberExistsAsync(string batchNumber)
        {
            return await _dbSet.AnyAsync(x => x.BatchNumber == batchNumber);
        }
    }
}