namespace BeyondTheBarcode.Application.DTOs.MachineMasterDtos;

public class UpdateMachineMasterDto
{
        public int MachineId { get; set; }
        public string MachineCode { get; set; } = null!;
        public string MachineName { get; set; } = null!;
        public string MachineType { get; set; } = null!;
        public string? Manufacturer { get; set; }
        public string? ModelNumber { get; set; }
        public string? SerialNumber { get; set; }
        public string? AssetTagNumber { get; set; }
        public string? PlantName { get; set; }
        public string? BuildingName { get; set; }
        public string? FloorNumber { get; set; }
        public string? LineNumber { get; set; }
        public decimal ProductionCapacity { get; set; }
        public string CapacityUom { get; set; } = null!;
        public DateOnly? InstallationDate { get; set; }
        public DateOnly? LastMaintenanceDate { get; set; }
        public DateOnly? NextMaintenanceDate { get; set; }
        public string? MaintenanceFrequency { get; set; }
        public string? MaintenanceVendor { get; set; }
        public string? AmccontractRef { get; set; }
        public decimal? PurchaseCost { get; set; }
        public decimal? DepreciationRate { get; set; }
        public string? InsuranceRef { get; set; }
        public string CurrentStatus { get; set; } = null!;
        public bool IsActive { get; set; }
        public string? Remarks { get; set; }
}
