using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents a manufacturing order used to produce finished tobacco products.

RELATIONSHIP
- Produces one Product.
- Uses one Bill of Materials (BOM).
- May run on one Machine.
- Creates Batch Trace records.
- Generates Quality Control records.
- Uses Excise Stamps.
*/

public partial class ProductionOrder
{
    // =========================
    // Primary Key
    // =========================
    public int ProductionOrderId { get; set; }

    // =========================
    // Order Information
    // =========================
    public string OrderNumber { get; set; } = null!;

    public int ProductId { get; set; }

    public int Bomid { get; set; }

    public string OrderType { get; set; } = null!;

    // =========================
    // Production
    // =========================
    public decimal PlannedQty { get; set; }

    public decimal? ActualQty { get; set; }

    public decimal? RejectedQty { get; set; }

    public decimal? YieldPercentage { get; set; }

    public string Status { get; set; } = null!;

    public byte Priority { get; set; }

    // =========================
    // Schedule
    // =========================
    public DateOnly PlannedStartDate { get; set; }

    public DateOnly PlannedEndDate { get; set; }

    public DateOnly? ActualStartDate { get; set; }

    public DateOnly? ActualEndDate { get; set; }

    // =========================
    // Machine
    // =========================
    public int? MachineId { get; set; }

    public int? OperatorId { get; set; }

    public string? ShiftCode { get; set; }

    // =========================
    // Batch
    // =========================
    public string BatchNumber { get; set; } = null!;

    public string? LotNumber { get; set; }

    // =========================
    // Costing
    // =========================
    public decimal? PlannedLaborHours { get; set; }

    public decimal? ActualLaborHours { get; set; }

    public decimal? LaborCostPlanned { get; set; }

    public decimal? LaborCostActual { get; set; }

    public decimal? MaterialCostPlanned { get; set; }

    public decimal? MaterialCostActual { get; set; }

    public decimal? OverheadCostPlanned { get; set; }

    public decimal? OverheadCostActual { get; set; }

    public decimal? TotalCostActual { get; set; }

    // =========================
    // Approval
    // =========================
    public string? ReasonForDeviation { get; set; }

    public string? SalesOrderRef { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public int? ClosedBy { get; set; }

    public DateTime? ClosedAt { get; set; }

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

    public virtual BillOfMaterialsBom Bom { get; set; } = null!;

    public virtual MachineMaster? Machine { get; set; }

    public virtual ICollection<BatchTrackTrace> BatchTrackTraces { get; set; }
        = new List<BatchTrackTrace>();

    public virtual ICollection<QualityControlLog> QualityControlLogs { get; set; }
        = new List<QualityControlLog>();

    public virtual ICollection<ExciseStamp> ExciseStamps { get; set; }
        = new List<ExciseStamp>();
}