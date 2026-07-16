namespace BeyondTheBarcode.Application.DTOs.ProductionOrderDtos;

public class ProductionOrderDto
{
        public int ProductionOrderId { get; set; }
        public string OrderNumber { get; set; } = null!;
        public int ProductId { get; set; }
        public int Bomid { get; set; }
        public string OrderType { get; set; } = null!;
        public decimal PlannedQty { get; set; }
        public decimal? ActualQty { get; set; }
        public decimal? RejectedQty { get; set; }
        public decimal? YieldPercentage { get; set; }
        public string Status { get; set; } = null!;
        public byte Priority { get; set; }
        public DateOnly PlannedStartDate { get; set; }
        public DateOnly PlannedEndDate { get; set; }
        public DateOnly? ActualStartDate { get; set; }
        public DateOnly? ActualEndDate { get; set; }
        public int? MachineId { get; set; }
        public int? OperatorId { get; set; }
        public string? ShiftCode { get; set; }
        public string BatchNumber { get; set; } = null!;
        public string? LotNumber { get; set; }
        public decimal? PlannedLaborHours { get; set; }
        public decimal? ActualLaborHours { get; set; }
        public decimal? LaborCostPlanned { get; set; }
        public decimal? LaborCostActual { get; set; }
        public decimal? MaterialCostPlanned { get; set; }
        public decimal? MaterialCostActual { get; set; }
        public decimal? OverheadCostPlanned { get; set; }
        public decimal? OverheadCostActual { get; set; }
        public decimal? TotalCostActual { get; set; }
        public string? ReasonForDeviation { get; set; }
        public string? SalesOrderRef { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public int? ClosedBy { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
}
