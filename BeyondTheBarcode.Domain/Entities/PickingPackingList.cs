using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents the warehouse picking and packing process
for customer sales orders before shipment.

RELATIONSHIP
- Belongs to one Sales Order.
- Belongs to one Product.
- Uses one Warehouse Bin.
- Can generate multiple Shipment Logs.
*/

public partial class PickingPackingList
{
    // =========================
    // Primary Key
    // =========================
    public int PickPackId { get; set; }

    // =========================
    // Picking Information
    // =========================
    public string PickPackNumber { get; set; } = null!;

    public int SalesOrderId { get; set; }

    public string PickPackType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int? AssignedToPickerId { get; set; }

    public DateTime? PickingStartedAt { get; set; }

    public DateTime? PickingCompletedAt { get; set; }

    public DateTime? PackingStartedAt { get; set; }

    public DateTime? PackingCompletedAt { get; set; }

    // =========================
    // Product Information
    // =========================
    public int BinId { get; set; }

    public int ProductId { get; set; }

    public string BatchNumber { get; set; } = null!;

    public string? LotNumber { get; set; }

    public decimal RequestedQty { get; set; }

    public decimal? PickedQty { get; set; }

    public decimal? PackedQty { get; set; }

    public decimal? ShortQty { get; set; }

    public string UnitOfMeasure { get; set; } = null!;

    // =========================
    // Packing Details
    // =========================
    public string? PackagingMaterial { get; set; }

    public int? CartonCount { get; set; }

    public string? CartonNumbers { get; set; }

    public string? PalletNumber { get; set; }

    public decimal? TotalGrossWeightKg { get; set; }

    public decimal? TotalNetWeightKg { get; set; }

    public decimal? TotalVolumeM3 { get; set; }

    public string? SealNumber { get; set; }

    public decimal? TemperatureAtPacking { get; set; }

    public decimal? HumidityAtPacking { get; set; }

    // =========================
    // QC Verification
    // =========================
    public int? QcverifiedBy { get; set; }

    public DateTime? QcverifiedAt { get; set; }

    public string? QcverificationStatus { get; set; }

    public string? Qcremarks { get; set; }

    // =========================
    // Dispatch
    // =========================
    public DateTime? DispatchReadyAt { get; set; }

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

    public virtual SalesOrder SalesOrder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual WarehouseBin Bin { get; set; } = null!;

    public virtual ICollection<ShipmentLog> ShipmentLogs { get; set; }
        = new List<ShipmentLog>();
}