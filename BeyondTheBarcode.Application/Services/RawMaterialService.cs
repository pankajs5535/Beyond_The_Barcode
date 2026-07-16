using BeyondTheBarcode.Application.DTOs.RawMaterialDtos;
using BeyondTheBarcode.Application.Interfaces;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class RawMaterialService : IRawMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RawMaterialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RawMaterialDto>> GetAllAsync()
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetAllAsync();
            return rawMaterials.Select(MapToDto);
        }

        public async Task<RawMaterialDto?> GetByIdAsync(int id)
        {
            var rawMaterial = await _unitOfWork.RawMaterials.GetByIdAsync(id);

            if (rawMaterial == null)
                return null;

            return MapToDto(rawMaterial);
        }

        public async Task<RawMaterialDto?> GetByCodeAsync(string code)
        {
            var rawMaterial = await _unitOfWork.RawMaterials.GetByCodeAsync(code);

            if (rawMaterial == null)
                return null;

            return MapToDto(rawMaterial);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetByTypeAsync(string type)
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetByTypeAsync(type);
            return rawMaterials.Select(MapToDto);
        }

        public async Task<IEnumerable<RawMaterialDto>> SearchAsync(string keyword)
        {
            var rawMaterials = await _unitOfWork.RawMaterials.SearchAsync(keyword);
            return rawMaterials.Select(MapToDto);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetActiveAsync()
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetActiveAsync();
            return rawMaterials.Select(MapToDto);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetInactiveAsync()
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetInactiveAsync();
            return rawMaterials.Select(MapToDto);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetByDateRangeAsync(fromDate, toDate);
            return rawMaterials.Select(MapToDto);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetLowStockAsync()
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetLowStockAsync();
            return rawMaterials.Select(MapToDto);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetBySupplierAsync(int supplierId)
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetBySupplierAsync(supplierId);
            return rawMaterials.Select(MapToDto);
        }

        public async Task<IEnumerable<RawMaterialDto>> GetControlledSubstancesAsync()
        {
            var rawMaterials = await _unitOfWork.RawMaterials.GetControlledSubstancesAsync();
            return rawMaterials.Select(MapToDto);
        }

        public async Task<bool> IsMaterialCodeExistsAsync(string materialCode)
        {
            return await _unitOfWork.RawMaterials.IsMaterialCodeExistsAsync(materialCode);
        }

        public async Task CreateAsync(CreateRawMaterialDto dto)
        {
            var rawMaterial = new RawMaterial
            {
                MaterialCode = dto.MaterialCode,
                MaterialName = dto.MaterialName,
                MaterialType = dto.MaterialType,
                Grade = dto.Grade,
                Specification = dto.Specification,
                Uom = dto.Uom,
                MinStockLevel = dto.MinStockLevel,
                MaxStockLevel = dto.MaxStockLevel,
                ReorderPoint = dto.ReorderPoint,
                CurrentStock = dto.CurrentStock,
                UnitCost = dto.UnitCost,
                PrimarySupplierId = dto.PrimarySupplierId,
                StorageConditions = dto.StorageConditions,
                HazardClassification = dto.HazardClassification,
                IsControlledSubstance = dto.IsControlledSubstance,
                ShelfLifeDays = dto.ShelfLifeDays,
                Hsncode = dto.Hsncode,
                CountryOfOrigin = dto.CountryOfOrigin,
                QualityStandard = dto.QualityStandard,
                LastReceivedDate = dto.LastReceivedDate,
                LastReceivedQty = dto.LastReceivedQty,
                IsActive = dto.IsActive,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.RawMaterials.AddAsync(rawMaterial);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateRawMaterialDto dto)
        {
            var rawMaterial = await _unitOfWork.RawMaterials.GetByIdAsync(dto.RawMaterialId);

            if (rawMaterial == null)
                throw new Exception("Raw Material not found.");

            rawMaterial.MaterialCode = dto.MaterialCode;
            rawMaterial.MaterialName = dto.MaterialName;
            rawMaterial.MaterialType = dto.MaterialType;
            rawMaterial.Grade = dto.Grade;
            rawMaterial.Specification = dto.Specification;
            rawMaterial.Uom = dto.Uom;
            rawMaterial.MinStockLevel = dto.MinStockLevel;
            rawMaterial.MaxStockLevel = dto.MaxStockLevel;
            rawMaterial.ReorderPoint = dto.ReorderPoint;
            rawMaterial.CurrentStock = dto.CurrentStock;
            rawMaterial.UnitCost = dto.UnitCost;
            rawMaterial.PrimarySupplierId = dto.PrimarySupplierId;
            rawMaterial.StorageConditions = dto.StorageConditions;
            rawMaterial.HazardClassification = dto.HazardClassification;
            rawMaterial.IsControlledSubstance = dto.IsControlledSubstance;
            rawMaterial.ShelfLifeDays = dto.ShelfLifeDays;
            rawMaterial.Hsncode = dto.Hsncode;
            rawMaterial.CountryOfOrigin = dto.CountryOfOrigin;
            rawMaterial.QualityStandard = dto.QualityStandard;
            rawMaterial.LastReceivedDate = dto.LastReceivedDate;
            rawMaterial.LastReceivedQty = dto.LastReceivedQty;
            rawMaterial.IsActive = dto.IsActive;
            rawMaterial.Remarks = dto.Remarks;
            rawMaterial.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.RawMaterials.Update(rawMaterial);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rawMaterial = await _unitOfWork.RawMaterials.GetByIdAsync(id);

            if (rawMaterial == null)
                throw new Exception("Raw Material not found.");

            _unitOfWork.RawMaterials.Delete(rawMaterial);
            await _unitOfWork.SaveAsync();
        }

        private static RawMaterialDto MapToDto(RawMaterial rawMaterial)
        {
            return new RawMaterialDto
            {
                RawMaterialId = rawMaterial.RawMaterialId,
                MaterialCode = rawMaterial.MaterialCode,
                MaterialName = rawMaterial.MaterialName,
                MaterialType = rawMaterial.MaterialType,
                Grade = rawMaterial.Grade,
                Specification = rawMaterial.Specification,
                Uom = rawMaterial.Uom,
                MinStockLevel = rawMaterial.MinStockLevel,
                MaxStockLevel = rawMaterial.MaxStockLevel,
                ReorderPoint = rawMaterial.ReorderPoint,
                CurrentStock = rawMaterial.CurrentStock,
                UnitCost = rawMaterial.UnitCost,
                PrimarySupplierId = rawMaterial.PrimarySupplierId,
                StorageConditions = rawMaterial.StorageConditions,
                HazardClassification = rawMaterial.HazardClassification,
                IsControlledSubstance = rawMaterial.IsControlledSubstance,
                ShelfLifeDays = rawMaterial.ShelfLifeDays,
                Hsncode = rawMaterial.Hsncode,
                CountryOfOrigin = rawMaterial.CountryOfOrigin,
                QualityStandard = rawMaterial.QualityStandard,
                LastReceivedDate = rawMaterial.LastReceivedDate,
                LastReceivedQty = rawMaterial.LastReceivedQty,
                IsActive = rawMaterial.IsActive,
                Remarks = rawMaterial.Remarks,
                CreatedAt = rawMaterial.CreatedAt,
                UpdatedAt = rawMaterial.UpdatedAt,
                CreatedBy = rawMaterial.CreatedBy,
                UpdatedBy = rawMaterial.UpdatedBy
            };
        }
    }
}