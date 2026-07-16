using BeyondTheBarcode.Application.DTOs.ShipmentLogDtos;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class ShipmentLogService : IShipmentLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShipmentLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all Shipments
        public async Task<IEnumerable<ShipmentLogDto>> GetAllAsync()
        {
            var shipments = await _unitOfWork.ShipmentLogs.GetAllAsync();
            return shipments.Select(MapToDto);
        }

        // Get Shipment by Id
        public async Task<ShipmentLogDto?> GetByIdAsync(int id)
        {
            var shipment = await _unitOfWork.ShipmentLogs.GetByIdAsync(id);

            if (shipment == null)
                return null;

            return MapToDto(shipment);
        }

        // Get Shipment by Shipment Number
        public async Task<ShipmentLogDto?> GetByShipmentNumberAsync(string shipmentNumber)
        {
            var shipment = await _unitOfWork.ShipmentLogs.GetByShipmentNumberAsync(shipmentNumber);

            if (shipment == null)
                return null;

            return MapToDto(shipment);
        }

        // Get Shipments by Sales Order
        public async Task<IEnumerable<ShipmentLogDto>> GetBySalesOrderAsync(int salesOrderId)
        {
            var shipments = await _unitOfWork.ShipmentLogs.GetBySalesOrderAsync(salesOrderId);
            return shipments.Select(MapToDto);
        }

        // Get Shipments by Pick & Pack
        public async Task<IEnumerable<ShipmentLogDto>> GetByPickPackAsync(int pickPackId)
        {
            var shipments = await _unitOfWork.ShipmentLogs.GetByPickPackAsync(pickPackId);
            return shipments.Select(MapToDto);
        }

        // Search Shipments
        public async Task<IEnumerable<ShipmentLogDto>> SearchAsync(string keyword)
        {
            var shipments = await _unitOfWork.ShipmentLogs.SearchAsync(keyword);
            return shipments.Select(MapToDto);
        }

        // Get Shipments by Status
        public async Task<IEnumerable<ShipmentLogDto>> GetByStatusAsync(string status)
        {
            var shipments = await _unitOfWork.ShipmentLogs.GetByStatusAsync(status);
            return shipments.Select(MapToDto);
        }
        // Get Delivered Shipments
        public async Task<IEnumerable<ShipmentLogDto>> GetDeliveredAsync()
        {
            var shipments = await _unitOfWork.ShipmentLogs.GetDeliveredAsync();
            return shipments.Select(MapToDto);
        }

        // Get Pending Deliveries
        public async Task<IEnumerable<ShipmentLogDto>> GetPendingDeliveriesAsync()
        {
            var shipments = await _unitOfWork.ShipmentLogs.GetPendingDeliveriesAsync();
            return shipments.Select(MapToDto);
        }

        // Get Shipments by Transporter
        public async Task<IEnumerable<ShipmentLogDto>> GetByTransporterAsync(string transporter)
        {
            var shipments = await _unitOfWork.ShipmentLogs.GetByTransporterAsync(transporter);
            return shipments.Select(MapToDto);
        }

        // Check Shipment Number Exists
        public async Task<bool> IsShipmentNumberExistsAsync(string shipmentNumber)
        {
            return await _unitOfWork.ShipmentLogs.IsShipmentNumberExistsAsync(shipmentNumber);
        }

        // Create Shipment
        public async Task CreateAsync(CreateShipmentLogDto dto)
        {
            var shipment = new ShipmentLog
            {
                ShipmentNumber = dto.ShipmentNumber,
                SalesOrderId = dto.SalesOrderId,
                PickPackId = dto.PickPackId,
                ShipmentType = dto.ShipmentType,
                ShipmentStatus = dto.ShipmentStatus,
                DispatchDateTime = dto.DispatchDateTime,
                ExpectedDeliveryDateTime = dto.ExpectedDeliveryDateTime,
                ActualDeliveryDateTime = dto.ActualDeliveryDateTime,
                TransportMode = dto.TransportMode,
                TransporterName = dto.TransporterName,
                VehicleNumber = dto.VehicleNumber,
                DriverName = dto.DriverName,
                DriverMobile = dto.DriverMobile,
                Lrnumber = dto.Lrnumber,
                InvoiceNumber = dto.InvoiceNumber,
                EwayBillNumber = dto.EwayBillNumber,
                DispatchLocation = dto.DispatchLocation,
                DeliveryLocation = dto.DeliveryLocation,
                GrossWeightKg = dto.GrossWeightKg,
                NetWeightKg = dto.NetWeightKg,
                FreightCharges = dto.FreightCharges,
                ReceiverName = dto.ReceiverName,
                ReceiverSignature = dto.ReceiverSignature,
                DeliveryRemarks = dto.DeliveryRemarks,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.ShipmentLogs.AddAsync(shipment);
            await _unitOfWork.SaveAsync();
        }

        // Update Shipment
        public async Task UpdateAsync(UpdateShipmentLogDto dto)
        {
            var shipment = await _unitOfWork.ShipmentLogs.GetByIdAsync(dto.ShipmentId);

            if (shipment == null)
                throw new Exception("Shipment not found.");

            shipment.ShipmentNumber = dto.ShipmentNumber;
            shipment.SalesOrderId = dto.SalesOrderId;
            shipment.PickPackId = dto.PickPackId;
            shipment.ShipmentType = dto.ShipmentType;
            shipment.ShipmentStatus = dto.ShipmentStatus;
            shipment.DispatchDateTime = dto.DispatchDateTime;
            shipment.ExpectedDeliveryDateTime = dto.ExpectedDeliveryDateTime;
            shipment.ActualDeliveryDateTime = dto.ActualDeliveryDateTime;
            shipment.TransportMode = dto.TransportMode;
            shipment.TransporterName = dto.TransporterName;
            shipment.VehicleNumber = dto.VehicleNumber;
            shipment.DriverName = dto.DriverName;
            shipment.DriverMobile = dto.DriverMobile;
            shipment.Lrnumber = dto.Lrnumber;
            shipment.InvoiceNumber = dto.InvoiceNumber;
            shipment.EwayBillNumber = dto.EwayBillNumber;
            shipment.DispatchLocation = dto.DispatchLocation;
            shipment.DeliveryLocation = dto.DeliveryLocation;
            shipment.GrossWeightKg = dto.GrossWeightKg;
            shipment.NetWeightKg = dto.NetWeightKg;
            shipment.FreightCharges = dto.FreightCharges;
            shipment.ReceiverName = dto.ReceiverName;
            shipment.ReceiverSignature = dto.ReceiverSignature;
            shipment.DeliveryRemarks = dto.DeliveryRemarks;
            shipment.Remarks = dto.Remarks;
            shipment.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.ShipmentLogs.Update(shipment);
            await _unitOfWork.SaveAsync();
        }

        // Delete Shipment
        public async Task DeleteAsync(int id)
        {
            var shipment = await _unitOfWork.ShipmentLogs.GetByIdAsync(id);

            if (shipment == null)
                throw new Exception("Shipment not found.");

            _unitOfWork.ShipmentLogs.Delete(shipment);
            await _unitOfWork.SaveAsync();
        }

        // Map Entity to DTO
        private static ShipmentLogDto MapToDto(ShipmentLog shipment)
        {
            return new ShipmentLogDto
            {
                ShipmentId = shipment.ShipmentId,
                ShipmentNumber = shipment.ShipmentNumber,
                SalesOrderId = shipment.SalesOrderId,
                PickPackId = shipment.PickPackId,
                ShipmentType = shipment.ShipmentType,
                ShipmentStatus = shipment.ShipmentStatus,
                DispatchDateTime = shipment.DispatchDateTime,
                ExpectedDeliveryDateTime = shipment.ExpectedDeliveryDateTime,
                ActualDeliveryDateTime = shipment.ActualDeliveryDateTime,
                TransportMode = shipment.TransportMode,
                TransporterName = shipment.TransporterName,
                VehicleNumber = shipment.VehicleNumber,
                DriverName = shipment.DriverName,
                DriverMobile = shipment.DriverMobile,
                Lrnumber = shipment.Lrnumber,
                InvoiceNumber = shipment.InvoiceNumber,
                EwayBillNumber = shipment.EwayBillNumber,
                DispatchLocation = shipment.DispatchLocation,
                DeliveryLocation = shipment.DeliveryLocation,
                GrossWeightKg = shipment.GrossWeightKg,
                NetWeightKg = shipment.NetWeightKg,
                FreightCharges = shipment.FreightCharges,
                ReceiverName = shipment.ReceiverName,
                ReceiverSignature = shipment.ReceiverSignature,
                DeliveryRemarks = shipment.DeliveryRemarks,
                Remarks = shipment.Remarks,
                CreatedAt = shipment.CreatedAt,
                UpdatedAt = shipment.UpdatedAt,
                CreatedBy = shipment.CreatedBy,
                UpdatedBy = shipment.UpdatedBy
            };
        }
    }
}
