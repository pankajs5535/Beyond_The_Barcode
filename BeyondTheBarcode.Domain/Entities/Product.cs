using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents the finished tobacco product ready for sale.

RELATIONSHIP
- Manufactured using Bill of Materials (BOM).
- Produced through Production Orders.
- Stored in Warehouse Inventory.
- Sold through Sales Orders.
- Uses Excise Stamps.
- Tracked through Batch Trace records.
*/

public partial class Product
{
    // =========================
    // Primary Key
    // =========================
    public int ProductId { get; set; }

    // =========================
    // Product Information
    // =========================
    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string? SubCategory { get; set; }

    public string? Description { get; set; }

    // =========================
    // Product Specifications
    // =========================
    public string? NicotineContent { get; set; }

    public string? TarContent { get; set; }

    public string? FilterType { get; set; }

    public decimal? CigaretteLengthMm { get; set; }

    public decimal? CigaretteDiameterMm { get; set; }

    // =========================
    // Packaging
    // =========================
    public string? PackagingType { get; set; }

    public int UnitsPerPack { get; set; }

    public int PacksPerCarton { get; set; }

    public int CartonsPerMasterCarton { get; set; }

    // =========================
    // Pricing
    // =========================
    public decimal UnitCostPrice { get; set; }

    public decimal UnitSalePrice { get; set; }

    public decimal? Mrp { get; set; }

    // =========================
    // Tax Information
    // =========================
    public decimal ExciseDutyRate { get; set; }

    public string ExciseDutyBasis { get; set; } = null!;

    public decimal Gstrate { get; set; }

    public decimal? CompensationCessRate { get; set; }

    public string? Hsncode { get; set; }

    // =========================
    // Regulatory Information
    // =========================
    public string CountryOfOrigin { get; set; } = null!;

    public string? RegulatoryApprovalRef { get; set; }

    public bool HealthWarningRequired { get; set; }

    public string? HealthWarningText { get; set; }

    public bool IsExportProduct { get; set; }

    // =========================
    // Status
    // =========================
    public bool IsActive { get; set; }

    public DateOnly? DiscontinuedDate { get; set; }

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

    public virtual ICollection<BillOfMaterialsBom> BillOfMaterialsBoms { get; set; }
        = new List<BillOfMaterialsBom>();

    public virtual ICollection<ProductionOrder> ProductionOrders { get; set; }
        = new List<ProductionOrder>();

    public virtual ICollection<WarehouseInventory> WarehouseInventories { get; set; }
        = new List<WarehouseInventory>();

    public virtual ICollection<QualityControlLog> QualityControlLogs { get; set; }
        = new List<QualityControlLog>();

    public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        = new List<SalesOrder>();

    public virtual ICollection<PickingPackingList> PickingPackingLists { get; set; }
        = new List<PickingPackingList>();

    public virtual ICollection<ExciseStamp> ExciseStamps { get; set; }
        = new List<ExciseStamp>();

    public virtual ICollection<BatchTrackTrace> BatchTrackTraces { get; set; }
        = new List<BatchTrackTrace>();
}