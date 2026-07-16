namespace BeyondTheBarcode.Application.DTOs.WarehouseBinDtos;

public class CreateWarehouseBinDto
{
        public string WarehouseName { get; set; } = null!;
        public string Zone { get; set; } = null!;
        public string Row { get; set; } = null!;
        public string Level { get; set; } = null!;
        public string BinCode { get; set; } = null!;
        public string BinType { get; set; } = null!;
        public decimal MaxWeightCapacityKg { get; set; }
        public decimal MaxVolumeCapacityCbm { get; set; }
        public decimal? CurrentWeightUsedKg { get; set; }
        public decimal? CurrentVolumeUsedCbm { get; set; }
        public decimal? MinTemperatureC { get; set; }
        public decimal? MaxTemperatureC { get; set; }
        public string? TemperatureZone { get; set; }
        public string BinStatus { get; set; } = null!;
        public bool IsActive { get; set; }
        public string? Remarks { get; set; }
}
