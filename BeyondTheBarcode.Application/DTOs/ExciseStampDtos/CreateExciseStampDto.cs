namespace BeyondTheBarcode.Application.DTOs.ExciseStampDtos;

public class CreateExciseStampDto
{
        public string StampSerialNumber { get; set; } = null!;
        public string? StampSeriesFrom { get; set; }
        public string? StampSeriesTo { get; set; }
        public string StampType { get; set; } = null!;
        public string? StampDenomination { get; set; }
        public string? StampFormat { get; set; }
        public int ProductId { get; set; }
        public string? BatchNumber { get; set; }
        public string? SupplierRef { get; set; }
        public string? GovernmentOrderRef { get; set; }
        public string? LicenseNumber { get; set; }
        public string? ExciseOfficerRef { get; set; }
        public DateOnly ReceivedDate { get; set; }
        public int ReceivedQty { get; set; }
        public DateOnly? ApplicationDate { get; set; }
        public int? AppliedToProductionOrderId { get; set; }
        public int? AppliedQty { get; set; }
        public int? RemainingQty { get; set; }
        public int? DamagedQty { get; set; }
        public string Status { get; set; } = null!;
        public decimal DutyAmountPerStamp { get; set; }
        public decimal? TotalDutyAmount { get; set; }
        public decimal? AppliedDutyAmount { get; set; }
        public decimal? CessAmountPerStamp { get; set; }
        public string? PaymentChallanRef { get; set; }
        public DateOnly? PaymentDate { get; set; }
        public string? ReturnFiledRef { get; set; }
        public DateOnly? ReturnFiledDate { get; set; }
        public int? StorageLocationBinId { get; set; }
        public string? Remarks { get; set; }
}
