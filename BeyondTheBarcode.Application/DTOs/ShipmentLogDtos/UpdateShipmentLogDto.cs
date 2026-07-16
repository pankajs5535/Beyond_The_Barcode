namespace BeyondTheBarcode.Application.DTOs.ShipmentLogDtos;

public class UpdateShipmentLogDto
{
        public int ShipmentId { get; set; }
        public string ShipmentNumber { get; set; } = null!;
        public int SalesOrderId { get; set; }
        public int PickPackId { get; set; }
        public string ShipmentType { get; set; } = null!;
        public string ShipmentStatus { get; set; } = null!;
        public DateTime DispatchDateTime { get; set; }
        public DateTime? ExpectedDeliveryDateTime { get; set; }
        public DateTime? ActualDeliveryDateTime { get; set; }
        public string? TransportMode { get; set; }
        public string? TransporterName { get; set; }
        public string? VehicleNumber { get; set; }
        public string? DriverName { get; set; }
        public string? DriverMobile { get; set; }
        public string? Lrnumber { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? EwayBillNumber { get; set; }
        public string? DispatchLocation { get; set; }
        public string? DeliveryLocation { get; set; }
        public decimal? GrossWeightKg { get; set; }
        public decimal? NetWeightKg { get; set; }
        public decimal? FreightCharges { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverSignature { get; set; }
        public string? DeliveryRemarks { get; set; }
        public string? Remarks { get; set; }
}
