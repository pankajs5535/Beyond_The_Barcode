using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Provides complete traceability of every manufactured tobacco batch
from raw material receipt through production, warehouse storage,
shipment and final customer delivery.

RELATIONSHIP
- Belongs to one Product.
- Belongs to one Production Order.
- May reference one Raw Material.
- May reference one Supplier.
- May reference one Quality Control Log.
- May reference one Warehouse Inventory.
- May reference one Sales Order.
- May reference one Shipment Log.
- May reference one Customer.
- May reference one Excise Stamp.
*/

public partial class BatchTrackTrace
{
    // =========================
    // Primary Key
    // =========================
    public int TraceId { get; set; }

    // =========================
    // Trace Information
    // =========================
    public string TraceNumber { get; set; } = null!;

    public string BatchNumber { get; set; } = null!;

    public string? LotNumber { get; set; }

    // =========================
    // Manufacturing
    // =========================
    public int ProductId { get; set; }

    public int ProductionOrderId { get; set; }

    public int? RawMaterialId { get; set; }

    public string? RawMaterialBatch { get; set; }

    public int? SupplierId { get; set; }

    public DateOnly ManufacturingDate { get; set; }

    public DateOnly? PackagingDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public int? ShelfLifeDays { get; set; }

    // =========================
    // Excise
    // =========================
    public int? StampId { get; set; }

    public string? ExciseChallanRef { get; set; }

    // =========================
    // Quality Control
    // =========================
    public int? QclogId { get; set; }

    public string? Qcstatus { get; set; }

    public DateTime? QcreleasedAt { get; set; }

    // =========================
    // Warehouse
    // =========================
    public int? WarehouseInventoryId { get; set; }

    public DateOnly? ReceiptDate { get; set; }

    public DateOnly? DispatchDate { get; set; }

    // =========================
    // Sales
    // =========================
    public int? SalesOrderId { get; set; }

    public string? InvoiceNumber { get; set; }

    public int? ShipmentId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    // =========================
    // Status
    // =========================
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

    // =========================
    // Audit
    // =========================
    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    // =========================
    // Navigation Properties
    // =========================

    public virtual Product Product { get; set; } = null!;

    public virtual ProductionOrder ProductionOrder { get; set; } = null!;

    public virtual RawMaterial? RawMaterial { get; set; }

    public virtual Supplier? Supplier { get; set; }

    public virtual QualityControlLog? Qclog { get; set; }

    public virtual WarehouseInventory? WarehouseInventory { get; set; }

    public virtual SalesOrder? SalesOrder { get; set; }

    public virtual ShipmentLog? Shipment { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ExciseStamp? Stamp { get; set; }
}