namespace BeyondTheBarcode.Application.DTOs.QualityControlLogDtos;

public class CreateQualityControlLogDto
{
        public string QcreferenceNumber { get; set; } = null!;
        public string InspectionType { get; set; } = null!;
        public int? ProductionOrderId { get; set; }
        public int? ProductId { get; set; }
        public int? RawMaterialId { get; set; }
        public string BatchNumber { get; set; } = null!;
        public string? LotNumber { get; set; }
        public string? SamplingStandard { get; set; }
        public int InspectorId { get; set; }
        public DateTime InspectionDateTime { get; set; }
        public decimal SampleSize { get; set; }
        public decimal PassedQty { get; set; }
        public decimal FailedQty { get; set; }
        public decimal? MoistureContentPct { get; set; }
        public decimal? MoistureSpecMin { get; set; }
        public decimal? MoistureSpecMax { get; set; }
        public decimal? NicotineLevelMg { get; set; }
        public decimal? NicotineSpecMin { get; set; }
        public decimal? NicotineSpecMax { get; set; }
        public decimal? TarLevelMg { get; set; }
        public decimal? TarSpecMin { get; set; }
        public decimal? TarSpecMax { get; set; }
        public decimal? DrawResistancePa { get; set; }
        public decimal? DrawResistanceSpecMin { get; set; }
        public decimal? DrawResistanceSpecMax { get; set; }
        public decimal? CigaretteDiameterMm { get; set; }
        public decimal? CigaretteLengthMm { get; set; }
        public decimal? PackWeightGm { get; set; }
        public decimal? TensileStrength { get; set; }
        public decimal? VentilationPct { get; set; }
        public string? PrintingQualityResult { get; set; }
        public bool? HealthWarningPresent { get; set; }
        public bool? BarcodeVerified { get; set; }
        public string OverallResult { get; set; } = null!;
        public string? FailureMode { get; set; }
        public string? DefectCategory { get; set; }
        public string? Ncrnumber { get; set; }
        public string? CorrectiveAction { get; set; }
        public string? PreventiveAction { get; set; }
        public bool IsReleased { get; set; }
        public int? ReleasedBy { get; set; }
        public DateTime? ReleasedAt { get; set; }
        public string? TestReportAttachment { get; set; }
        public string? Remarks { get; set; }
}
