using BeyondTheBarcode.Application.DTOs.BillOfMaterialsBomDtos;
using BeyondTheBarcode.Application.Interfaces;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class BillOfMaterialsBomService : IBillOfMaterialsBomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BillOfMaterialsBomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetAllAsync()
        {
            var boms = await _unitOfWork.BillOfMaterialsBoms.GetAllAsync();
            return boms.Select(MapToDto);
        }

        public async Task<BillOfMaterialsBomDto?> GetByIdAsync(int id)
        {
            var bom = await _unitOfWork.BillOfMaterialsBoms.GetByIdAsync(id);

            if (bom == null)
                return null;

            return MapToDto(bom);
        }

        public async Task<BillOfMaterialsBomDto?> GetByVersionAsync(string version)
        {
            var bom = await _unitOfWork.BillOfMaterialsBoms.GetByVersionAsync(version);

            if (bom == null)
                return null;

            return MapToDto(bom);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetByProductAsync(int productId)
        {
            var boms = await _unitOfWork.BillOfMaterialsBoms.GetByProductAsync(productId);
            return boms.Select(MapToDto);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetByRawMaterialAsync(int rawMaterialId)
        {
            var boms = await _unitOfWork.BillOfMaterialsBoms.GetByRawMaterialAsync(rawMaterialId);
            return boms.Select(MapToDto);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> SearchAsync(string keyword)
        {
            var boms = await _unitOfWork.BillOfMaterialsBoms.SearchAsync(keyword);
            return boms.Select(MapToDto);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetActiveAsync()
        {
            var boms = await _unitOfWork.BillOfMaterialsBoms.GetActiveAsync();
            return boms.Select(MapToDto);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetByEffectiveDateAsync(DateOnly fromDate, DateOnly toDate)
        {
            var boms = await _unitOfWork.BillOfMaterialsBoms.GetByEffectiveDateAsync(fromDate, toDate);
            return boms.Select(MapToDto);
        }
        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetCriticalComponentsAsync()
        {
            var boms = await _unitOfWork.BillOfMaterialsBoms.GetCriticalComponentsAsync();
            return boms.Select(MapToDto);
        }

        public async Task<IEnumerable<BillOfMaterialsBomDto>> GetSubstituteAllowedAsync()
        {
            var boms = await _unitOfWork.BillOfMaterialsBoms.GetSubstituteAllowedAsync();
            return boms.Select(MapToDto);
        }

        public async Task<bool> IsBomVersionExistsAsync(string version)
        {
            return await _unitOfWork.BillOfMaterialsBoms.IsBomVersionExistsAsync(version);
        }

        public async Task CreateAsync(CreateBillOfMaterialsBomDto dto)
        {
            var bom = new BillOfMaterialsBom
            {
                ProductId = dto.ProductId,
                Bomversion = dto.Bomversion,
                Bomstatus = dto.Bomstatus,
                RawMaterialId = dto.RawMaterialId,
                QuantityRequired = dto.QuantityRequired,
                Uom = dto.Uom,
                ScrapPercentage = dto.ScrapPercentage,
                EffectiveQty = dto.EffectiveQty,
                ComponentSequence = dto.ComponentSequence,
                IsCritical = dto.IsCritical,
                SubstituteAllowed = dto.SubstituteAllowed,
                SubstituteRawMaterialId = dto.SubstituteRawMaterialId,
                CostContributionPct = dto.CostContributionPct,
                EffectiveFrom = dto.EffectiveFrom,
                EffectiveTo = dto.EffectiveTo,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.BillOfMaterialsBoms.AddAsync(bom);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(UpdateBillOfMaterialsBomDto dto)
        {
            var bom = await _unitOfWork.BillOfMaterialsBoms.GetByIdAsync(dto.Bomid);

            if (bom == null)
                throw new Exception("BOM not found.");

            bom.ProductId = dto.ProductId;
            bom.Bomversion = dto.Bomversion;
            bom.Bomstatus = dto.Bomstatus;
            bom.RawMaterialId = dto.RawMaterialId;
            bom.QuantityRequired = dto.QuantityRequired;
            bom.Uom = dto.Uom;
            bom.ScrapPercentage = dto.ScrapPercentage;
            bom.EffectiveQty = dto.EffectiveQty;
            bom.ComponentSequence = dto.ComponentSequence;
            bom.IsCritical = dto.IsCritical;
            bom.SubstituteAllowed = dto.SubstituteAllowed;
            bom.SubstituteRawMaterialId = dto.SubstituteRawMaterialId;
            bom.CostContributionPct = dto.CostContributionPct;
            bom.EffectiveFrom = dto.EffectiveFrom;
            bom.EffectiveTo = dto.EffectiveTo;
            bom.ApprovedBy = dto.ApprovedBy;
            bom.ApprovedAt = dto.ApprovedAt;
            bom.Remarks = dto.Remarks;
            bom.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.BillOfMaterialsBoms.Update(bom);
            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var bom = await _unitOfWork.BillOfMaterialsBoms.GetByIdAsync(id);

            if (bom == null)
                throw new Exception("BOM not found.");

            _unitOfWork.BillOfMaterialsBoms.Delete(bom);
            await _unitOfWork.SaveAsync();
        }

        private static BillOfMaterialsBomDto MapToDto(BillOfMaterialsBom bom)
        {
            return new BillOfMaterialsBomDto
            {
                Bomid = bom.Bomid,
                ProductId = bom.ProductId,
                Bomversion = bom.Bomversion,
                Bomstatus = bom.Bomstatus,
                RawMaterialId = bom.RawMaterialId,
                QuantityRequired = bom.QuantityRequired,
                Uom = bom.Uom,
                ScrapPercentage = bom.ScrapPercentage,
                EffectiveQty = bom.EffectiveQty,
                ComponentSequence = bom.ComponentSequence,
                IsCritical = bom.IsCritical,
                SubstituteAllowed = bom.SubstituteAllowed,
                SubstituteRawMaterialId = bom.SubstituteRawMaterialId,
                CostContributionPct = bom.CostContributionPct,
                EffectiveFrom = bom.EffectiveFrom,
                EffectiveTo = bom.EffectiveTo,
                ApprovedBy = bom.ApprovedBy,
                ApprovedAt = bom.ApprovedAt,
                Remarks = bom.Remarks,
                CreatedAt = bom.CreatedAt,
                UpdatedAt = bom.UpdatedAt,
            };
        }
    }
}

