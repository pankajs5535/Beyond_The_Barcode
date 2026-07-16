using BeyondTheBarcode.Application.DTOs.ProductionOrderDtos;
using BeyondTheBarcode.Application.Interfaces;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class ProductionOrderService : IProductionOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductionOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all Production Orders
        public async Task<IEnumerable<ProductionOrderDto>> GetAllAsync()
        {
            var orders = await _unitOfWork.ProductionOrders.GetAllAsync();
            return orders.Select(MapToDto);
        }

        // Get Production Order by Id
        public async Task<ProductionOrderDto?> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.ProductionOrders.GetByIdAsync(id);

            if (order == null)
                return null;

            return MapToDto(order);
        }

        // Get Production Order by Order Number
        public async Task<ProductionOrderDto?> GetByOrderNumberAsync(string orderNumber)
        {
            var order = await _unitOfWork.ProductionOrders.GetByOrderNumberAsync(orderNumber);

            if (order == null)
                return null;

            return MapToDto(order);
        }

        // Get Production Orders by Product
        public async Task<IEnumerable<ProductionOrderDto>> GetByProductAsync(int productId)
        {
            var orders = await _unitOfWork.ProductionOrders.GetByProductAsync(productId);
            return orders.Select(MapToDto);
        }

        // Get Production Orders by Machine
        public async Task<IEnumerable<ProductionOrderDto>> GetByMachineAsync(int machineId)
        {
            var orders = await _unitOfWork.ProductionOrders.GetByMachineAsync(machineId);
            return orders.Select(MapToDto);
        }

        // Search Production Orders
        public async Task<IEnumerable<ProductionOrderDto>> SearchAsync(string keyword)
        {
            var orders = await _unitOfWork.ProductionOrders.SearchAsync(keyword);
            return orders.Select(MapToDto);
        }

        // Get Production Orders by Status
        public async Task<IEnumerable<ProductionOrderDto>> GetByStatusAsync(string status)
        {
            var orders = await _unitOfWork.ProductionOrders.GetByStatusAsync(status);
            return orders.Select(MapToDto);
        }

        // Get Production Orders by Priority
        public async Task<IEnumerable<ProductionOrderDto>> GetByPriorityAsync(byte priority)
        {
            var orders = await _unitOfWork.ProductionOrders.GetByPriorityAsync(priority);
            return orders.Select(MapToDto);
        }

        // Get Production Orders by Date Range
        public async Task<IEnumerable<ProductionOrderDto>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate)
        {
            var orders = await _unitOfWork.ProductionOrders.GetByDateRangeAsync(fromDate, toDate);
            return orders.Select(MapToDto);
        }

        // Get Open Production Orders
        public async Task<IEnumerable<ProductionOrderDto>> GetOpenOrdersAsync()
        {
            var orders = await _unitOfWork.ProductionOrders.GetOpenOrdersAsync();
            return orders.Select(MapToDto);
        }

        // Check Order Number Exists
        public async Task<bool> IsOrderNumberExistsAsync(string orderNumber)
        {
            return await _unitOfWork.ProductionOrders.IsOrderNumberExistsAsync(orderNumber);
        }

        // Create Production Order
        public async Task CreateAsync(CreateProductionOrderDto dto)
        {
            var order = new ProductionOrder
            {
                Bomid = dto.Bomid,
                PlannedQty = dto.PlannedQty,
                ActualQty = dto.ActualQty,
                RejectedQty = dto.RejectedQty,
                YieldPercentage = dto.YieldPercentage,

                OperatorId = dto.OperatorId,

                PlannedLaborHours = dto.PlannedLaborHours,
                ActualLaborHours = dto.ActualLaborHours,

                LaborCostPlanned = dto.LaborCostPlanned,
                LaborCostActual = dto.LaborCostActual,

                MaterialCostPlanned = dto.MaterialCostPlanned,
                MaterialCostActual = dto.MaterialCostActual,

                OverheadCostPlanned = dto.OverheadCostPlanned,
                OverheadCostActual = dto.OverheadCostActual,

                TotalCostActual = dto.TotalCostActual,

                ReasonForDeviation = dto.ReasonForDeviation,
                SalesOrderRef = dto.SalesOrderRef,

                ApprovedBy = dto.ApprovedBy,
                ApprovedAt = dto.ApprovedAt,

                ClosedBy = dto.ClosedBy,
                ClosedAt = dto.ClosedAt,    
            };

            await _unitOfWork.ProductionOrders.AddAsync(order);
            await _unitOfWork.SaveAsync();
        }

        // Update Production Order
        public async Task UpdateAsync(UpdateProductionOrderDto dto)
        {
            var order = await _unitOfWork.ProductionOrders.GetByIdAsync(dto.ProductionOrderId);

            if (order == null)
                throw new Exception("Production Order not found.");

            order.Bomid = dto.Bomid;
            order.PlannedQty = dto.PlannedQty;
            order.ActualQty = dto.ActualQty;
            order.RejectedQty = dto.RejectedQty;
            order.YieldPercentage = dto.YieldPercentage;

            order.OperatorId = dto.OperatorId;

            order.PlannedLaborHours = dto.PlannedLaborHours;
            order.ActualLaborHours = dto.ActualLaborHours;

            order.LaborCostPlanned = dto.LaborCostPlanned;
            order.LaborCostActual = dto.LaborCostActual;

            order.MaterialCostPlanned = dto.MaterialCostPlanned;
            order.MaterialCostActual = dto.MaterialCostActual;

            order.OverheadCostPlanned = dto.OverheadCostPlanned;
            order.OverheadCostActual = dto.OverheadCostActual;

            order.TotalCostActual = dto.TotalCostActual;

            order.ReasonForDeviation = dto.ReasonForDeviation;
            order.SalesOrderRef = dto.SalesOrderRef;

            order.ApprovedBy = dto.ApprovedBy;
            order.ApprovedAt = dto.ApprovedAt;

            order.ClosedBy = dto.ClosedBy;
            order.ClosedAt = dto.ClosedAt;

            _unitOfWork.ProductionOrders.Update(order);
            await _unitOfWork.SaveAsync();
        }

        // Delete Production Order
        public async Task DeleteAsync(int id)
        {
            var order = await _unitOfWork.ProductionOrders.GetByIdAsync(id);

            if (order == null)
                throw new Exception("Production Order not found.");

            _unitOfWork.ProductionOrders.Delete(order);
            await _unitOfWork.SaveAsync();
        }

        // Map Entity to DTO
        private static ProductionOrderDto MapToDto(ProductionOrder order)
        {
            return new ProductionOrderDto
            {
                Bomid = order.Bomid,
                PlannedQty = order.PlannedQty,
                ActualQty = order.ActualQty,
                RejectedQty = order.RejectedQty,
                YieldPercentage = order.YieldPercentage,

                OperatorId = order.OperatorId,

                PlannedLaborHours = order.PlannedLaborHours,
                ActualLaborHours = order.ActualLaborHours,

                LaborCostPlanned = order.LaborCostPlanned,
                LaborCostActual = order.LaborCostActual,

                MaterialCostPlanned = order.MaterialCostPlanned,
                MaterialCostActual = order.MaterialCostActual,

                OverheadCostPlanned = order.OverheadCostPlanned,
                OverheadCostActual = order.OverheadCostActual,

                TotalCostActual = order.TotalCostActual,

                ReasonForDeviation = order.ReasonForDeviation,
                SalesOrderRef = order.SalesOrderRef,

                ApprovedBy = order.ApprovedBy,
                ApprovedAt = order.ApprovedAt,

                ClosedBy = order.ClosedBy,
                ClosedAt = order.ClosedAt
            };
        }
    }
}


