using BeyondTheBarcode.Application.DTOs.WarehouseInventoryDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseInventoryController : ControllerBase
    {
        private readonly IWarehouseInventoryService _warehouseInventoryService;

        public WarehouseInventoryController(IWarehouseInventoryService warehouseInventoryService)
        {
            _warehouseInventoryService = warehouseInventoryService;
        }

        #region Get All Warehouse Inventory

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventories = await _warehouseInventoryService.GetAllAsync();
            return Ok(inventories);
        }

        #endregion

        #region Get Warehouse Inventory By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventory = await _warehouseInventoryService.GetByIdAsync(id);

            if (inventory == null)
                return NotFound($"Inventory with Id {id} not found.");

            return Ok(inventory);
        }

        #endregion

        #region Get Inventory By Product

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var inventories = await _warehouseInventoryService.GetByProductAsync(productId);

            if (!inventories.Any())
                return NotFound("No Inventory found.");

            return Ok(inventories);
        }

        #endregion

        #region Get Inventory By Raw Material

        [HttpGet("raw-material/{rawMaterialId:int}")]
        public async Task<IActionResult> GetByRawMaterial(int rawMaterialId)
        {
            var inventories = await _warehouseInventoryService.GetByRawMaterialAsync(rawMaterialId);

            if (!inventories.Any())
                return NotFound("No Inventory found.");

            return Ok(inventories);
        }

        #endregion

        #region Get Inventory By Warehouse Bin

        [HttpGet("warehouse-bin/{warehouseBinId:int}")]
        public async Task<IActionResult> GetByWarehouseBin(int warehouseBinId)
        {
            var inventories = await _warehouseInventoryService.GetByWarehouseBinAsync(warehouseBinId);

            if (!inventories.Any())
                return NotFound("No Inventory found.");

            return Ok(inventories);
        }

        #endregion

        #region Search Inventory

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var inventories = await _warehouseInventoryService.SearchAsync(keyword);

            if (!inventories.Any())
                return NotFound("No matching Inventory found.");

            return Ok(inventories);
        }

        #endregion

        #region Get Low Stock Inventory

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStock()
        {
            var inventories = await _warehouseInventoryService.GetLowStockAsync();

            if (!inventories.Any())
                return NotFound("No low stock Inventory found.");

            return Ok(inventories);
        }

        #endregion

        #region Get Expired Inventory

        [HttpGet("expired")]
        public async Task<IActionResult> GetExpired()
        {
            var inventories = await _warehouseInventoryService.GetExpiredAsync();

            if (!inventories.Any())
                return NotFound("No expired Inventory found.");

            return Ok(inventories);
        }

        #endregion


        #region Create Warehouse Inventory

        [HttpPost]
        public async Task<IActionResult> Create(CreateWarehouseInventoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _warehouseInventoryService.CreateAsync(dto);

            return Ok("Warehouse Inventory created successfully.");
        }

        #endregion

        #region Update Warehouse Inventory

        [HttpPut]
        public async Task<IActionResult> Update(UpdateWarehouseInventoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingInventory = await _warehouseInventoryService.GetByIdAsync(dto.InventoryId);

            if (existingInventory == null)
                return NotFound($"Warehouse Inventory with Id {dto.InventoryId} not found.");

            await _warehouseInventoryService.UpdateAsync(dto);

            return Ok("Warehouse Inventory updated successfully.");
        }

        #endregion

        #region Delete Warehouse Inventory

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingInventory = await _warehouseInventoryService.GetByIdAsync(id);

            if (existingInventory == null)
                return NotFound($"Warehouse Inventory with Id {id} not found.");

            await _warehouseInventoryService.DeleteAsync(id);

            return Ok("Warehouse Inventory deleted successfully.");
        }

        #endregion
    }
}