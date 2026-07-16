using BeyondTheBarcode.Application.DTOs.SalesOrderDtos;
using BeyondTheBarcode.Application.Interfaces;
using BeyondTheBarcode.Application.Interfaces.IUnitOfWork;
using BeyondTheBarcode.Application.Interfaces.Services;
using BeyondTheBarcode.Domain.Entities;

namespace BeyondTheBarcode.Application.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Get All Sales Orders

        public async Task<IEnumerable<SalesOrderDto>> GetAllAsync()
        {
            var orders = await _unitOfWork.SalesOrders.GetAllAsync();
            return orders.Select(MapToDto);
        }

        #endregion

        #region Get Sales Order By Id

        public async Task<SalesOrderDto?> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.SalesOrders.GetByIdAsync(id);

            if (order == null)
                return null;

            return MapToDto(order);
        }

        #endregion

        #region Get Sales Order By Order Number

        public async Task<SalesOrderDto?> GetByOrderNumberAsync(string orderNumber)
        {
            var order = await _unitOfWork.SalesOrders.GetByOrderNumberAsync(orderNumber);

            if (order == null)
                return null;

            return MapToDto(order);
        }

        #endregion

        #region Get Sales Orders By Customer

        public async Task<IEnumerable<SalesOrderDto>> GetByCustomerAsync(int customerId)
        {
            var orders = await _unitOfWork.SalesOrders.GetByCustomerAsync(customerId);
            return orders.Select(MapToDto);
        }

        #endregion

        #region Get Sales Orders By Product

        public async Task<IEnumerable<SalesOrderDto>> GetByProductAsync(int productId)
        {
            var orders = await _unitOfWork.SalesOrders.GetByProductAsync(productId);
            return orders.Select(MapToDto);
        }

        #endregion

        #region Search Sales Orders

        public async Task<IEnumerable<SalesOrderDto>> SearchAsync(string keyword)
        {
            var orders = await _unitOfWork.SalesOrders.SearchAsync(keyword);
            return orders.Select(MapToDto);
        }

        #endregion


        #region Get Sales Orders By Status

        public async Task<IEnumerable<SalesOrderDto>> GetByStatusAsync(string status)
        {
            var orders = await _unitOfWork.SalesOrders.GetByStatusAsync(status);
            return orders.Select(MapToDto);
        }

        #endregion

        #region Get Sales Orders By Payment Status

        public async Task<IEnumerable<SalesOrderDto>> GetByPaymentStatusAsync(string paymentStatus)
        {
            var orders = await _unitOfWork.SalesOrders.GetByPaymentStatusAsync(paymentStatus);
            return orders.Select(MapToDto);
        }

        #endregion

        #region Get Sales Orders By Date Range

        public async Task<IEnumerable<SalesOrderDto>> GetByDateRangeAsync(DateOnly fromDate, DateOnly toDate)
        {
            var orders = await _unitOfWork.SalesOrders.GetByDateRangeAsync(fromDate, toDate);
            return orders.Select(MapToDto);
        }

        #endregion

        #region Get Approved Sales Orders

        public async Task<IEnumerable<SalesOrderDto>> GetApprovedOrdersAsync()
        {
            var orders = await _unitOfWork.SalesOrders.GetApprovedOrdersAsync();
            return orders.Select(MapToDto);
        }

        #endregion

        #region Check Order Number Exists

        public async Task<bool> IsOrderNumberExistsAsync(string orderNumber)
        {
            return await _unitOfWork.SalesOrders.IsOrderNumberExistsAsync(orderNumber);
        }

        #endregion
        #region Create Sales Order

        public async Task CreateAsync(CreateSalesOrderDto dto)
        {
            var order = new SalesOrder
            {
                OrderNumber = dto.OrderNumber,
                CustomerId = dto.CustomerId,
                OrderDate = dto.OrderDate,
                RequestedDeliveryDate = dto.RequestedDeliveryDate,
                ConfirmedDeliveryDate = dto.ConfirmedDeliveryDate,
                OrderStatus = dto.OrderStatus,
                OrderSource = dto.OrderSource,
                ProductId = dto.ProductId,
                OrderedQty = dto.OrderedQty,
                ConfirmedQty = dto.ConfirmedQty,
                ShippedQty = dto.ShippedQty,
                BackOrderQty = dto.BackOrderQty,
                UnitOfMeasure = dto.UnitOfMeasure,
                UnitPrice = dto.UnitPrice,
                DiscountPercent = dto.DiscountPercent,
                DiscountAmount = dto.DiscountAmount,
                TaxableAmount = dto.TaxableAmount,
                Gstrate = dto.Gstrate,
                Cgstamount = dto.Cgstamount,
                Sgstamount = dto.Sgstamount,
                Igstamount = dto.Igstamount,
                CessAmount = dto.CessAmount,
                ExciseDutyAmount = dto.ExciseDutyAmount,
                TotalTaxAmount = dto.TotalTaxAmount,
                TotalAmount = dto.TotalAmount,
                RoundOff = dto.RoundOff,
                FinalAmount = dto.FinalAmount,
                PaymentStatus = dto.PaymentStatus,
                PaymentDueDate = dto.PaymentDueDate,
                ShippingAddress = dto.ShippingAddress,
                ShippingCity = dto.ShippingCity,
                ShippingState = dto.ShippingState,
                ShippingPincode = dto.ShippingPincode,
                IsInterstate = dto.IsInterstate,
                Ponumber = dto.Ponumber,
                SalesRepId = dto.SalesRepId,
                ApprovedBy = dto.ApprovedBy,
                ApprovedAt = dto.ApprovedAt,
                CancelledBy = dto.CancelledBy,
                CancelledAt = dto.CancelledAt,
                CancellationReason = dto.CancellationReason,
                InvoiceNumber = dto.InvoiceNumber,
                InvoiceDate = dto.InvoiceDate,
                EwayBillNumber = dto.EwayBillNumber,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.SalesOrders.AddAsync(order);
            await _unitOfWork.SaveAsync();
        }

        #endregion

        #region Update Sales Order

        public async Task UpdateAsync(UpdateSalesOrderDto dto)
        {
            var order = await _unitOfWork.SalesOrders.GetByIdAsync(dto.SalesOrderId);

            if (order == null)
                throw new Exception("Sales Order not found.");

            order.OrderNumber = dto.OrderNumber;
            order.CustomerId = dto.CustomerId;
            order.OrderDate = dto.OrderDate;
            order.RequestedDeliveryDate = dto.RequestedDeliveryDate;
            order.ConfirmedDeliveryDate = dto.ConfirmedDeliveryDate;
            order.OrderStatus = dto.OrderStatus;
            order.OrderSource = dto.OrderSource;
            order.ProductId = dto.ProductId;
            order.OrderedQty = dto.OrderedQty;
            order.ConfirmedQty = dto.ConfirmedQty;
            order.ShippedQty = dto.ShippedQty;
            order.BackOrderQty = dto.BackOrderQty;
            order.UnitOfMeasure = dto.UnitOfMeasure;
            order.UnitPrice = dto.UnitPrice;
            order.DiscountPercent = dto.DiscountPercent;
            order.DiscountAmount = dto.DiscountAmount;
            order.TaxableAmount = dto.TaxableAmount;
            order.Gstrate = dto.Gstrate;
            order.Cgstamount = dto.Cgstamount;
            order.Sgstamount = dto.Sgstamount;
            order.Igstamount = dto.Igstamount;
            order.CessAmount = dto.CessAmount;
            order.ExciseDutyAmount = dto.ExciseDutyAmount;
            order.TotalTaxAmount = dto.TotalTaxAmount;
            order.TotalAmount = dto.TotalAmount;
            order.RoundOff = dto.RoundOff;
            order.FinalAmount = dto.FinalAmount;
            order.PaymentStatus = dto.PaymentStatus;
            order.PaymentDueDate = dto.PaymentDueDate;
            order.ShippingAddress = dto.ShippingAddress;
            order.ShippingCity = dto.ShippingCity;
            order.ShippingState = dto.ShippingState;
            order.ShippingPincode = dto.ShippingPincode;
            order.IsInterstate = dto.IsInterstate;
            order.Ponumber = dto.Ponumber;
            order.SalesRepId = dto.SalesRepId;
            order.ApprovedBy = dto.ApprovedBy;
            order.ApprovedAt = dto.ApprovedAt;
            order.CancelledBy = dto.CancelledBy;
            order.CancelledAt = dto.CancelledAt;
            order.CancellationReason = dto.CancellationReason;
            order.InvoiceNumber = dto.InvoiceNumber;
            order.InvoiceDate = dto.InvoiceDate;
            order.EwayBillNumber = dto.EwayBillNumber;
            order.Remarks = dto.Remarks;
            order.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.SalesOrders.Update(order);
            await _unitOfWork.SaveAsync();
        }

        #endregion


        #region Map Entity To DTO

        private static SalesOrderDto MapToDto(SalesOrder order)
        {
            return new SalesOrderDto
            {
                SalesOrderId = order.SalesOrderId,
                OrderNumber = order.OrderNumber,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                RequestedDeliveryDate = order.RequestedDeliveryDate,
                ConfirmedDeliveryDate = order.ConfirmedDeliveryDate,
                OrderStatus = order.OrderStatus,
                OrderSource = order.OrderSource,
                ProductId = order.ProductId,
                OrderedQty = order.OrderedQty,
                ConfirmedQty = order.ConfirmedQty,
                ShippedQty = order.ShippedQty,
                BackOrderQty = order.BackOrderQty,
                UnitOfMeasure = order.UnitOfMeasure,
                UnitPrice = order.UnitPrice,
                DiscountPercent = order.DiscountPercent,
                DiscountAmount = order.DiscountAmount,
                TaxableAmount = order.TaxableAmount,
                Gstrate = order.Gstrate,
                Cgstamount = order.Cgstamount,
                Sgstamount = order.Sgstamount,
                Igstamount = order.Igstamount,
                CessAmount = order.CessAmount,
                ExciseDutyAmount = order.ExciseDutyAmount,
                TotalTaxAmount = order.TotalTaxAmount,
                TotalAmount = order.TotalAmount,
                RoundOff = order.RoundOff,
                FinalAmount = order.FinalAmount,
                PaymentStatus = order.PaymentStatus,
                PaymentDueDate = order.PaymentDueDate,
                ShippingAddress = order.ShippingAddress,
                ShippingCity = order.ShippingCity,
                ShippingState = order.ShippingState,
                ShippingPincode = order.ShippingPincode,
                IsInterstate = order.IsInterstate,
                Ponumber = order.Ponumber,
                SalesRepId = order.SalesRepId,
                ApprovedBy = order.ApprovedBy,
                ApprovedAt = order.ApprovedAt,
                CancelledBy = order.CancelledBy,
                CancelledAt = order.CancelledAt,
                CancellationReason = order.CancellationReason,
                InvoiceNumber = order.InvoiceNumber,
                InvoiceDate = order.InvoiceDate,
                EwayBillNumber = order.EwayBillNumber,
                Remarks = order.Remarks,
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                CreatedBy = order.CreatedBy,
                UpdatedBy = order.UpdatedBy
            };
        }

        #endregion

        #region Delete Sales Order

        public async Task DeleteAsync(int id)
        {
            var order = await _unitOfWork.SalesOrders.GetByIdAsync(id);

            if (order == null)
                throw new Exception("Sales Order not found.");

            _unitOfWork.SalesOrders.Delete(order);
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}