using BeyondTheBarcode.Application.DTOs.QualityControlLogDtos;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class QualityControlLogService : IQualityControlLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QualityControlLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all QC Records
        public async Task<IEnumerable<QualityControlLogDto>> GetAllAsync()
        {
            var logs = await _unitOfWork.QualityControlLogs.GetAllAsync();
            return logs.Select(MapToDto);
        }

        // Get QC Record by Id
        public async Task<QualityControlLogDto?> GetByIdAsync(int id)
        {
            var log = await _unitOfWork.QualityControlLogs.GetByIdAsync(id);

            if (log == null)
                return null;

            return MapToDto(log);
        }

        // Get QC by Reference Number
        public async Task<QualityControlLogDto?> GetByReferenceAsync(string reference)
        {
            var log = await _unitOfWork.QualityControlLogs.GetByReferenceAsync(reference);

            if (log == null)
                return null;

            return MapToDto(log);
        }

        // Get QC by Production Order
        public async Task<IEnumerable<QualityControlLogDto>> GetByProductionOrderAsync(int productionOrderId)
        {
            var logs = await _unitOfWork.QualityControlLogs.GetByProductionOrderAsync(productionOrderId);
            return logs.Select(MapToDto);
        }

        // Get QC by Product
        public async Task<IEnumerable<QualityControlLogDto>> GetByProductAsync(int productId)
        {
            var logs = await _unitOfWork.QualityControlLogs.GetByProductAsync(productId);
            return logs.Select(MapToDto);
        }

        // Get QC by Raw Material
        public async Task<IEnumerable<QualityControlLogDto>> GetByRawMaterialAsync(int rawMaterialId)
        {
            var logs = await _unitOfWork.QualityControlLogs.GetByRawMaterialAsync(rawMaterialId);
            return logs.Select(MapToDto);
        }

        // Search QC Records
        public async Task<IEnumerable<QualityControlLogDto>> SearchAsync(string keyword)
        {
            var logs = await _unitOfWork.QualityControlLogs.SearchAsync(keyword);
            return logs.Select(MapToDto);
        }

        // Get Released QC Records
        public async Task<IEnumerable<QualityControlLogDto>> GetReleasedAsync()
        {
            var logs = await _unitOfWork.QualityControlLogs.GetReleasedAsync();
            return logs.Select(MapToDto);
        }

        // Get Pending QC Records
        public async Task<IEnumerable<QualityControlLogDto>> GetPendingAsync()
        {
            var logs = await _unitOfWork.QualityControlLogs.GetPendingAsync();
            return logs.Select(MapToDto);
        }

        // Get QC by Result
        public async Task<IEnumerable<QualityControlLogDto>> GetByResultAsync(string result)
        {
            var logs = await _unitOfWork.QualityControlLogs.GetByResultAsync(result);
            return logs.Select(MapToDto);
        }

        // Check QC Reference Exists
        public async Task<bool> IsReferenceExistsAsync(string reference)
        {
            return await _unitOfWork.QualityControlLogs.IsReferenceExistsAsync(reference);
        }

        // Create QC Record
        public async Task CreateAsync(CreateQualityControlLogDto dto)
        {
            var log = new QualityControlLog
            {
                QcreferenceNumber = dto.QcreferenceNumber,
                InspectionType = dto.InspectionType,
                ProductionOrderId = dto.ProductionOrderId,
                ProductId = dto.ProductId,
                RawMaterialId = dto.RawMaterialId,
                BatchNumber = dto.BatchNumber,
                LotNumber = dto.LotNumber,
                SamplingStandard = dto.SamplingStandard,
                InspectorId = dto.InspectorId,
                InspectionDateTime = dto.InspectionDateTime,
                SampleSize = dto.SampleSize,
                PassedQty = dto.PassedQty,
                FailedQty = dto.FailedQty,
                MoistureContentPct = dto.MoistureContentPct,
                MoistureSpecMin = dto.MoistureSpecMin,
                MoistureSpecMax = dto.MoistureSpecMax,
                NicotineLevelMg = dto.NicotineLevelMg,
                NicotineSpecMin = dto.NicotineSpecMin,
                NicotineSpecMax = dto.NicotineSpecMax,
                TarLevelMg = dto.TarLevelMg,
                TarSpecMin = dto.TarSpecMin,
                TarSpecMax = dto.TarSpecMax,
                DrawResistancePa = dto.DrawResistancePa,
                DrawResistanceSpecMin = dto.DrawResistanceSpecMin,
                DrawResistanceSpecMax = dto.DrawResistanceSpecMax,
                CigaretteDiameterMm = dto.CigaretteDiameterMm,
                CigaretteLengthMm = dto.CigaretteLengthMm,
                PackWeightGm = dto.PackWeightGm,
                TensileStrength = dto.TensileStrength,
                VentilationPct = dto.VentilationPct,
                PrintingQualityResult = dto.PrintingQualityResult,
                HealthWarningPresent = dto.HealthWarningPresent,
                BarcodeVerified = dto.BarcodeVerified,
                OverallResult = dto.OverallResult,
                FailureMode = dto.FailureMode,
                DefectCategory = dto.DefectCategory,
                Ncrnumber = dto.Ncrnumber,
                CorrectiveAction = dto.CorrectiveAction,
                PreventiveAction = dto.PreventiveAction,
                IsReleased = dto.IsReleased,
                ReleasedBy = dto.ReleasedBy,
                ReleasedAt = dto.ReleasedAt,
                TestReportAttachment = dto.TestReportAttachment,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.QualityControlLogs.AddAsync(log);
            await _unitOfWork.SaveAsync();
        }

        // Update QC Record
        public async Task UpdateAsync(UpdateQualityControlLogDto dto)
        {
            var log = await _unitOfWork.QualityControlLogs.GetByIdAsync(dto.Qcid);

            if (log == null)
                throw new Exception("Quality Control Record not found.");

            log.QcreferenceNumber = dto.QcreferenceNumber;
            log.InspectionType = dto.InspectionType;
            log.ProductionOrderId = dto.ProductionOrderId;
            log.ProductId = dto.ProductId;
            log.RawMaterialId = dto.RawMaterialId;
            log.BatchNumber = dto.BatchNumber;
            log.LotNumber = dto.LotNumber;
            log.SamplingStandard = dto.SamplingStandard;
            log.InspectorId = dto.InspectorId;
            log.InspectionDateTime = dto.InspectionDateTime;
            log.SampleSize = dto.SampleSize;
            log.PassedQty = dto.PassedQty;
            log.FailedQty = dto.FailedQty;
            log.MoistureContentPct = dto.MoistureContentPct;
            log.MoistureSpecMin = dto.MoistureSpecMin;
            log.MoistureSpecMax = dto.MoistureSpecMax;
            log.NicotineLevelMg = dto.NicotineLevelMg;
            log.NicotineSpecMin = dto.NicotineSpecMin;
            log.NicotineSpecMax = dto.NicotineSpecMax;
            log.TarLevelMg = dto.TarLevelMg;
            log.TarSpecMin = dto.TarSpecMin;
            log.TarSpecMax = dto.TarSpecMax;
            log.DrawResistancePa = dto.DrawResistancePa;
            log.DrawResistanceSpecMin = dto.DrawResistanceSpecMin;
            log.DrawResistanceSpecMax = dto.DrawResistanceSpecMax;
            log.CigaretteDiameterMm = dto.CigaretteDiameterMm;
            log.CigaretteLengthMm = dto.CigaretteLengthMm;
            log.PackWeightGm = dto.PackWeightGm;
            log.TensileStrength = dto.TensileStrength;
            log.VentilationPct = dto.VentilationPct;
            log.PrintingQualityResult = dto.PrintingQualityResult;
            log.HealthWarningPresent = dto.HealthWarningPresent;
            log.BarcodeVerified = dto.BarcodeVerified;
            log.OverallResult = dto.OverallResult;
            log.FailureMode = dto.FailureMode;
            log.DefectCategory = dto.DefectCategory;
            log.Ncrnumber = dto.Ncrnumber;
            log.CorrectiveAction = dto.CorrectiveAction;
            log.PreventiveAction = dto.PreventiveAction;
            log.IsReleased = dto.IsReleased;
            log.ReleasedBy = dto.ReleasedBy;
            log.ReleasedAt = dto.ReleasedAt;
            log.TestReportAttachment = dto.TestReportAttachment;
            log.Remarks = dto.Remarks;
            log.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.QualityControlLogs.Update(log);
            await _unitOfWork.SaveAsync();
        }

        // Delete QC Record
        public async Task DeleteAsync(int id)
        {
            var log = await _unitOfWork.QualityControlLogs.GetByIdAsync(id);

            if (log == null)
                throw new Exception("Quality Control Record not found.");

            _unitOfWork.QualityControlLogs.Delete(log);
            await _unitOfWork.SaveAsync();
        }

        // Map Entity to DTO
        private static QualityControlLogDto MapToDto(QualityControlLog log)
        {
            return new QualityControlLogDto
            {
                Qcid = log.Qcid,
                QcreferenceNumber = log.QcreferenceNumber,
                InspectionType = log.InspectionType,
                ProductionOrderId = log.ProductionOrderId,
                ProductId = log.ProductId,
                RawMaterialId = log.RawMaterialId,
                BatchNumber = log.BatchNumber,
                LotNumber = log.LotNumber,
                SamplingStandard = log.SamplingStandard,
                InspectorId = log.InspectorId,
                InspectionDateTime = log.InspectionDateTime,
                SampleSize = log.SampleSize,
                PassedQty = log.PassedQty,
                FailedQty = log.FailedQty,
                MoistureContentPct = log.MoistureContentPct,
                MoistureSpecMin = log.MoistureSpecMin,
                MoistureSpecMax = log.MoistureSpecMax,
                NicotineLevelMg = log.NicotineLevelMg,
                NicotineSpecMin = log.NicotineSpecMin,
                NicotineSpecMax = log.NicotineSpecMax,
                TarLevelMg = log.TarLevelMg,
                TarSpecMin = log.TarSpecMin,
                TarSpecMax = log.TarSpecMax,
                DrawResistancePa = log.DrawResistancePa,
                DrawResistanceSpecMin = log.DrawResistanceSpecMin,
                DrawResistanceSpecMax = log.DrawResistanceSpecMax,
                CigaretteDiameterMm = log.CigaretteDiameterMm,
                CigaretteLengthMm = log.CigaretteLengthMm,
                PackWeightGm = log.PackWeightGm,
                TensileStrength = log.TensileStrength,
                VentilationPct = log.VentilationPct,
                PrintingQualityResult = log.PrintingQualityResult,
                HealthWarningPresent = log.HealthWarningPresent,
                BarcodeVerified = log.BarcodeVerified,
                OverallResult = log.OverallResult,
                FailureMode = log.FailureMode,
                DefectCategory = log.DefectCategory,
                Ncrnumber = log.Ncrnumber,
                CorrectiveAction = log.CorrectiveAction,
                PreventiveAction = log.PreventiveAction,
                IsReleased = log.IsReleased,
                ReleasedBy = log.ReleasedBy,
                ReleasedAt = log.ReleasedAt,
                TestReportAttachment = log.TestReportAttachment,
                Remarks = log.Remarks,
                CreatedAt = log.CreatedAt,
                UpdatedAt = log.UpdatedAt,
                CreatedBy = log.CreatedBy,
                UpdatedBy = log.UpdatedBy
            };
        }
    }
}