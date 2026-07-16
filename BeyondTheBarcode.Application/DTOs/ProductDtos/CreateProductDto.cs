namespace BeyondTheBarcode.Application.DTOs.ProductDtos;

public class CreateProductDto
{
        public string ProductCode { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? SubCategory { get; set; }
        public string? Description { get; set; }
        public string? NicotineContent { get; set; }
        public string? TarContent { get; set; }
        public string? FilterType { get; set; }
        public decimal? CigaretteLengthMm { get; set; }
        public decimal? CigaretteDiameterMm { get; set; }
        public string? PackagingType { get; set; }
        public int UnitsPerPack { get; set; }
        public int PacksPerCarton { get; set; }
        public int CartonsPerMasterCarton { get; set; }
        public decimal UnitCostPrice { get; set; }
        public decimal UnitSalePrice { get; set; }
        public decimal? Mrp { get; set; }
        public decimal ExciseDutyRate { get; set; }
        public string ExciseDutyBasis { get; set; } = null!;
        public decimal Gstrate { get; set; }
        public decimal? CompensationCessRate { get; set; }
        public string? Hsncode { get; set; }
        public string CountryOfOrigin { get; set; } = null!;
        public string? RegulatoryApprovalRef { get; set; }
        public bool HealthWarningRequired { get; set; }
        public string? HealthWarningText { get; set; }
        public bool IsExportProduct { get; set; }
        public bool IsActive { get; set; }
        public DateOnly? DiscontinuedDate { get; set; }
        public string? Remarks { get; set; }
}
