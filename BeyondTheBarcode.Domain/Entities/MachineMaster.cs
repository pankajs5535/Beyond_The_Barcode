using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents a manufacturing machine used in the tobacco production process.

RELATIONSHIP
- One Machine can execute many Production Orders.
*/

public partial class MachineMaster
{
    // =========================
    // Primary Key
    // =========================
    public int MachineId { get; set; }

    // =========================
    // Machine Information
    // =========================
    public string MachineCode { get; set; } = null!;

    public string MachineName { get; set; } = null!;

    public string MachineType { get; set; } = null!;

    public string? Manufacturer { get; set; }

    public string? ModelNumber { get; set; }

    public string? SerialNumber { get; set; }

    public string? AssetTagNumber { get; set; }

    // =========================
    // Location
    // =========================
    public string? PlantName { get; set; }

    public string? BuildingName { get; set; }

    public string? FloorNumber { get; set; }

    public string? LineNumber { get; set; }

    // =========================
    // Capacity
    // =========================
    public decimal ProductionCapacity { get; set; }

    public string CapacityUom { get; set; } = null!;

    // =========================
    // Maintenance
    // =========================
    public DateOnly? InstallationDate { get; set; }

    public DateOnly? LastMaintenanceDate { get; set; }

    public DateOnly? NextMaintenanceDate { get; set; }

    public string? MaintenanceFrequency { get; set; }

    public string? MaintenanceVendor { get; set; }

    public string? AmccontractRef { get; set; }

    // =========================
    // Financial
    // =========================
    public decimal? PurchaseCost { get; set; }

    public decimal? DepreciationRate { get; set; }

    public string? InsuranceRef { get; set; }

    // =========================
    // Status
    // =========================
    public string CurrentStatus { get; set; } = null!;

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

    // One Machine → Many Production Orders
    public virtual ICollection<ProductionOrder> ProductionOrders { get; set; }
        = new List<ProductionOrder>();
}