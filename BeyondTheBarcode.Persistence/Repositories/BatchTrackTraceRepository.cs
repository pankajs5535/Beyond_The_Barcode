using BeyondTheBarcode.Application.Interfaces.Repositories;
using BeyondTheBarcode.Domain.Entities;
using BeyondTheBarcode.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BeyondTheBarcode.Persistence.Repositories
{
    public class BatchTrackTraceRepository : GenericRepository<BatchTrackTrace>, IBatchTrackTraceRepository
    {
        public BatchTrackTraceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BatchTrackTrace?> GetByTraceNumberAsync(string traceNumber)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.TraceNumber == traceNumber);
        }

        public async Task<IEnumerable<BatchTrackTrace>> GetByBatchAsync(string batchNumber)
        {
            return await _dbSet.Where(x => x.BatchNumber == batchNumber).ToListAsync();
        }

        public async Task<IEnumerable<BatchTrackTrace>> GetByProductAsync(int productId)
        {
            return await _dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<BatchTrackTrace>> GetByProductionOrderAsync(int productionOrderId)
        {
            return await _dbSet.Where(x => x.ProductionOrderId == productionOrderId).ToListAsync();
        }

        public async Task<IEnumerable<BatchTrackTrace>> SearchAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _dbSet.Where(x =>
                x.TraceNumber.ToLower().Contains(keyword) ||
                x.BatchNumber.ToLower().Contains(keyword) ||
                (x.LotNumber ?? "").ToLower().Contains(keyword) ||
                (x.InvoiceNumber ?? "").ToLower().Contains(keyword) ||
                x.CurrentStatus.ToLower().Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<BatchTrackTrace>> GetRecalledAsync()
        {
            return await _dbSet.Where(x => x.IsRecalled).ToListAsync();
        }

        public async Task<IEnumerable<BatchTrackTrace>> GetDestroyedAsync()
        {
            return await _dbSet.Where(x => x.IsDestroyed).ToListAsync();
        }

        public async Task<IEnumerable<BatchTrackTrace>> GetByCustomerAsync(int customerId)
        {
            return await _dbSet.Where(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<bool> IsTraceNumberExistsAsync(string traceNumber)
        {
            return await _dbSet.AnyAsync(x => x.TraceNumber == traceNumber);
        }
    }
}