using BeyondTheBarcode.Application.DTOs.WarehouseBinDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseBinController : ControllerBase
    {
        private readonly IWarehouseBinService _warehouseBinService;

        public WarehouseBinController(IWarehouseBinService warehouseBinService)
        {
            _warehouseBinService = warehouseBinService;
        }

        #region Get All Warehouse Bins

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bins = await _warehouseBinService.GetAllAsync();
            return Ok(bins);
        }

        #endregion

        #region Get Warehouse Bin By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bin = await _warehouseBinService.GetByIdAsync(id);

            if (bin == null)
                return NotFound($"Warehouse Bin with Id {id} not found.");

            return Ok(bin);
        }

        #endregion

        #region Get Warehouse Bin By Code

        [HttpGet("code/{binCode}")]
        public async Task<IActionResult> GetByCode(string binCode)
        {
            var bin = await _warehouseBinService.GetByCodeAsync(binCode);

            if (bin == null)
                return NotFound($"Warehouse Bin with code '{binCode}' not found.");

            return Ok(bin);
        }

        #endregion

        #region Get Warehouse Bins By Warehouse

        [HttpGet("warehouse/{warehouse}")]
        public async Task<IActionResult> GetByWarehouse(string warehouse)
        {
            var bins = await _warehouseBinService.GetByWarehouseAsync(warehouse);

            if (!bins.Any())
                return NotFound("No Warehouse Bins found.");

            return Ok(bins);
        }

        #endregion

        #region Search Warehouse Bins

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var bins = await _warehouseBinService.SearchAsync(keyword);

            if (!bins.Any())
                return NotFound("No matching Warehouse Bins found.");

            return Ok(bins);
        }

        #endregion

        #region Get Active Warehouse Bins

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var bins = await _warehouseBinService.GetActiveAsync();

            if (!bins.Any())
                return NotFound("No active Warehouse Bins found.");

            return Ok(bins);
        }

        #endregion

        #region Get Inactive Warehouse Bins

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactive()
        {
            var bins = await _warehouseBinService.GetInactiveAsync();

            if (!bins.Any())
                return NotFound("No inactive Warehouse Bins found.");

            return Ok(bins);
        }

        #endregion

        #region Check Bin Code Exists

        [HttpGet("exists/{binCode}")]
        public async Task<IActionResult> IsBinCodeExists(string binCode)
        {
            var exists = await _warehouseBinService.IsBinCodeExistsAsync(binCode);

            return Ok(exists);
        }

        #endregion

        #region Create Warehouse Bin

        [HttpPost]
        public async Task<IActionResult> Create(CreateWarehouseBinDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _warehouseBinService.IsBinCodeExistsAsync(dto.BinCode);

            if (exists)
                return BadRequest("Bin Code already exists.");

            await _warehouseBinService.CreateAsync(dto);

            return Ok("Warehouse Bin created successfully.");
        }

        #endregion

        #region Update Warehouse Bin

        [HttpPut]
        public async Task<IActionResult> Update(UpdateWarehouseBinDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingBin = await _warehouseBinService.GetByIdAsync(dto.BinId);

            if (existingBin == null)
                return NotFound($"Warehouse Bin with Id {dto.BinId} not found.");

            await _warehouseBinService.UpdateAsync(dto);

            return Ok("Warehouse Bin updated successfully.");
        }

        #endregion

        #region Delete Warehouse Bin

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingBin = await _warehouseBinService.GetByIdAsync(id);

            if (existingBin == null)
                return NotFound($"Warehouse Bin with Id {id} not found.");

            await _warehouseBinService.DeleteAsync(id);

            return Ok("Warehouse Bin deleted successfully.");
        }

        #endregion
    }
}