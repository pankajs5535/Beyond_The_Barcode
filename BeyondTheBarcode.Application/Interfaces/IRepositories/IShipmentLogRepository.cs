using BeyondTheBarcode.Application.Interfaces.IRepositories;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Interfaces.Repositories
{
    public interface IShipmentLogRepository : IGenericRepository<ShipmentLog>
    {
        // Get Shipment by Shipment Number
        Task<ShipmentLog?> GetByShipmentNumberAsync(string shipmentNumber);

        // Get Shipments by Sales Order
        Task<IEnumerable<ShipmentLog>> GetBySalesOrderAsync(int salesOrderId);

        // Get Shipments by Pick & Pack
        Task<IEnumerable<ShipmentLog>> GetByPickPackAsync(int pickPackId);

        // Search by Shipment Number, Invoice, E-Way Bill, Vehicle and Transporter
        Task<IEnumerable<ShipmentLog>> SearchAsync(string keyword);

        // Get Shipments by Status
        Task<IEnumerable<ShipmentLog>> GetByStatusAsync(string status);

        // Get Delivered Shipments
        Task<IEnumerable<ShipmentLog>> GetDeliveredAsync();

        // Get Pending Deliveries
        Task<IEnumerable<ShipmentLog>> GetPendingDeliveriesAsync();

        // Get Shipments by Transporter
        Task<IEnumerable<ShipmentLog>> GetByTransporterAsync(string transporter);

        // Check duplicate Shipment Number
        Task<bool> IsShipmentNumberExistsAsync(string shipmentNumber);
    }
}