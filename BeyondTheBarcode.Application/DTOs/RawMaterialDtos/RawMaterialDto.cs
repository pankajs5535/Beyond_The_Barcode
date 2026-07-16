namespace BeyondTheBarcode.Application.DTOs.RawMaterialDtos;

public class RawMaterialDto
{
        public int RawMaterialId { get; set; }
        public string MaterialCode { get; set; } = null!;
        public string MaterialName { get; set; } = null!;
        public string MaterialType { get; set; } = null!;
        public string? Grade { get; set; }
        public string? Specification { get; set; }
        public string Uom { get; set; } = null!;
        public decimal MinStockLevel { get; set; }
        public decimal MaxStockLevel { get; set; }
        public decimal ReorderPoint { get; set; }
        public decimal CurrentStock { get; set; }
        public decimal UnitCost { get; set; }
        public int? PrimarySupplierId { get; set; }
        public string? StorageConditions { get; set; }
        public string? HazardClassification { get; set; }
        public bool IsControlledSubstance { get; set; }
        public int? ShelfLifeDays { get; set; }
        public string? Hsncode { get; set; }
        public string? CountryOfOrigin { get; set; }
        public string? QualityStandard { get; set; }
        public DateOnly? LastReceivedDate { get; set; }
        public decimal? LastReceivedQty { get; set; }
        public bool IsActive { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
}
