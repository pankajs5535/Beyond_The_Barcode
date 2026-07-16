namespace BeyondTheBarcode.Application.DTOs.BatchTrackTraceDtos;

public class BatchTrackTraceDto
{
        public int TraceId { get; set; }
        public string TraceNumber { get; set; } = null!;
        public string BatchNumber { get; set; } = null!;
        public string? LotNumber { get; set; }
        public int ProductId { get; set; }
        public int ProductionOrderId { get; set; }
        public int? RawMaterialId { get; set; }
        public string? RawMaterialBatch { get; set; }
        public int? SupplierId { get; set; }
        public DateOnly ManufacturingDate { get; set; }
        public DateOnly? PackagingDate { get; set; }
        public DateOnly? ExpiryDate { get; set; }
        public int? ShelfLifeDays { get; set; }
        public int? StampId { get; set; }
        public string? ExciseChallanRef { get; set; }
        public int? QclogId { get; set; }
        public string? Qcstatus { get; set; }
        public DateTime? QcreleasedAt { get; set; }
        public int? WarehouseInventoryId { get; set; }
        public DateOnly? ReceiptDate { get; set; }
        public DateOnly? DispatchDate { get; set; }
        public int? SalesOrderId { get; set; }
        public string? InvoiceNumber { get; set; }
        public int? ShipmentId { get; set; }
        public int? CustomerId { get; set; }
        public DateOnly? DeliveryDate { get; set; }
        public string CurrentStatus { get; set; } = null!;
        public bool IsRecalled { get; set; }
        public string? RecallReason { get; set; }
        public DateTime? RecallInitiatedAt { get; set; }
        public int? RecallInitiatedBy { get; set; }
        public bool IsDestroyed { get; set; }
        public DateTime? DestroyedAt { get; set; }
        public int? DestroyedBy { get; set; }
        public string? DestructionReason { get; set; }
        public string? TraceabilityChain { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
}
