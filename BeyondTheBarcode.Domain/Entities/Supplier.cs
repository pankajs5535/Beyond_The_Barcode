using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents an approved supplier that provides raw materials,
packaging materials and manufacturing consumables.

RELATIONSHIP
- One Supplier can supply many Raw Materials.
- One Supplier can be referenced in Batch Track & Trace records.
*/

public partial class Supplier
{
    // =========================
    // Primary Key
    // =========================
    public int SupplierId { get; set; }

    // =========================
    // Supplier Information
    // =========================
    public string SupplierCode { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string SupplierType { get; set; } = null!;

    public string? ContactPersonName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? AlternatePhone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string Country { get; set; } = null!;

    public string? PostalCode { get; set; }

    public string? Gstnumber { get; set; }

    public string? Pannumber { get; set; }

    public string? LicenseNumber { get; set; }

    public string? LicenseType { get; set; }

    public DateOnly? LicenseExpiryDate { get; set; }

    // =========================
    // Banking Information
    // =========================
    public string? BankAccountNumber { get; set; }

    public string? BankIfsccode { get; set; }

    public string? BankName { get; set; }

    // =========================
    // Business Information
    // =========================
    public int LeadTimeDays { get; set; }

    public decimal CreditLimit { get; set; }

    public int CreditDays { get; set; }

    public string? PaymentTerms { get; set; }

    public byte? QualityRating { get; set; }

    // =========================
    // Approval Information
    // =========================
    public bool IsApproved { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public bool IsBlacklisted { get; set; }

    public string? BlacklistReason { get; set; }

    public bool IsActive { get; set; }

    // =========================
    // Audit Information
    // =========================
    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    // =========================
    // Navigation Properties
    // =========================

    // One Supplier → Many Raw Materials
    public virtual ICollection<RawMaterial> RawMaterials { get; set; }
        = new List<RawMaterial>();

    // One Supplier → Many Batch Trace Records
    public virtual ICollection<BatchTrackTrace> BatchTrackTraces { get; set; }
        = new List<BatchTrackTrace>();
}