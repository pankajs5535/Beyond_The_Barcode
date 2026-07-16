using BeyondTheBarcode.Application.DTOs.PickingPackingListDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IPickingPackingListService
    {
        // Get all Pick & Pack Records
        Task<IEnumerable<PickingPackingListDto>> GetAllAsync();

        // Get Pick & Pack by Id
        Task<PickingPackingListDto?> GetByIdAsync(int id);

        // Get Pick & Pack by Number
        Task<PickingPackingListDto?> GetByNumberAsync(string pickPackNumber);

        // Get Pick & Pack by Sales Order
        Task<IEnumerable<PickingPackingListDto>> GetBySalesOrderAsync(int salesOrderId);

        // Get Pick & Pack by Product
        Task<IEnumerable<PickingPackingListDto>> GetByProductAsync(int productId);

        // Search Pick & Pack Records
        Task<IEnumerable<PickingPackingListDto>> SearchAsync(string keyword);

        // Get Pick & Pack by Status
        Task<IEnumerable<PickingPackingListDto>> GetByStatusAsync(string status);

        // Get Ready for Dispatch
        Task<IEnumerable<PickingPackingListDto>> GetReadyForDispatchAsync();

        // Get Pick & Pack by Picker
        Task<IEnumerable<PickingPackingListDto>> GetByPickerAsync(int pickerId);

        // Check Pick & Pack Number Exists
        Task<bool> IsPickPackNumberExistsAsync(string pickPackNumber);

        // Create Pick & Pack
        Task CreateAsync(CreatePickingPackingListDto dto);

        // Update Pick & Pack
        Task UpdateAsync(UpdatePickingPackingListDto dto);

        // Delete Pick & Pack
        Task DeleteAsync(int id);
    }
}