using BeyondTheBarcode.Application.DTOs.BatchTrackTraceDtos;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class BatchTrackTraceService : IBatchTrackTraceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BatchTrackTraceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all Batch Traces
        public async Task<IEnumerable<BatchTrackTraceDto>> GetAllAsync()
        {
            var traces = await _unitOfWork.BatchTrackTraces.GetAllAsync();
            return traces.Select(MapToDto);
        }

        // Get Batch Trace by Id
        public async Task<BatchTrackTraceDto?> GetByIdAsync(int id)
        {
            var trace = await _unitOfWork.BatchTrackTraces.GetByIdAsync(id);

            if (trace == null)
                return null;

            return MapToDto(trace);
        }

        // Get Batch Trace by Trace Number
        public async Task<BatchTrackTraceDto?> GetByTraceNumberAsync(string traceNumber)
        {
            var trace = await _unitOfWork.BatchTrackTraces.GetByTraceNumberAsync(traceNumber);

            if (trace == null)
                return null;

            return MapToDto(trace);
        }

        // Get Batch Trace by Batch Number
        public async Task<IEnumerable<BatchTrackTraceDto>> GetByBatchAsync(string batchNumber)
        {
            var traces = await _unitOfWork.BatchTrackTraces.GetByBatchAsync(batchNumber);
            return traces.Select(MapToDto);
        }

        // Get Batch Trace by Product
        public async Task<IEnumerable<BatchTrackTraceDto>> GetByProductAsync(int productId)
        {
            var traces = await _unitOfWork.BatchTrackTraces.GetByProductAsync(productId);
            return traces.Select(MapToDto);
        }

        // Get Batch Trace by Production Order
        public async Task<IEnumerable<BatchTrackTraceDto>> GetByProductionOrderAsync(int productionOrderId)
        {
            var traces = await _unitOfWork.BatchTrackTraces.GetByProductionOrderAsync(productionOrderId);
            return traces.Select(MapToDto);
        }

        // Search Batch Traces
        public async Task<IEnumerable<BatchTrackTraceDto>> SearchAsync(string keyword)
        {
            var traces = await _unitOfWork.BatchTrackTraces.SearchAsync(keyword);
            return traces.Select(MapToDto);
        }
        // Get Recalled Batches
        public async Task<IEnumerable<BatchTrackTraceDto>> GetRecalledAsync()
        {
            var traces = await _unitOfWork.BatchTrackTraces.GetRecalledAsync();
            return traces.Select(MapToDto);
        }

        // Get Destroyed Batches
        public async Task<IEnumerable<BatchTrackTraceDto>> GetDestroyedAsync()
        {
            var traces = await _unitOfWork.BatchTrackTraces.GetDestroyedAsync();
            return traces.Select(MapToDto);
        }

        // Get Batch Trace by Customer
        public async Task<IEnumerable<BatchTrackTraceDto>> GetByCustomerAsync(int customerId)
        {
            var traces = await _unitOfWork.BatchTrackTraces.GetByCustomerAsync(customerId);
            return traces.Select(MapToDto);
        }

        // Check Trace Number Exists
        public async Task<bool> IsTraceNumberExistsAsync(string traceNumber)
        {
            return await _unitOfWork.BatchTrackTraces.IsTraceNumberExistsAsync(traceNumber);
        }

        // Create Batch Trace
        public async Task CreateAsync(CreateBatchTrackTraceDto dto)
        {
            var trace = new BatchTrackTrace
            {
                TraceNumber = dto.TraceNumber,
                BatchNumber = dto.BatchNumber,
                LotNumber = dto.LotNumber,
                ProductId = dto.ProductId,
                ProductionOrderId = dto.ProductionOrderId,
                RawMaterialId = dto.RawMaterialId,
                RawMaterialBatch = dto.RawMaterialBatch,
                SupplierId = dto.SupplierId,
                ManufacturingDate = dto.ManufacturingDate,
                PackagingDate = dto.PackagingDate,
                ExpiryDate = dto.ExpiryDate,
                ShelfLifeDays = dto.ShelfLifeDays,
                StampId = dto.StampId,
                ExciseChallanRef = dto.ExciseChallanRef,
                QclogId = dto.QclogId,
                Qcstatus = dto.Qcstatus,
                QcreleasedAt = dto.QcreleasedAt,
                WarehouseInventoryId = dto.WarehouseInventoryId,
                ReceiptDate = dto.ReceiptDate,
                DispatchDate = dto.DispatchDate,
                SalesOrderId = dto.SalesOrderId,
                InvoiceNumber = dto.InvoiceNumber,
                ShipmentId = dto.ShipmentId,
                CustomerId = dto.CustomerId,
                DeliveryDate = dto.DeliveryDate,
                CurrentStatus = dto.CurrentStatus,
                IsRecalled = dto.IsRecalled,
                RecallReason = dto.RecallReason,
                RecallInitiatedAt = dto.RecallInitiatedAt,
                RecallInitiatedBy = dto.RecallInitiatedBy,
                IsDestroyed = dto.IsDestroyed,
                DestroyedAt = dto.DestroyedAt,
                DestroyedBy = dto.DestroyedBy,
                DestructionReason = dto.DestructionReason,
                TraceabilityChain = dto.TraceabilityChain,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.BatchTrackTraces.AddAsync(trace);
            await _unitOfWork.SaveAsync();
        }


        // Update Batch Trace
        public async Task UpdateAsync(UpdateBatchTrackTraceDto dto)
        {
            var trace = await _unitOfWork.BatchTrackTraces.GetByIdAsync(dto.TraceId);

            if (trace == null)
                throw new Exception("Batch Trace not found.");

            trace.TraceNumber = dto.TraceNumber;
            trace.BatchNumber = dto.BatchNumber;
            trace.LotNumber = dto.LotNumber;
            trace.ProductId = dto.ProductId;
            trace.ProductionOrderId = dto.ProductionOrderId;
            trace.RawMaterialId = dto.RawMaterialId;
            trace.RawMaterialBatch = dto.RawMaterialBatch;
            trace.SupplierId = dto.SupplierId;
            trace.ManufacturingDate = dto.ManufacturingDate;
            trace.PackagingDate = dto.PackagingDate;
            trace.ExpiryDate = dto.ExpiryDate;
            trace.ShelfLifeDays = dto.ShelfLifeDays;
            trace.StampId = dto.StampId;
            trace.ExciseChallanRef = dto.ExciseChallanRef;
            trace.QclogId = dto.QclogId;
            trace.Qcstatus = dto.Qcstatus;
            trace.QcreleasedAt = dto.QcreleasedAt;
            trace.WarehouseInventoryId = dto.WarehouseInventoryId;
            trace.ReceiptDate = dto.ReceiptDate;
            trace.DispatchDate = dto.DispatchDate;
            trace.SalesOrderId = dto.SalesOrderId;
            trace.InvoiceNumber = dto.InvoiceNumber;
            trace.ShipmentId = dto.ShipmentId;
            trace.CustomerId = dto.CustomerId;
            trace.DeliveryDate = dto.DeliveryDate;
            trace.CurrentStatus = dto.CurrentStatus;
            trace.IsRecalled = dto.IsRecalled;
            trace.RecallReason = dto.RecallReason;
            trace.RecallInitiatedAt = dto.RecallInitiatedAt;
            trace.RecallInitiatedBy = dto.RecallInitiatedBy;
            trace.IsDestroyed = dto.IsDestroyed;
            trace.DestroyedAt = dto.DestroyedAt;
            trace.DestroyedBy = dto.DestroyedBy;
            trace.DestructionReason = dto.DestructionReason;
            trace.TraceabilityChain = dto.TraceabilityChain;
            trace.Remarks = dto.Remarks;
            trace.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.BatchTrackTraces.Update(trace);
            await _unitOfWork.SaveAsync();
        }

        // Delete Batch Trace
        public async Task DeleteAsync(int id)
        {
            var trace = await _unitOfWork.BatchTrackTraces.GetByIdAsync(id);

            if (trace == null)
                throw new Exception("Batch Trace not found.");

            _unitOfWork.BatchTrackTraces.Delete(trace);
            await _unitOfWork.SaveAsync();
        }

        // Map Entity to DTO
        private static BatchTrackTraceDto MapToDto(BatchTrackTrace trace)
        {
            return new BatchTrackTraceDto
            {
                TraceId = trace.TraceId,
                TraceNumber = trace.TraceNumber,
                BatchNumber = trace.BatchNumber,
                LotNumber = trace.LotNumber,
                ProductId = trace.ProductId,
                ProductionOrderId = trace.ProductionOrderId,
                RawMaterialId = trace.RawMaterialId,
                RawMaterialBatch = trace.RawMaterialBatch,
                SupplierId = trace.SupplierId,
                ManufacturingDate = trace.ManufacturingDate,
                PackagingDate = trace.PackagingDate,
                ExpiryDate = trace.ExpiryDate,
                ShelfLifeDays = trace.ShelfLifeDays,
                StampId = trace.StampId,
                ExciseChallanRef = trace.ExciseChallanRef,
                QclogId = trace.QclogId,
                Qcstatus = trace.Qcstatus,
                QcreleasedAt = trace.QcreleasedAt,
                WarehouseInventoryId = trace.WarehouseInventoryId,
                ReceiptDate = trace.ReceiptDate,
                DispatchDate = trace.DispatchDate,
                SalesOrderId = trace.SalesOrderId,
                InvoiceNumber = trace.InvoiceNumber,
                ShipmentId = trace.ShipmentId,
                CustomerId = trace.CustomerId,
                DeliveryDate = trace.DeliveryDate,
                CurrentStatus = trace.CurrentStatus,
                IsRecalled = trace.IsRecalled,
                RecallReason = trace.RecallReason,
                RecallInitiatedAt = trace.RecallInitiatedAt,
                RecallInitiatedBy = trace.RecallInitiatedBy,
                IsDestroyed = trace.IsDestroyed,
                DestroyedAt = trace.DestroyedAt,
                DestroyedBy = trace.DestroyedBy,
                DestructionReason = trace.DestructionReason,
                TraceabilityChain = trace.TraceabilityChain,
                Remarks = trace.Remarks,
                CreatedAt = trace.CreatedAt,
                UpdatedAt = trace.UpdatedAt,
                CreatedBy = trace.CreatedBy,
                UpdatedBy = trace.UpdatedBy
            };
        }
    }
}
