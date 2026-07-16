using BeyondTheBarcode.Application.DTOs.ProductionOrderDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionOrderController : ControllerBase
    {
        private readonly IProductionOrderService _productionOrderService;

        public ProductionOrderController(IProductionOrderService productionOrderService)
        {
            _productionOrderService = productionOrderService;
        }

        #region Get All Production Orders

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _productionOrderService.GetAllAsync();
            return Ok(orders);
        }

        #endregion

        #region Get Production Order By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _productionOrderService.GetByIdAsync(id);

            if (order == null)
                return NotFound($"Production Order with Id {id} not found.");

            return Ok(order);
        }

        #endregion

        #region Get Production Order By Order Number

        [HttpGet("order-number/{orderNumber}")]
        public async Task<IActionResult> GetByOrderNumber(string orderNumber)
        {
            var order = await _productionOrderService.GetByOrderNumberAsync(orderNumber);

            if (order == null)
                return NotFound($"Production Order '{orderNumber}' not found.");

            return Ok(order);
        }

        #endregion

        #region Get Production Orders By Product

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var orders = await _productionOrderService.GetByProductAsync(productId);

            if (!orders.Any())
                return NotFound("No Production Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Get Production Orders By Machine

        [HttpGet("machine/{machineId:int}")]
        public async Task<IActionResult> GetByMachine(int machineId)
        {
            var orders = await _productionOrderService.GetByMachineAsync(machineId);

            if (!orders.Any())
                return NotFound("No Production Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Search Production Orders

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var orders = await _productionOrderService.SearchAsync(keyword);

            if (!orders.Any())
                return NotFound("No matching Production Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Get Production Orders By Status

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var orders = await _productionOrderService.GetByStatusAsync(status);

            if (!orders.Any())
                return NotFound("No Production Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Get Production Orders By Priority

        [HttpGet("priority/{priority}")]
        public async Task<IActionResult> GetByPriority(byte priority)
        {
            var orders = await _productionOrderService.GetByPriorityAsync(priority);

            if (!orders.Any())
                return NotFound("No Production Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Get Production Orders By Date Range

        [HttpGet("date-range")]
        public async Task<IActionResult> GetByDateRange(
            [FromQuery] DateOnly fromDate,
            [FromQuery] DateOnly toDate)
        {
            var orders = await _productionOrderService.GetByDateRangeAsync(fromDate, toDate);

            if (!orders.Any())
                return NotFound("No Production Orders found for the given date range.");

            return Ok(orders);
        }

        #endregion

        #region Get Open Production Orders

        [HttpGet("open-orders")]
        public async Task<IActionResult> GetOpenOrders()
        {
            var orders = await _productionOrderService.GetOpenOrdersAsync();

            if (!orders.Any())
                return NotFound("No open Production Orders found.");

            return Ok(orders);
        }

        #endregion

        #region Check Order Number Exists

        [HttpGet("exists/{orderNumber}")]
        public async Task<IActionResult> IsOrderNumberExists(string orderNumber)
        {
            var exists = await _productionOrderService.IsOrderNumberExistsAsync(orderNumber);

            return Ok(exists);
        }

        #endregion

        #region Create Production Order

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductionOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _productionOrderService.IsOrderNumberExistsAsync(dto.OrderNumber);

            if (exists)
                return BadRequest("Order Number already exists.");

            await _productionOrderService.CreateAsync(dto);

            return Ok("Production Order created successfully.");
        }

        #endregion

        #region Update Production Order

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductionOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingOrder = await _productionOrderService.GetByIdAsync(dto.ProductionOrderId);

            if (existingOrder == null)
                return NotFound($"Production Order with Id {dto.ProductionOrderId} not found.");

            await _productionOrderService.UpdateAsync(dto);

            return Ok("Production Order updated successfully.");
        }

        #endregion

        #region Delete Production Order

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingOrder = await _productionOrderService.GetByIdAsync(id);

            if (existingOrder == null)
                return NotFound($"Production Order with Id {id} not found.");

            await _productionOrderService.DeleteAsync(id);

            return Ok("Production Order deleted successfully.");
        }

        #endregion
    }
}