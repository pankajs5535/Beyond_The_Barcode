using System;
using System.Collections.Generic;

namespace BeyondTheBarcode.Domain.Entities;

/*
BUSINESS PURPOSE
Represents the shipment and delivery of finished tobacco
products to customers.

RELATIONSHIP
- Belongs to one Sales Order.
- Belongs to one Picking & Packing List.
- Referenced in Batch Track & Trace.
*/

public partial class ShipmentLog
{
    // =========================
    // Primary Key
    // =========================
    public int ShipmentId { get; set; }

    // =========================
    // Shipment Information
    // =========================
    public string ShipmentNumber { get; set; } = null!;

    public int SalesOrderId { get; set; }

    public int PickPackId { get; set; }

    public string ShipmentType { get; set; } = null!;

    public string ShipmentStatus { get; set; } = null!;

    // =========================
    // Dispatch Information
    // =========================
    public DateTime DispatchDateTime { get; set; }

    public DateTime? ExpectedDeliveryDateTime { get; set; }

    public DateTime? ActualDeliveryDateTime { get; set; }

    // =========================
    // Transport Information
    // =========================
    public string? TransportMode { get; set; }

    public string? TransporterName { get; set; }

    public string? VehicleNumber { get; set; }

    public string? DriverName { get; set; }

    public string? DriverMobile { get; set; }

    public string? Lrnumber { get; set; }

    // =========================
    // Shipping Documents
    // =========================
    public string? InvoiceNumber { get; set; }

    public string? EwayBillNumber { get; set; }

    public string? DispatchLocation { get; set; }

    public string? DeliveryLocation { get; set; }

    // =========================
    // Weight Information
    // =========================
    public decimal? GrossWeightKg { get; set; }

    public decimal? NetWeightKg { get; set; }

    public decimal? FreightCharges { get; set; }

    // =========================
    // Delivery
    // =========================
    public string? ReceiverName { get; set; }

    public string? ReceiverSignature { get; set; }

    public string? DeliveryRemarks { get; set; }

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

    public virtual SalesOrder SalesOrder { get; set; } = null!;

    public virtual PickingPackingList PickPack { get; set; } = null!;

    public virtual ICollection<BatchTrackTrace> BatchTrackTraces { get; set; }
        = new List<BatchTrackTrace>();
}