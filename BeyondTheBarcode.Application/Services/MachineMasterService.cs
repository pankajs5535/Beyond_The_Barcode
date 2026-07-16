using BeyondTheBarcode.Application.DTOs.MachineMasterDtos;
using BeyondTheBarcode.Application.Interfaces;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class MachineMasterService : IMachineMasterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MachineMasterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MachineMasterDto>> GetAllAsync()
        {
            var machines = await _unitOfWork.MachineMasters.GetAllAsync();
            return machines.Select(MapToDto);
        }

        public async Task<MachineMasterDto?> GetByIdAsync(int id)
        {
            var machine = await _unitOfWork.MachineMasters.GetByIdAsync(id);

            if (machine == null)
                return null;

            return MapToDto(machine);
        }

        public async Task<MachineMasterDto?> GetByCodeAsync(string code)
        {
            var machine = await _unitOfWork.MachineMasters.GetByCodeAsync(code);

            if (machine == null)
                return null;

            return MapToDto(machine);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetByTypeAsync(string type)
        {
            var machines = await _unitOfWork.MachineMasters.GetByTypeAsync(type);
            return machines.Select(MapToDto);
        }

        public async Task<IEnumerable<MachineMasterDto>> SearchAsync(string keyword)
        {
            var machines = await _unitOfWork.MachineMasters.SearchAsync(keyword);
            return machines.Select(MapToDto);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetActiveAsync()
        {
            var machines = await _unitOfWork.MachineMasters.GetActiveAsync();
            return machines.Select(MapToDto);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetInactiveAsync()
        {
            var machines = await _unitOfWork.MachineMasters.GetInactiveAsync();
            return machines.Select(MapToDto);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetByStatusAsync(string status)
        {
            var machines = await _unitOfWork.MachineMasters.GetByStatusAsync(status);
            return machines.Select(MapToDto);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetMaintenanceDueAsync()
        {
            var machines = await _unitOfWork.MachineMasters.GetMaintenanceDueAsync();
            return machines.Select(MapToDto);
        }

        public async Task<IEnumerable<MachineMasterDto>> GetByPlantAsync(string plant)
        {
            var machines = await _unitOfWork.MachineMasters.GetByPlantAsync(plant);
            return machines.Select(MapToDto);
        }

        public async Task<bool> IsMachineCodeExistsAsync(string machineCode)
        {
            return await _unitOfWork.MachineMasters.IsMachineCodeExistsAsync(machineCode);
        }

        public async Task CreateAsync(CreateMachineMasterDto dto)
        {
            var machine = new MachineMaster
            {
                MachineCode = dto.MachineCode,
                MachineName = dto.MachineName,
                MachineType = dto.MachineType,
                Manufacturer = dto.Manufacturer,
                ModelNumber = dto.ModelNumber,
                SerialNumber = dto.SerialNumber,
                AssetTagNumber = dto.AssetTagNumber,
                PlantName = dto.PlantName,
                BuildingName = dto.BuildingName,
                FloorNumber = dto.FloorNumber,
                LineNumber = dto.LineNumber,
                ProductionCapacity = dto.ProductionCapacity,
                CapacityUom = dto.CapacityUom,
                InstallationDate = dto.InstallationDate,
                LastMaintenanceDate = dto.LastMaintenanceDate,
                NextMaintenanceDate = dto.NextMaintenanceDate,
                MaintenanceFrequency = dto.MaintenanceFrequency,
                MaintenanceVendor = dto.MaintenanceVendor,
                AmccontractRef = dto.AmccontractRef,
                PurchaseCost = dto.PurchaseCost,
                DepreciationRate = dto.DepreciationRate,
                InsuranceRef = dto.InsuranceRef,
                CurrentStatus = dto.CurrentStatus,
                IsActive = dto.IsActive,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.MachineMasters.AddAsync(machine);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateMachineMasterDto dto)
        {
            var machine = await _unitOfWork.MachineMasters.GetByIdAsync(dto.MachineId);

            if (machine == null)
                throw new Exception("Machine not found.");

            machine.MachineCode = dto.MachineCode;
            machine.MachineName = dto.MachineName;
            machine.MachineType = dto.MachineType;
            machine.Manufacturer = dto.Manufacturer;
            machine.ModelNumber = dto.ModelNumber;
            machine.SerialNumber = dto.SerialNumber;
            machine.AssetTagNumber = dto.AssetTagNumber;
            machine.PlantName = dto.PlantName;
            machine.BuildingName = dto.BuildingName;
            machine.FloorNumber = dto.FloorNumber;
            machine.LineNumber = dto.LineNumber;
            machine.ProductionCapacity = dto.ProductionCapacity;
            machine.CapacityUom = dto.CapacityUom;
            machine.InstallationDate = dto.InstallationDate;
            machine.LastMaintenanceDate = dto.LastMaintenanceDate;
            machine.NextMaintenanceDate = dto.NextMaintenanceDate;
            machine.MaintenanceFrequency = dto.MaintenanceFrequency;
            machine.MaintenanceVendor = dto.MaintenanceVendor;
            machine.AmccontractRef = dto.AmccontractRef;
            machine.PurchaseCost = dto.PurchaseCost;
            machine.DepreciationRate = dto.DepreciationRate;
            machine.InsuranceRef = dto.InsuranceRef;
            machine.CurrentStatus = dto.CurrentStatus;
            machine.IsActive = dto.IsActive;
            machine.Remarks = dto.Remarks;
            machine.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.MachineMasters.Update(machine);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var machine = await _unitOfWork.MachineMasters.GetByIdAsync(id);

            if (machine == null)
                throw new Exception("Machine not found.");

            _unitOfWork.MachineMasters.Delete(machine);
            await _unitOfWork.SaveAsync();
        }

        private static MachineMasterDto MapToDto(MachineMaster machine)
        {
            return new MachineMasterDto
            {
                MachineId = machine.MachineId,
                MachineCode = machine.MachineCode,
                MachineName = machine.MachineName,
                MachineType = machine.MachineType,
                Manufacturer = machine.Manufacturer,
                ModelNumber = machine.ModelNumber,
                SerialNumber = machine.SerialNumber,
                AssetTagNumber = machine.AssetTagNumber,
                PlantName = machine.PlantName,
                BuildingName = machine.BuildingName,
                FloorNumber = machine.FloorNumber,
                LineNumber = machine.LineNumber,
                ProductionCapacity = machine.ProductionCapacity,
                CapacityUom = machine.CapacityUom,
                InstallationDate = machine.InstallationDate,
                LastMaintenanceDate = machine.LastMaintenanceDate,
                NextMaintenanceDate = machine.NextMaintenanceDate,
                MaintenanceFrequency = machine.MaintenanceFrequency,
                MaintenanceVendor = machine.MaintenanceVendor,
                AmccontractRef = machine.AmccontractRef,
                PurchaseCost = machine.PurchaseCost,
                DepreciationRate = machine.DepreciationRate,
                InsuranceRef = machine.InsuranceRef,
                CurrentStatus = machine.CurrentStatus,
                IsActive = machine.IsActive,
                Remarks = machine.Remarks,
                CreatedAt = machine.CreatedAt,
                UpdatedAt = machine.UpdatedAt,
                CreatedBy = machine.CreatedBy,
                UpdatedBy = machine.UpdatedBy
            };
        }
    }
}