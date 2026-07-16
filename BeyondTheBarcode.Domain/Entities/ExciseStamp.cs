using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents government-issued excise stamps used for
regulatory compliance of tobacco products.

RELATIONSHIP
- Belongs to one Product.
- May be applied to one Production Order.
- Stored in one Warehouse Bin.
- Referenced by Batch Track & Trace.
*/

public partial class ExciseStamp
{
    // =========================
    // Primary Key
    // =========================
    public int StampId { get; set; }

    // =========================
    // Stamp Information
    // =========================
    public string StampSerialNumber { get; set; } = null!;

    public string? StampSeriesFrom { get; set; }

    public string? StampSeriesTo { get; set; }

    public string StampType { get; set; } = null!;

    public string? StampDenomination { get; set; }

    public string? StampFormat { get; set; }

    // =========================
    // Product Information
    // =========================
    public int ProductId { get; set; }

    public string? BatchNumber { get; set; }

    // =========================
    // Reference Information
    // =========================
    public string? SupplierRef { get; set; }

    public string? GovernmentOrderRef { get; set; }

    public string? LicenseNumber { get; set; }

    public string? ExciseOfficerRef { get; set; }

    // =========================
    // Receiving Information
    // =========================
    public DateOnly ReceivedDate { get; set; }

    public int ReceivedQty { get; set; }

    // =========================
    // Usage Information
    // =========================
    public DateOnly? ApplicationDate { get; set; }

    public int? AppliedToProductionOrderId { get; set; }

    public int? AppliedQty { get; set; }

    public int? RemainingQty { get; set; }

    public int? DamagedQty { get; set; }

    // =========================
    // Duty Information
    // =========================
    public string Status { get; set; } = null!;

    public decimal DutyAmountPerStamp { get; set; }

    public decimal? TotalDutyAmount { get; set; }

    public decimal? AppliedDutyAmount { get; set; }

    public decimal? CessAmountPerStamp { get; set; }

    // =========================
    // Payment Information
    // =========================
    public string? PaymentChallanRef { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public string? ReturnFiledRef { get; set; }

    public DateOnly? ReturnFiledDate { get; set; }

    // =========================
    // Storage
    // =========================
    public int? StorageLocationBinId { get; set; }

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

    public virtual ProductionOrder? AppliedToProductionOrder { get; set; }

    public virtual WarehouseBin? StorageLocationBin { get; set; }

    public virtual ICollection<BatchTrackTrace> BatchTrackTraces { get; set; }
        = new List<BatchTrackTrace>();
}