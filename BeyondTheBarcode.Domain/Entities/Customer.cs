using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents customers who purchase finished tobacco products.

RELATIONSHIP
- One Customer can place many Sales Orders.
- Referenced in Batch Track & Trace records.
*/

public partial class Customer
{
    // =========================
    // Primary Key
    // =========================
    public int CustomerId { get; set; }

    // =========================
    // Customer Information
    // =========================
    public string CustomerCode { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string CustomerType { get; set; } = null!;

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

    public string? LicenseIssuingAuthority { get; set; }

    public DateOnly? LicenseExpiryDate { get; set; }

    // =========================
    // Banking
    // =========================
    public string? BankAccountNumber { get; set; }

    public string? BankIfsccode { get; set; }

    public string? BankName { get; set; }

    // =========================
    // Business
    // =========================
    public decimal CreditLimit { get; set; }

    public int CreditDays { get; set; }

    public decimal OutstandingBalance { get; set; }

    public string? PaymentTerms { get; set; }

    public int? AssignedSalesRepId { get; set; }

    public string? DistributionZone { get; set; }

    public string? TerritoryCode { get; set; }

    public string? RegionCode { get; set; }

    public DateOnly? CustomerSince { get; set; }

    public DateOnly? LastOrderDate { get; set; }

    public int TotalOrders { get; set; }

    // =========================
    // Status
    // =========================
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

    public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        = new List<SalesOrder>();

    public virtual ICollection<BatchTrackTrace> BatchTrackTraces { get; set; }
        = new List<BatchTrackTrace>();
}