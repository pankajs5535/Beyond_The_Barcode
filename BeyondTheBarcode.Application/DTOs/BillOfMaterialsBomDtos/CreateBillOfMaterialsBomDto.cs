namespace BeyondTheBarcode.Application.DTOs.BillOfMaterialsBomDtos;

public class CreateBillOfMaterialsBomDto
{
        public int ProductId { get; set; }
        public string Bomversion { get; set; } = null!;
        public string Bomstatus { get; set; } = null!;
        public int RawMaterialId { get; set; }
        public decimal QuantityRequired { get; set; }
        public string Uom { get; set; } = null!;
        public decimal ScrapPercentage { get; set; }
        public decimal? EffectiveQty { get; set; }
        public int? ComponentSequence { get; set; }
        public bool IsCritical { get; set; }
        public bool SubstituteAllowed { get; set; }
        public int? SubstituteRawMaterialId { get; set; }
        public decimal? CostContributionPct { get; set; }
        public DateOnly EffectiveFrom { get; set; }
        public DateOnly? EffectiveTo { get; set; }
        public string? Remarks { get; set; }
}
