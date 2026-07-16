using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IPickingPackingListRepository : IGenericRepository<PickingPackingList>
    {
        // Get Pick & Pack by Number
        Task<PickingPackingList?> GetByNumberAsync(string pickPackNumber);

        // Get Pick & Pack by Sales Order
        Task<IEnumerable<PickingPackingList>> GetBySalesOrderAsync(int salesOrderId);

        // Get Pick & Pack by Product
        Task<IEnumerable<PickingPackingList>> GetByProductAsync(int productId);

        // Search by Number, Batch, Lot, Status and Seal Number
        Task<IEnumerable<PickingPackingList>> SearchAsync(string keyword);

        // Get by Status
        Task<IEnumerable<PickingPackingList>> GetByStatusAsync(string status);

        // Get Ready for Dispatch
        Task<IEnumerable<PickingPackingList>> GetReadyForDispatchAsync();

        // Get by Picker
        Task<IEnumerable<PickingPackingList>> GetByPickerAsync(int pickerId);

        // Check duplicate Pick & Pack Number
        Task<bool> IsPickPackNumberExistsAsync(string pickPackNumber);
    }
}