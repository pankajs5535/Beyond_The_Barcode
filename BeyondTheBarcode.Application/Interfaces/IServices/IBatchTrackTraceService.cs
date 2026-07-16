using BeyondTheBarcode.Application.DTOs.BatchTrackTraceDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IBatchTrackTraceService
    {
        // Get all Batch Traces
        Task<IEnumerable<BatchTrackTraceDto>> GetAllAsync();

        // Get Batch Trace by Id
        Task<BatchTrackTraceDto?> GetByIdAsync(int id);

        // Get Batch Trace by Trace Number
        Task<BatchTrackTraceDto?> GetByTraceNumberAsync(string traceNumber);

        // Get Batch Trace by Batch Number
        Task<IEnumerable<BatchTrackTraceDto>> GetByBatchAsync(string batchNumber);

        // Get Batch Trace by Product
        Task<IEnumerable<BatchTrackTraceDto>> GetByProductAsync(int productId);

        // Get Batch Trace by Production Order
        Task<IEnumerable<BatchTrackTraceDto>> GetByProductionOrderAsync(int productionOrderId);

        // Search Batch Traces
        Task<IEnumerable<BatchTrackTraceDto>> SearchAsync(string keyword);

        // Get Recalled Batches
        Task<IEnumerable<BatchTrackTraceDto>> GetRecalledAsync();

        // Get Destroyed Batches
        Task<IEnumerable<BatchTrackTraceDto>> GetDestroyedAsync();

        // Get Batch Trace by Customer
        Task<IEnumerable<BatchTrackTraceDto>> GetByCustomerAsync(int customerId);

        // Check Trace Number Exists
        Task<bool> IsTraceNumberExistsAsync(string traceNumber);

        // Create Batch Trace
        Task CreateAsync(CreateBatchTrackTraceDto dto);

        // Update Batch Trace
        Task UpdateAsync(UpdateBatchTrackTraceDto dto);

        // Delete Batch Trace
        Task DeleteAsync(int id);
    }
}