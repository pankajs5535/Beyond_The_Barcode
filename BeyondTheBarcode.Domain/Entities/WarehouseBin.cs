using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents a physical storage location inside the warehouse.

RELATIONSHIP
- One Warehouse Bin can store many Inventory records.
- Used during Picking & Packing.
- Can store Excise Stamps.
*/

public partial class WarehouseBin
{
    // =========================
    // Primary Key
    // =========================
    public int BinId { get; set; }

    // =========================
    // Warehouse Information
    // =========================
    public string WarehouseName { get; set; } = null!;

    public string Zone { get; set; } = null!;

    public string Row { get; set; } = null!;

    public string Level { get; set; } = null!;

    public string BinCode { get; set; } = null!;

    public string BinType { get; set; } = null!;

    // =========================
    // Capacity
    // =========================
    public decimal MaxWeightCapacityKg { get; set; }

    public decimal MaxVolumeCapacityCbm { get; set; }

    public decimal? CurrentWeightUsedKg { get; set; }

    public decimal? CurrentVolumeUsedCbm { get; set; }

    // =========================
    // Environment
    // =========================
    public decimal? MinTemperatureC { get; set; }

    public decimal? MaxTemperatureC { get; set; }

    public string? TemperatureZone { get; set; }

    // =========================
    // Status
    // =========================
    public string BinStatus { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? Remarks { get; set; }

    // =========================
    // Audit
    // =========================
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    // =========================
    // Navigation Properties
    // =========================

    public virtual ICollection<WarehouseInventory> WarehouseInventories { get; set; }
        = new List<WarehouseInventory>();

    public virtual ICollection<PickingPackingList> PickingPackingLists { get; set; }
        = new List<PickingPackingList>();

    public virtual ICollection<ExciseStamp> ExciseStamps { get; set; }
        = new List<ExciseStamp>();
}