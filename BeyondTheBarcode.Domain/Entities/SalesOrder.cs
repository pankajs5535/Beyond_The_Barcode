using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents a customer sales order for finished tobacco products.

RELATIONSHIP
- Belongs to one Customer.
- Contains one Product.
- Generates Picking & Packing Lists.
- Generates Shipment Logs.
- Referenced in Batch Track & Trace.
*/

public partial class SalesOrder
{
    // =========================
    // Primary Key
    // =========================
    public int SalesOrderId { get; set; }

    // =========================
    // Order Information
    // =========================
    public string OrderNumber { get; set; } = null!;

    public int CustomerId { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly? RequestedDeliveryDate { get; set; }

    public DateOnly? ConfirmedDeliveryDate { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string? OrderSource { get; set; }

    // =========================
    // Product
    // =========================
    public int ProductId { get; set; }

    public decimal OrderedQty { get; set; }

    public decimal? ConfirmedQty { get; set; }

    public decimal? ShippedQty { get; set; }

    public decimal? BackOrderQty { get; set; }

    public string UnitOfMeasure { get; set; } = null!;

    // =========================
    // Pricing
    // =========================
    public decimal UnitPrice { get; set; }

    public decimal? DiscountPercent { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? TaxableAmount { get; set; }

    public decimal Gstrate { get; set; }

    public decimal? Cgstamount { get; set; }

    public decimal? Sgstamount { get; set; }

    public decimal? Igstamount { get; set; }

    public decimal? CessAmount { get; set; }

    public decimal? ExciseDutyAmount { get; set; }

    public decimal? TotalTaxAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? RoundOff { get; set; }

    public decimal? FinalAmount { get; set; }

    // =========================
    // Payment
    // =========================
    public string PaymentStatus { get; set; } = null!;

    public DateOnly? PaymentDueDate { get; set; }

    // =========================
    // Shipping
    // =========================
    public string? ShippingAddress { get; set; }

    public string? ShippingCity { get; set; }

    public string? ShippingState { get; set; }

    public string? ShippingPincode { get; set; }

    public bool IsInterstate { get; set; }

    // =========================
    // Additional Information
    // =========================
    public string? Ponumber { get; set; }

    public int? SalesRepId { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public int? CancelledBy { get; set; }

    public DateTime? CancelledAt { get; set; }

    public string? CancellationReason { get; set; }

    public string? InvoiceNumber { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public string? EwayBillNumber { get; set; }

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

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<PickingPackingList> PickingPackingLists { get; set; }
        = new List<PickingPackingList>();

    public virtual ICollection<ShipmentLog> ShipmentLogs { get; set; }
        = new List<ShipmentLog>();

    public virtual ICollection<BatchTrackTrace> BatchTrackTraces { get; set; }
        = new List<BatchTrackTrace>();
}