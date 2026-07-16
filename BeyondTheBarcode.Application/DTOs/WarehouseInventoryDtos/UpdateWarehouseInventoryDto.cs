namespace BeyondTheBarcode.Application.DTOs.WarehouseInventoryDtos;

public class UpdateWarehouseInventoryDto
{
        public int InventoryId { get; set; }
        public int BinId { get; set; }
        public string ItemType { get; set; } = null!;
        public int? ProductId { get; set; }
        public int? RawMaterialId { get; set; }
        public string BatchNumber { get; set; } = null!;
        public string? LotNumber { get; set; }
        public decimal Quantity { get; set; }
        public string Uom { get; set; } = null!;
        public decimal ReservedQty { get; set; }
        public decimal? AvailableQty { get; set; }
        public decimal DamagedQty { get; set; }
        public decimal QuarantineQty { get; set; }
        public DateOnly? ManufacturingDate { get; set; }
        public DateOnly? ExpiryDate { get; set; }
        public decimal UnitCost { get; set; }
        public decimal? TotalValue { get; set; }
        public string ValuationMethod { get; set; } = null!;
        public string InventoryStatus { get; set; } = null!;
        public string? QcreleaseRef { get; set; }
        public string? Grnreference { get; set; }
        public DateOnly? LastCycleCountDate { get; set; }
        public decimal? LastCycleCountQty { get; set; }
        public decimal? VarianceQty { get; set; }
}
