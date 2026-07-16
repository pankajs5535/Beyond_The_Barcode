using BeyondTheBarcode.Application.DTOs.ExciseStampDtos;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class ExciseStampService : IExciseStampService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExciseStampService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all Excise Stamps
        public async Task<IEnumerable<ExciseStampDto>> GetAllAsync()
        {
            var stamps = await _unitOfWork.ExciseStamps.GetAllAsync();
            return stamps.Select(MapToDto);
        }

        // Get Excise Stamp by Id
        public async Task<ExciseStampDto?> GetByIdAsync(int id)
        {
            var stamp = await _unitOfWork.ExciseStamps.GetByIdAsync(id);

            if (stamp == null)
                return null;

            return MapToDto(stamp);
        }

        // Get Excise Stamp by Serial Number
        public async Task<ExciseStampDto?> GetBySerialNumberAsync(string serialNumber)
        {
            var stamp = await _unitOfWork.ExciseStamps.GetBySerialNumberAsync(serialNumber);

            if (stamp == null)
                return null;

            return MapToDto(stamp);
        }

        // Get Excise Stamps by Product
        public async Task<IEnumerable<ExciseStampDto>> GetByProductAsync(int productId)
        {
            var stamps = await _unitOfWork.ExciseStamps.GetByProductAsync(productId);
            return stamps.Select(MapToDto);
        }

        // Get Excise Stamps by Production Order
        public async Task<IEnumerable<ExciseStampDto>> GetByProductionOrderAsync(int productionOrderId)
        {
            var stamps = await _unitOfWork.ExciseStamps.GetByProductionOrderAsync(productionOrderId);
            return stamps.Select(MapToDto);
        }

        // Search Excise Stamps
        public async Task<IEnumerable<ExciseStampDto>> SearchAsync(string keyword)
        {
            var stamps = await _unitOfWork.ExciseStamps.SearchAsync(keyword);
            return stamps.Select(MapToDto);
        }

        // Get Excise Stamps by Status
        public async Task<IEnumerable<ExciseStampDto>> GetByStatusAsync(string status)
        {
            var stamps = await _unitOfWork.ExciseStamps.GetByStatusAsync(status);
            return stamps.Select(MapToDto);
        }


        // Get Available Excise Stamps
        public async Task<IEnumerable<ExciseStampDto>> GetAvailableAsync()
        {
            var stamps = await _unitOfWork.ExciseStamps.GetAvailableAsync();
            return stamps.Select(MapToDto);
        }

        // Get Applied Excise Stamps
        public async Task<IEnumerable<ExciseStampDto>> GetAppliedAsync()
        {
            var stamps = await _unitOfWork.ExciseStamps.GetAppliedAsync();
            return stamps.Select(MapToDto);
        }

        // Get Excise Stamps by Storage Bin
        public async Task<IEnumerable<ExciseStampDto>> GetByStorageBinAsync(int binId)
        {
            var stamps = await _unitOfWork.ExciseStamps.GetByStorageBinAsync(binId);
            return stamps.Select(MapToDto);
        }

        // Check Serial Number Exists
        public async Task<bool> IsSerialNumberExistsAsync(string serialNumber)
        {
            return await _unitOfWork.ExciseStamps.IsSerialNumberExistsAsync(serialNumber);
        }

        // Create Excise Stamp
        public async Task CreateAsync(CreateExciseStampDto dto)
        {
            var stamp = new ExciseStamp
            {
                StampSerialNumber = dto.StampSerialNumber,
                StampSeriesFrom = dto.StampSeriesFrom,
                StampSeriesTo = dto.StampSeriesTo,
                StampType = dto.StampType,
                StampDenomination = dto.StampDenomination,
                StampFormat = dto.StampFormat,
                ProductId = dto.ProductId,
                BatchNumber = dto.BatchNumber,
                SupplierRef = dto.SupplierRef,
                GovernmentOrderRef = dto.GovernmentOrderRef,
                LicenseNumber = dto.LicenseNumber,
                ExciseOfficerRef = dto.ExciseOfficerRef,
                ReceivedDate = dto.ReceivedDate,
                ReceivedQty = dto.ReceivedQty,
                ApplicationDate = dto.ApplicationDate,
                AppliedToProductionOrderId = dto.AppliedToProductionOrderId,
                AppliedQty = dto.AppliedQty,
                RemainingQty = dto.RemainingQty,
                DamagedQty = dto.DamagedQty,
                Status = dto.Status,
                DutyAmountPerStamp = dto.DutyAmountPerStamp,
                TotalDutyAmount = dto.TotalDutyAmount,
                AppliedDutyAmount = dto.AppliedDutyAmount,
                CessAmountPerStamp = dto.CessAmountPerStamp,
                PaymentChallanRef = dto.PaymentChallanRef,
                PaymentDate = dto.PaymentDate,
                ReturnFiledRef = dto.ReturnFiledRef,
                ReturnFiledDate = dto.ReturnFiledDate,
                StorageLocationBinId = dto.StorageLocationBinId,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.ExciseStamps.AddAsync(stamp);
            await _unitOfWork.SaveAsync();
        }


        // Update Excise Stamp
        public async Task UpdateAsync(UpdateExciseStampDto dto)
        {
            var stamp = await _unitOfWork.ExciseStamps.GetByIdAsync(dto.StampId);

            if (stamp == null)
                throw new Exception("Excise Stamp not found.");

            stamp.StampSerialNumber = dto.StampSerialNumber;
            stamp.StampSeriesFrom = dto.StampSeriesFrom;
            stamp.StampSeriesTo = dto.StampSeriesTo;
            stamp.StampType = dto.StampType;
            stamp.StampDenomination = dto.StampDenomination;
            stamp.StampFormat = dto.StampFormat;
            stamp.ProductId = dto.ProductId;
            stamp.BatchNumber = dto.BatchNumber;
            stamp.SupplierRef = dto.SupplierRef;
            stamp.GovernmentOrderRef = dto.GovernmentOrderRef;
            stamp.LicenseNumber = dto.LicenseNumber;
            stamp.ExciseOfficerRef = dto.ExciseOfficerRef;
            stamp.ReceivedDate = dto.ReceivedDate;
            stamp.ReceivedQty = dto.ReceivedQty;
            stamp.ApplicationDate = dto.ApplicationDate;
            stamp.AppliedToProductionOrderId = dto.AppliedToProductionOrderId;
            stamp.AppliedQty = dto.AppliedQty;
            stamp.RemainingQty = dto.RemainingQty;
            stamp.DamagedQty = dto.DamagedQty;
            stamp.Status = dto.Status;
            stamp.DutyAmountPerStamp = dto.DutyAmountPerStamp;
            stamp.TotalDutyAmount = dto.TotalDutyAmount;
            stamp.AppliedDutyAmount = dto.AppliedDutyAmount;
            stamp.CessAmountPerStamp = dto.CessAmountPerStamp;
            stamp.PaymentChallanRef = dto.PaymentChallanRef;
            stamp.PaymentDate = dto.PaymentDate;
            stamp.ReturnFiledRef = dto.ReturnFiledRef;
            stamp.ReturnFiledDate = dto.ReturnFiledDate;
            stamp.StorageLocationBinId = dto.StorageLocationBinId;
            stamp.Remarks = dto.Remarks;
            stamp.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.ExciseStamps.Update(stamp);
            await _unitOfWork.SaveAsync();
        }

        // Delete Excise Stamp
        public async Task DeleteAsync(int id)
        {
            var stamp = await _unitOfWork.ExciseStamps.GetByIdAsync(id);

            if (stamp == null)
                throw new Exception("Excise Stamp not found.");

            _unitOfWork.ExciseStamps.Delete(stamp);
            await _unitOfWork.SaveAsync();
        }

        // Map Entity to DTO
        private static ExciseStampDto MapToDto(ExciseStamp stamp)
        {
            return new ExciseStampDto
            {
                StampId = stamp.StampId,
                StampSerialNumber = stamp.StampSerialNumber,
                StampSeriesFrom = stamp.StampSeriesFrom,
                StampSeriesTo = stamp.StampSeriesTo,
                StampType = stamp.StampType,
                StampDenomination = stamp.StampDenomination,
                StampFormat = stamp.StampFormat,
                ProductId = stamp.ProductId,
                BatchNumber = stamp.BatchNumber,
                SupplierRef = stamp.SupplierRef,
                GovernmentOrderRef = stamp.GovernmentOrderRef,
                LicenseNumber = stamp.LicenseNumber,
                ExciseOfficerRef = stamp.ExciseOfficerRef,
                ReceivedDate = stamp.ReceivedDate,
                ReceivedQty = stamp.ReceivedQty,
                ApplicationDate = stamp.ApplicationDate,
                AppliedToProductionOrderId = stamp.AppliedToProductionOrderId,
                AppliedQty = stamp.AppliedQty,
                RemainingQty = stamp.RemainingQty,
                DamagedQty = stamp.DamagedQty,
                Status = stamp.Status,
                DutyAmountPerStamp = stamp.DutyAmountPerStamp,
                TotalDutyAmount = stamp.TotalDutyAmount,
                AppliedDutyAmount = stamp.AppliedDutyAmount,
                CessAmountPerStamp = stamp.CessAmountPerStamp,
                PaymentChallanRef = stamp.PaymentChallanRef,
                PaymentDate = stamp.PaymentDate,
                ReturnFiledRef = stamp.ReturnFiledRef,
                ReturnFiledDate = stamp.ReturnFiledDate,
                StorageLocationBinId = stamp.StorageLocationBinId,
                Remarks = stamp.Remarks,
                CreatedAt = stamp.CreatedAt,
                UpdatedAt = stamp.UpdatedAt,
                CreatedBy = stamp.CreatedBy,
                UpdatedBy = stamp.UpdatedBy
            };
        }
    }
}