using BeyondTheBarcode.Application.DTOs.WarehouseBinDtos;
using BeyondTheBarcode.Application.Interfaces;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class WarehouseBinService : IWarehouseBinService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseBinService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all Warehouse Bins
        public async Task<IEnumerable<WarehouseBinDto>> GetAllAsync()
        {
            var bins = await _unitOfWork.WarehouseBins.GetAllAsync();
            return bins.Select(MapToDto);
        }

        // Get Warehouse Bin by Id
        public async Task<WarehouseBinDto?> GetByIdAsync(int id)
        {
            var bin = await _unitOfWork.WarehouseBins.GetByIdAsync(id);

            if (bin == null)
                return null;

            return MapToDto(bin);
        }

        // Get Warehouse Bin by Code
        public async Task<WarehouseBinDto?> GetByCodeAsync(string binCode)
        {
            var bin = await _unitOfWork.WarehouseBins.GetByCodeAsync(binCode);

            if (bin == null)
                return null;

            return MapToDto(bin);
        }

        // Get Warehouse Bins by Warehouse
        public async Task<IEnumerable<WarehouseBinDto>> GetByWarehouseAsync(string warehouse)
        {
            var bins = await _unitOfWork.WarehouseBins.GetByWarehouseAsync(warehouse);
            return bins.Select(MapToDto);
        }

        // Search Warehouse Bins
        public async Task<IEnumerable<WarehouseBinDto>> SearchAsync(string keyword)
        {
            var bins = await _unitOfWork.WarehouseBins.SearchAsync(keyword);
            return bins.Select(MapToDto);
        }

        // Get Active Warehouse Bins
        public async Task<IEnumerable<WarehouseBinDto>> GetActiveAsync()
        {
            var bins = await _unitOfWork.WarehouseBins.GetActiveAsync();
            return bins.Select(MapToDto);
        }

        // Get Inactive Warehouse Bins
        public async Task<IEnumerable<WarehouseBinDto>> GetInactiveAsync()
        {
            var bins = await _unitOfWork.WarehouseBins.GetInactiveAsync();
            return bins.Select(MapToDto);
        }

      

        // Check Bin Code Exists
        public async Task<bool> IsBinCodeExistsAsync(string binCode)
        {
            return await _unitOfWork.WarehouseBins.IsBinCodeExistsAsync(binCode);
        }

        // Create Warehouse Bin
        public async Task CreateAsync(CreateWarehouseBinDto dto)
        {
            var bin = new WarehouseBin
            {
                WarehouseName = dto.WarehouseName,
                Zone = dto.Zone,
                Row = dto.Row,
                Level = dto.Level,
                BinCode = dto.BinCode,
                BinType = dto.BinType,
                MaxWeightCapacityKg = dto.MaxWeightCapacityKg,
                MaxVolumeCapacityCbm = dto.MaxVolumeCapacityCbm,
                CurrentWeightUsedKg = dto.CurrentWeightUsedKg,
                CurrentVolumeUsedCbm = dto.CurrentVolumeUsedCbm,
                MinTemperatureC = dto.MinTemperatureC,
                MaxTemperatureC = dto.MaxTemperatureC,
                TemperatureZone = dto.TemperatureZone,
                BinStatus = dto.BinStatus,
                IsActive = dto.IsActive,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.WarehouseBins.AddAsync(bin);
            await _unitOfWork.SaveAsync();
        }

        // Update Warehouse Bin
        public async Task UpdateAsync(UpdateWarehouseBinDto dto)
        {
            var bin = await _unitOfWork.WarehouseBins.GetByIdAsync(dto.BinId);

            if (bin == null)
                throw new Exception("Warehouse Bin not found.");

            bin.WarehouseName = dto.WarehouseName;
            bin.Zone = dto.Zone;
            bin.Row = dto.Row;
            bin.Level = dto.Level;
            bin.BinCode = dto.BinCode;
            bin.BinType = dto.BinType;
            bin.MaxWeightCapacityKg = dto.MaxWeightCapacityKg;
            bin.MaxVolumeCapacityCbm = dto.MaxVolumeCapacityCbm;
            bin.CurrentWeightUsedKg = dto.CurrentWeightUsedKg;
            bin.CurrentVolumeUsedCbm = dto.CurrentVolumeUsedCbm;
            bin.MinTemperatureC = dto.MinTemperatureC;
            bin.MaxTemperatureC = dto.MaxTemperatureC;
            bin.TemperatureZone = dto.TemperatureZone;
            bin.BinStatus = dto.BinStatus;
            bin.IsActive = dto.IsActive;
            bin.Remarks = dto.Remarks;
            bin.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.WarehouseBins.Update(bin);
            await _unitOfWork.SaveAsync();
        }

        // Delete Warehouse Bin
        public async Task DeleteAsync(int id)
        {
            var bin = await _unitOfWork.WarehouseBins.GetByIdAsync(id);

            if (bin == null)
                throw new Exception("Warehouse Bin not found.");

            _unitOfWork.WarehouseBins.Delete(bin);
            await _unitOfWork.SaveAsync();
        }

        // Map Entity to DTO
        private static WarehouseBinDto MapToDto(WarehouseBin bin)
        {
            return new WarehouseBinDto
            {
                BinId = bin.BinId,
                WarehouseName = bin.WarehouseName,
                Zone = bin.Zone,
                Row = bin.Row,
                Level = bin.Level,
                BinCode = bin.BinCode,
                BinType = bin.BinType,
                MaxWeightCapacityKg = bin.MaxWeightCapacityKg,
                MaxVolumeCapacityCbm = bin.MaxVolumeCapacityCbm,
                CurrentWeightUsedKg = bin.CurrentWeightUsedKg,
                CurrentVolumeUsedCbm = bin.CurrentVolumeUsedCbm,
                MinTemperatureC = bin.MinTemperatureC,
                MaxTemperatureC = bin.MaxTemperatureC,
                TemperatureZone = bin.TemperatureZone,
                BinStatus = bin.BinStatus,
                IsActive = bin.IsActive,
                Remarks = bin.Remarks,
                CreatedAt = bin.CreatedAt,
                UpdatedAt = bin.UpdatedAt,
                CreatedBy = bin.CreatedBy,
                UpdatedBy = bin.UpdatedBy
            };
        }

    }
}