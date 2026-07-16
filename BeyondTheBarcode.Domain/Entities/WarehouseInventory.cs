using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents inventory stored inside warehouse bins.

RELATIONSHIP
- Belongs to one Warehouse Bin.
- May contain one Product or one Raw Material.
- Referenced by Batch Track & Trace.
*/

public partial class WarehouseInventory
{
    // =========================
    // Primary Key
    // =========================
    public int InventoryId { get; set; }

    // =========================
    // Storage Information
    // =========================
    public int BinId { get; set; }

    public string ItemType { get; set; } = null!;

    public int? ProductId { get; set; }

    public int? RawMaterialId { get; set; }

    public string BatchNumber { get; set; } = null!;

    public string? LotNumber { get; set; }

    // =========================
    // Quantity
    // =========================
    public decimal Quantity { get; set; }

    public string Uom { get; set; } = null!;

    public decimal ReservedQty { get; set; }

    public decimal? AvailableQty { get; set; }

    public decimal DamagedQty { get; set; }

    public decimal QuarantineQty { get; set; }

    // =========================
    // Manufacturing
    // =========================
    public DateOnly? ManufacturingDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    // =========================
    // Cost
    // =========================
    public decimal UnitCost { get; set; }

    public decimal? TotalValue { get; set; }

    public string ValuationMethod { get; set; } = null!;

    // =========================
    // Status
    // =========================
    public string InventoryStatus { get; set; } = null!;

    public string? QcreleaseRef { get; set; }

    public string? Grnreference { get; set; }

    // =========================
    // Cycle Count
    // =========================
    public DateOnly? LastCycleCountDate { get; set; }

    public decimal? LastCycleCountQty { get; set; }

    public decimal? VarianceQty { get; set; }

    // =========================
    // Audit
    // =========================
    public int? LastUpdatedBy { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    // =========================
    // Navigation Properties
    // =========================

    public virtual WarehouseBin Bin { get; set; } = null!;

    public virtual Product? Product { get; set; }

    public virtual RawMaterial? RawMaterial { get; set; }

    public virtual ICollection<BatchTrackTrace> BatchTrackTraces { get; set; }
        = new List<BatchTrackTrace>();
}