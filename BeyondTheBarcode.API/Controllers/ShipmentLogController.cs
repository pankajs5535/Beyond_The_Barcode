using BeyondTheBarcode.Application.DTOs.ShipmentLogDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentLogController : ControllerBase
    {
        private readonly IShipmentLogService _shipmentLogService;

        public ShipmentLogController(IShipmentLogService shipmentLogService)
        {
            _shipmentLogService = shipmentLogService;
        }

        #region Get All Shipments

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shipments = await _shipmentLogService.GetAllAsync();
            return Ok(shipments);
        }

        #endregion

        #region Get Shipment By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shipment = await _shipmentLogService.GetByIdAsync(id);

            if (shipment == null)
                return NotFound($"Shipment with Id {id} not found.");

            return Ok(shipment);
        }

        #endregion

        #region Get Shipment By Shipment Number

        [HttpGet("number/{shipmentNumber}")]
        public async Task<IActionResult> GetByShipmentNumber(string shipmentNumber)
        {
            var shipment = await _shipmentLogService.GetByShipmentNumberAsync(shipmentNumber);

            if (shipment == null)
                return NotFound($"Shipment '{shipmentNumber}' not found.");

            return Ok(shipment);
        }

        #endregion

        #region Get Shipments By Sales Order

        [HttpGet("sales-order/{salesOrderId:int}")]
        public async Task<IActionResult> GetBySalesOrder(int salesOrderId)
        {
            var shipments = await _shipmentLogService.GetBySalesOrderAsync(salesOrderId);

            if (!shipments.Any())
                return NotFound("No Shipments found.");

            return Ok(shipments);
        }

        #endregion

        #region Get Shipments By Pick & Pack

        [HttpGet("pick-pack/{pickPackId:int}")]
        public async Task<IActionResult> GetByPickPack(int pickPackId)
        {
            var shipments = await _shipmentLogService.GetByPickPackAsync(pickPackId);

            if (!shipments.Any())
                return NotFound("No Shipments found.");

            return Ok(shipments);
        }

        #endregion

        #region Search Shipments

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var shipments = await _shipmentLogService.SearchAsync(keyword);

            if (!shipments.Any())
                return NotFound("No matching Shipments found.");

            return Ok(shipments);
        }

        #endregion

        #region Get Shipments By Status

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var shipments = await _shipmentLogService.GetByStatusAsync(status);

            if (!shipments.Any())
                return NotFound("No Shipments found.");

            return Ok(shipments);
        }

        #endregion

        #region Get Delivered Shipments

        [HttpGet("delivered")]
        public async Task<IActionResult> GetDelivered()
        {
            var shipments = await _shipmentLogService.GetDeliveredAsync();

            if (!shipments.Any())
                return NotFound("No delivered Shipments found.");

            return Ok(shipments);
        }

        #endregion

        #region Get Pending Deliveries

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingDeliveries()
        {
            var shipments = await _shipmentLogService.GetPendingDeliveriesAsync();

            if (!shipments.Any())
                return NotFound("No pending deliveries found.");

            return Ok(shipments);
        }

        #endregion

        #region Get Shipments By Transporter

        [HttpGet("transporter/{transporter}")]
        public async Task<IActionResult> GetByTransporter(string transporter)
        {
            var shipments = await _shipmentLogService.GetByTransporterAsync(transporter);

            if (!shipments.Any())
                return NotFound("No Shipments found.");

            return Ok(shipments);
        }

        #endregion

        #region Check Shipment Number Exists

        [HttpGet("exists/{shipmentNumber}")]
        public async Task<IActionResult> IsShipmentNumberExists(string shipmentNumber)
        {
            var exists = await _shipmentLogService.IsShipmentNumberExistsAsync(shipmentNumber);

            return Ok(exists);
        }

        #endregion

        #region Create Shipment

        [HttpPost]
        public async Task<IActionResult> Create(CreateShipmentLogDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _shipmentLogService.IsShipmentNumberExistsAsync(dto.ShipmentNumber);

            if (exists)
                return BadRequest("Shipment Number already exists.");

            await _shipmentLogService.CreateAsync(dto);

            return Ok("Shipment created successfully.");
        }

        #endregion

        #region Update Shipment

        [HttpPut]
        public async Task<IActionResult> Update(UpdateShipmentLogDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _shipmentLogService.GetByIdAsync(dto.ShipmentId);

            if (existing == null)
                return NotFound($"Shipment with Id {dto.ShipmentId} not found.");

            await _shipmentLogService.UpdateAsync(dto);

            return Ok("Shipment updated successfully.");
        }

        #endregion

        #region Delete Shipment

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _shipmentLogService.GetByIdAsync(id);

            if (existing == null)
                return NotFound($"Shipment with Id {id} not found.");

            await _shipmentLogService.DeleteAsync(id);

            return Ok("Shipment deleted successfully.");
        }

        #endregion
    }
}