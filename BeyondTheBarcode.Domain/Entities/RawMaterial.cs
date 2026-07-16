using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents materials required to manufacture tobacco products.

RELATIONSHIP
- Purchased from Suppliers.
- Used in Bill of Materials (BOM).
- Consumed in Production Orders.
- Stored in Warehouse Inventory.
- Inspected through Quality Control.
- Tracked through Batch Trace records.
*/

public partial class RawMaterial
{
    // =========================
    // Primary Key
    // =========================
    public int RawMaterialId { get; set; }

    // =========================
    // Material Information
    // =========================
    public string MaterialCode { get; set; } = null!;

    public string MaterialName { get; set; } = null!;

    public string MaterialType { get; set; } = null!;

    public string? Grade { get; set; }

    public string? Specification { get; set; }

    public string Uom { get; set; } = null!;

    // =========================
    // Inventory Information
    // =========================
    public decimal MinStockLevel { get; set; }

    public decimal MaxStockLevel { get; set; }

    public decimal ReorderPoint { get; set; }

    public decimal CurrentStock { get; set; }

    public decimal UnitCost { get; set; }

    // =========================
    // Supplier Information
    // =========================
    public int? PrimarySupplierId { get; set; }

    // =========================
    // Storage Information
    // =========================
    public string? StorageConditions { get; set; }

    public string? HazardClassification { get; set; }

    public bool IsControlledSubstance { get; set; }

    public int? ShelfLifeDays { get; set; }

    public string? Hsncode { get; set; }

    public string? CountryOfOrigin { get; set; }

    public string? QualityStandard { get; set; }

    // =========================
    // Receiving Information
    // =========================
    public DateOnly? LastReceivedDate { get; set; }

    public decimal? LastReceivedQty { get; set; }

    // =========================
    // Status
    // =========================
    public bool IsActive { get; set; }

    public string? Remarks { get; set; }

    // =========================
    // Audit Information
    // =========================
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    // =========================
    // Navigation Properties
    // =========================

    public virtual Supplier? PrimarySupplier { get; set; }

    public virtual ICollection<BillOfMaterialsBom> BillOfMaterialsBomRawMaterials { get; set; }
        = new List<BillOfMaterialsBom>();

    public virtual ICollection<BillOfMaterialsBom> BillOfMaterialsBomSubstituteRawMaterials { get; set; }
        = new List<BillOfMaterialsBom>();

    public virtual ICollection<ProductionOrder> ProductionOrders { get; set; }
        = new List<ProductionOrder>();

    public virtual ICollection<WarehouseInventory> WarehouseInventories { get; set; }
        = new List<WarehouseInventory>();

    public virtual ICollection<QualityControlLog> QualityControlLogs { get; set; }
        = new List<QualityControlLog>();

    public virtual ICollection<BatchTrackTrace> BatchTrackTraces { get; set; }
        = new List<BatchTrackTrace>();
}