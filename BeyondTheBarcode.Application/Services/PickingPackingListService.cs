using BeyondTheBarcode.Application.DTOs.PickingPackingListDtos;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class PickingPackingListService : IPickingPackingListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PickingPackingListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all Pick & Pack Records
        public async Task<IEnumerable<PickingPackingListDto>> GetAllAsync()
        {
            var lists = await _unitOfWork.PickingPackingLists.GetAllAsync();
            return lists.Select(MapToDto);
        }

        // Get Pick & Pack by Id
        public async Task<PickingPackingListDto?> GetByIdAsync(int id)
        {
            var list = await _unitOfWork.PickingPackingLists.GetByIdAsync(id);

            if (list == null)
                return null;

            return MapToDto(list);
        }

        // Get Pick & Pack by Number
        public async Task<PickingPackingListDto?> GetByNumberAsync(string pickPackNumber)
        {
            var list = await _unitOfWork.PickingPackingLists.GetByNumberAsync(pickPackNumber);

            if (list == null)
                return null;

            return MapToDto(list);
        }

        // Get Pick & Pack by Sales Order
        public async Task<IEnumerable<PickingPackingListDto>> GetBySalesOrderAsync(int salesOrderId)
        {
            var lists = await _unitOfWork.PickingPackingLists.GetBySalesOrderAsync(salesOrderId);
            return lists.Select(MapToDto);
        }

        // Get Pick & Pack by Product
        public async Task<IEnumerable<PickingPackingListDto>> GetByProductAsync(int productId)
        {
            var lists = await _unitOfWork.PickingPackingLists.GetByProductAsync(productId);
            return lists.Select(MapToDto);
        }

        // Search Pick & Pack Records
        public async Task<IEnumerable<PickingPackingListDto>> SearchAsync(string keyword)
        {
            var lists = await _unitOfWork.PickingPackingLists.SearchAsync(keyword);
            return lists.Select(MapToDto);
        }

        // Get Pick & Pack by Status
        public async Task<IEnumerable<PickingPackingListDto>> GetByStatusAsync(string status)
        {
            var lists = await _unitOfWork.PickingPackingLists.GetByStatusAsync(status);
            return lists.Select(MapToDto);
        }
        // Get Ready for Dispatch
        public async Task<IEnumerable<PickingPackingListDto>> GetReadyForDispatchAsync()
        {
            var lists = await _unitOfWork.PickingPackingLists.GetReadyForDispatchAsync();
            return lists.Select(MapToDto);
        }

        // Get Pick & Pack by Picker
        public async Task<IEnumerable<PickingPackingListDto>> GetByPickerAsync(int pickerId)
        {
            var lists = await _unitOfWork.PickingPackingLists.GetByPickerAsync(pickerId);
            return lists.Select(MapToDto);
        }

        // Check Pick & Pack Number Exists
        public async Task<bool> IsPickPackNumberExistsAsync(string pickPackNumber)
        {
            return await _unitOfWork.PickingPackingLists.IsPickPackNumberExistsAsync(pickPackNumber);
        }

        // Create Pick & Pack
        public async Task CreateAsync(CreatePickingPackingListDto dto)
        {
            var list = new PickingPackingList
            {
                PickPackNumber = dto.PickPackNumber,
                SalesOrderId = dto.SalesOrderId,
                PickPackType = dto.PickPackType,
                Status = dto.Status,
                AssignedToPickerId = dto.AssignedToPickerId,
                PickingStartedAt = dto.PickingStartedAt,
                PickingCompletedAt = dto.PickingCompletedAt,
                PackingStartedAt = dto.PackingStartedAt,
                PackingCompletedAt = dto.PackingCompletedAt,
                BinId = dto.BinId,
                ProductId = dto.ProductId,
                BatchNumber = dto.BatchNumber,
                LotNumber = dto.LotNumber,
                RequestedQty = dto.RequestedQty,
                PickedQty = dto.PickedQty,
                PackedQty = dto.PackedQty,
                ShortQty = dto.ShortQty,
                UnitOfMeasure = dto.UnitOfMeasure,
                PackagingMaterial = dto.PackagingMaterial,
                CartonCount = dto.CartonCount,
                CartonNumbers = dto.CartonNumbers,
                PalletNumber = dto.PalletNumber,
                TotalGrossWeightKg = dto.TotalGrossWeightKg,
                TotalNetWeightKg = dto.TotalNetWeightKg,
                TotalVolumeM3 = dto.TotalVolumeM3,
                SealNumber = dto.SealNumber,
                TemperatureAtPacking = dto.TemperatureAtPacking,
                HumidityAtPacking = dto.HumidityAtPacking,
                QcverifiedBy = dto.QcverifiedBy,
                QcverifiedAt = dto.QcverifiedAt,
                QcverificationStatus = dto.QcverificationStatus,
                Qcremarks = dto.Qcremarks,
                DispatchReadyAt = dto.DispatchReadyAt,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.PickingPackingLists.AddAsync(list);
            await _unitOfWork.SaveAsync();
        }

        // Update Pick & Pack
        public async Task UpdateAsync(UpdatePickingPackingListDto dto)
        {
            var list = await _unitOfWork.PickingPackingLists.GetByIdAsync(dto.PickPackId);

            if (list == null)
                throw new Exception("Picking & Packing record not found.");

            list.PickPackNumber = dto.PickPackNumber;
            list.SalesOrderId = dto.SalesOrderId;
            list.PickPackType = dto.PickPackType;
            list.Status = dto.Status;
            list.AssignedToPickerId = dto.AssignedToPickerId;
            list.PickingStartedAt = dto.PickingStartedAt;
            list.PickingCompletedAt = dto.PickingCompletedAt;
            list.PackingStartedAt = dto.PackingStartedAt;
            list.PackingCompletedAt = dto.PackingCompletedAt;
            list.BinId = dto.BinId;
            list.ProductId = dto.ProductId;
            list.BatchNumber = dto.BatchNumber;
            list.LotNumber = dto.LotNumber;
            list.RequestedQty = dto.RequestedQty;
            list.PickedQty = dto.PickedQty;
            list.PackedQty = dto.PackedQty;
            list.ShortQty = dto.ShortQty;
            list.UnitOfMeasure = dto.UnitOfMeasure;
            list.PackagingMaterial = dto.PackagingMaterial;
            list.CartonCount = dto.CartonCount;
            list.CartonNumbers = dto.CartonNumbers;
            list.PalletNumber = dto.PalletNumber;
            list.TotalGrossWeightKg = dto.TotalGrossWeightKg;
            list.TotalNetWeightKg = dto.TotalNetWeightKg;
            list.TotalVolumeM3 = dto.TotalVolumeM3;
            list.SealNumber = dto.SealNumber;
            list.TemperatureAtPacking = dto.TemperatureAtPacking;
            list.HumidityAtPacking = dto.HumidityAtPacking;
            list.QcverifiedBy = dto.QcverifiedBy;
            list.QcverifiedAt = dto.QcverifiedAt;
            list.QcverificationStatus = dto.QcverificationStatus;
            list.Qcremarks = dto.Qcremarks;
            list.DispatchReadyAt = dto.DispatchReadyAt;
            list.Remarks = dto.Remarks;
            list.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.PickingPackingLists.Update(list);
            await _unitOfWork.SaveAsync();
        }

        // Delete Pick & Pack
        public async Task DeleteAsync(int id)
        {
            var list = await _unitOfWork.PickingPackingLists.GetByIdAsync(id);

            if (list == null)
                throw new Exception("Picking & Packing record not found.");

            _unitOfWork.PickingPackingLists.Delete(list);
            await _unitOfWork.SaveAsync();
        }

        // Map Entity to DTO
        private static PickingPackingListDto MapToDto(PickingPackingList list)
        {
            return new PickingPackingListDto
            {
                PickPackId = list.PickPackId,
                PickPackNumber = list.PickPackNumber,
                SalesOrderId = list.SalesOrderId,
                PickPackType = list.PickPackType,
                Status = list.Status,
                AssignedToPickerId = list.AssignedToPickerId,
                PickingStartedAt = list.PickingStartedAt,
                PickingCompletedAt = list.PickingCompletedAt,
                PackingStartedAt = list.PackingStartedAt,
                PackingCompletedAt = list.PackingCompletedAt,
                BinId = list.BinId,
                ProductId = list.ProductId,
                BatchNumber = list.BatchNumber,
                LotNumber = list.LotNumber,
                RequestedQty = list.RequestedQty,
                PickedQty = list.PickedQty,
                PackedQty = list.PackedQty,
                ShortQty = list.ShortQty,
                UnitOfMeasure = list.UnitOfMeasure,
                PackagingMaterial = list.PackagingMaterial,
                CartonCount = list.CartonCount,
                CartonNumbers = list.CartonNumbers,
                PalletNumber = list.PalletNumber,
                TotalGrossWeightKg = list.TotalGrossWeightKg,
                TotalNetWeightKg = list.TotalNetWeightKg,
                TotalVolumeM3 = list.TotalVolumeM3,
                SealNumber = list.SealNumber,
                TemperatureAtPacking = list.TemperatureAtPacking,
                HumidityAtPacking = list.HumidityAtPacking,
                QcverifiedBy = list.QcverifiedBy,
                QcverifiedAt = list.QcverifiedAt,
                QcverificationStatus = list.QcverificationStatus,
                Qcremarks = list.Qcremarks,
                DispatchReadyAt = list.DispatchReadyAt,
                Remarks = list.Remarks,
                CreatedAt = list.CreatedAt,
                UpdatedAt = list.UpdatedAt,
                CreatedBy = list.CreatedBy,
                UpdatedBy = list.UpdatedBy
            };
        }
    }
}
