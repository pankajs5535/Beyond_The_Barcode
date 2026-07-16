using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Defines the approved manufacturing recipe required to produce
a finished tobacco product.

RELATIONSHIP
- Belongs to one Product.
- Uses one Raw Material.
- May reference one Substitute Raw Material.
- Used by Production Orders.
*/

public partial class BillOfMaterialsBom
{
    // =========================
    // Primary Key
    // =========================
    public int Bomid { get; set; }

    // =========================
    // Product Information
    // =========================
    public int ProductId { get; set; }

    public string Bomversion { get; set; } = null!;

    public string Bomstatus { get; set; } = null!;

    // =========================
    // Material Information
    // =========================
    public int RawMaterialId { get; set; }

    public decimal QuantityRequired { get; set; }

    public string Uom { get; set; } = null!;

    public decimal ScrapPercentage { get; set; }

    public decimal? EffectiveQty { get; set; }

    // =========================
    // Production Configuration
    // =========================
    public int? ComponentSequence { get; set; }

    public bool IsCritical { get; set; }

    public bool SubstituteAllowed { get; set; }

    public int? SubstituteRawMaterialId { get; set; }

    public decimal? CostContributionPct { get; set; }

    // =========================
    // Approval
    // =========================
    public DateOnly EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

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

    // One Product → Many BOMs
    public virtual Product Product { get; set; } = null!;

    // One Raw Material → Many BOMs
    public virtual RawMaterial RawMaterial { get; set; } = null!;

    // Optional Substitute Material
    public virtual RawMaterial? SubstituteRawMaterial { get; set; }

    // One BOM → Many Production Orders
    public virtual ICollection<ProductionOrder> ProductionOrders { get; set; }
        = new List<ProductionOrder>();
}