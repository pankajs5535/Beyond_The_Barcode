using BeyondTheBarcode.Application.DTOs.ShipmentLogDtos;

namespace BeyondTheBarcode.Application.Interfaces.Services
{
    public interface IShipmentLogService
    {
        // Get all Shipments
        Task<IEnumerable<ShipmentLogDto>> GetAllAsync();

        // Get Shipment by Id
        Task<ShipmentLogDto?> GetByIdAsync(int id);

        // Get Shipment by Shipment Number
        Task<ShipmentLogDto?> GetByShipmentNumberAsync(string shipmentNumber);

        // Get Shipments by Sales Order
        Task<IEnumerable<ShipmentLogDto>> GetBySalesOrderAsync(int salesOrderId);

        // Get Shipments by Pick & Pack
        Task<IEnumerable<ShipmentLogDto>> GetByPickPackAsync(int pickPackId);

        // Search Shipments
        Task<IEnumerable<ShipmentLogDto>> SearchAsync(string keyword);

        // Get Shipments by Status
        Task<IEnumerable<ShipmentLogDto>> GetByStatusAsync(string status);

        // Get Delivered Shipments
        Task<IEnumerable<ShipmentLogDto>> GetDeliveredAsync();

        // Get Pending Deliveries
        Task<IEnumerable<ShipmentLogDto>> GetPendingDeliveriesAsync();

        // Get Shipments by Transporter
        Task<IEnumerable<ShipmentLogDto>> GetByTransporterAsync(string transporter);

        // Check Shipment Number Exists
        Task<bool> IsShipmentNumberExistsAsync(string shipmentNumber);

        // Create Shipment
        Task CreateAsync(CreateShipmentLogDto dto);

        // Update Shipment
        Task UpdateAsync(UpdateShipmentLogDto dto);

        // Delete Shipment
        Task DeleteAsync(int id);
    }
}