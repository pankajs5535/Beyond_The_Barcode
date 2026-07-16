using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IBatchTrackTraceRepository : IGenericRepository<BatchTrackTrace>
    {
        // Get Trace by Trace Number
        Task<BatchTrackTrace?> GetByTraceNumberAsync(string traceNumber);

        // Get Trace by Batch Number
        Task<IEnumerable<BatchTrackTrace>> GetByBatchAsync(string batchNumber);

        // Get Trace by Product
        Task<IEnumerable<BatchTrackTrace>> GetByProductAsync(int productId);

        // Get Trace by Production Order
        Task<IEnumerable<BatchTrackTrace>> GetByProductionOrderAsync(int productionOrderId);

        // Search by Trace Number, Batch, Lot, Invoice and Status
        Task<IEnumerable<BatchTrackTrace>> SearchAsync(string keyword);

        // Get Recalled Batches
        Task<IEnumerable<BatchTrackTrace>> GetRecalledAsync();

        // Get Destroyed Batches
        Task<IEnumerable<BatchTrackTrace>> GetDestroyedAsync();

        // Get Trace by Customer
        Task<IEnumerable<BatchTrackTrace>> GetByCustomerAsync(int customerId);

        // Check duplicate Trace Number
        Task<bool> IsTraceNumberExistsAsync(string traceNumber);
    }
}