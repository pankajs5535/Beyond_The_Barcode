namespace BeyondTheBarcode.Application.DTOs.PickingPackingListDtos;

public class UpdatePickingPackingListDto
{
        public int PickPackId { get; set; }
        public string PickPackNumber { get; set; } = null!;
        public int SalesOrderId { get; set; }
        public string PickPackType { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int? AssignedToPickerId { get; set; }
        public DateTime? PickingStartedAt { get; set; }
        public DateTime? PickingCompletedAt { get; set; }
        public DateTime? PackingStartedAt { get; set; }
        public DateTime? PackingCompletedAt { get; set; }
        public int BinId { get; set; }
        public int ProductId { get; set; }
        public string BatchNumber { get; set; } = null!;
        public string? LotNumber { get; set; }
        public decimal RequestedQty { get; set; }
        public decimal? PickedQty { get; set; }
        public decimal? PackedQty { get; set; }
        public decimal? ShortQty { get; set; }
        public string UnitOfMeasure { get; set; } = null!;
        public string? PackagingMaterial { get; set; }
        public int? CartonCount { get; set; }
        public string? CartonNumbers { get; set; }
        public string? PalletNumber { get; set; }
        public decimal? TotalGrossWeightKg { get; set; }
        public decimal? TotalNetWeightKg { get; set; }
        public decimal? TotalVolumeM3 { get; set; }
        public string? SealNumber { get; set; }
        public decimal? TemperatureAtPacking { get; set; }
        public decimal? HumidityAtPacking { get; set; }
        public int? QcverifiedBy { get; set; }
        public DateTime? QcverifiedAt { get; set; }
        public string? QcverificationStatus { get; set; }
        public string? Qcremarks { get; set; }
        public DateTime? DispatchReadyAt { get; set; }
        public string? Remarks { get; set; }
}
