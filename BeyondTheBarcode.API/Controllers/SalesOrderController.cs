using BeyondTheBarcode.Application.DTOs.SalesOrderDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderService _salesOrderService;

        public SalesOrderController(ISalesOrderService salesOrderService)
        {
            _salesOrderService = salesOrderService;
        }

        #region Get All Sales Orders

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _salesOrderService.GetAllAsync();
            return Ok(orders);
        }

        #endregion

        #region Get Sales Order By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _salesOrderService.GetByIdAsync(id);

            if (order == null)
                return NotFound($"Sales Order with Id {id} not found.");

            return Ok(order);
        }

        #endregion

        #region Get Sales Order By Order Number

        [HttpGet("number/{orderNumber}")]
        public async Task<IActionResult> GetByOrderNumber(string orderNumber)
        {
            var order = await _salesOrderService.GetByOrderNumberAsync(orderNumber);

            if (order == null)
                return NotFound($"Sales Order '{orderNumber}' not found.");

            return Ok(order);
        }

        #endregion

        #region Get Sales Orders By Customer

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var orders = await _salesOrderService.GetByCustomerAsync(customerId);

            if (!orders.Any())
                return NotFound("No Sales Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Get Sales Orders By Product

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var orders = await _salesOrderService.GetByProductAsync(productId);

            if (!orders.Any())
                return NotFound("No Sales Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Search Sales Orders

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var orders = await _salesOrderService.SearchAsync(keyword);

            if (!orders.Any())
                return NotFound("No matching Sales Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Get Sales Orders By Status

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var orders = await _salesOrderService.GetByStatusAsync(status);

            if (!orders.Any())
                return NotFound("No Sales Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Get Sales Orders By Payment Status

        [HttpGet("payment-status/{paymentStatus}")]
        public async Task<IActionResult> GetByPaymentStatus(string paymentStatus)
        {
            var orders = await _salesOrderService.GetByPaymentStatusAsync(paymentStatus);

            if (!orders.Any())
                return NotFound("No Sales Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Get Sales Orders By Date Range

        [HttpGet("date-range")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateOnly fromDate, [FromQuery] DateOnly toDate)
        {
            var orders = await _salesOrderService.GetByDateRangeAsync(fromDate, toDate);

            if (!orders.Any())
                return NotFound("No Sales Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Get Approved Sales Orders

        [HttpGet("approved")]
        public async Task<IActionResult> GetApproved()
        {
            var orders = await _salesOrderService.GetApprovedOrdersAsync();

            if (!orders.Any())
                return NotFound("No approved Sales Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Check Order Number Exists

        [HttpGet("exists/{orderNumber}")]
        public async Task<IActionResult> IsOrderNumberExists(string orderNumber)
        {
            var exists = await _salesOrderService.IsOrderNumberExistsAsync(orderNumber);

            return Ok(exists);
        }

        #endregion

        #region Create Sales Order

        [HttpPost]
        public async Task<IActionResult> Create(CreateSalesOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _salesOrderService.IsOrderNumberExistsAsync(dto.OrderNumber);

            if (exists)
                return BadRequest("Order Number already exists.");

            await _salesOrderService.CreateAsync(dto);

            return Ok("Sales Order created successfully.");
        }

        #endregion

        #region Update Sales Order

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSalesOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _salesOrderService.GetByIdAsync(dto.SalesOrderId);

            if (existing == null)
                return NotFound($"Sales Order with Id {dto.SalesOrderId} not found.");

            await _salesOrderService.UpdateAsync(dto);

            return Ok("Sales Order updated successfully.");
        }

        #endregion


        #region Delete Sales Order

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _salesOrderService.GetByIdAsync(id);

            if (existing == null)
                return NotFound($"Sales Order with Id {id} not found.");

            await _salesOrderService.DeleteAsync(id);

            return Ok("Sales Order deleted successfully.");
        }

        #endregion
    }
}