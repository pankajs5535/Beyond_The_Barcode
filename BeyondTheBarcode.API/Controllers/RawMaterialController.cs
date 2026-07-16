using BeyondTheBarcode.Application.DTOs.RawMaterialDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialController : ControllerBase
    {
        private readonly IRawMaterialService _rawMaterialService;

        public RawMaterialController(IRawMaterialService rawMaterialService)
        {
            _rawMaterialService = rawMaterialService;
        }

        #region Get All Raw Materials

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rawMaterials = await _rawMaterialService.GetAllAsync();
            return Ok(rawMaterials);
        }

        #endregion

        #region Get Raw Material By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rawMaterial = await _rawMaterialService.GetByIdAsync(id);

            if (rawMaterial == null)
                return NotFound($"Raw Material with Id {id} not found.");

            return Ok(rawMaterial);
        }

        #endregion

        #region Get Raw Material By Code

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var rawMaterial = await _rawMaterialService.GetByCodeAsync(code);

            if (rawMaterial == null)
                return NotFound($"Raw Material with code '{code}' not found.");

            return Ok(rawMaterial);
        }

        #endregion

        #region Get Raw Materials By Type

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            var rawMaterials = await _rawMaterialService.GetByTypeAsync(type);

            if (!rawMaterials.Any())
                return NotFound("No Raw Materials found.");

            return Ok(rawMaterials);
        }

        #endregion

        #region Search Raw Materials

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var rawMaterials = await _rawMaterialService.SearchAsync(keyword);

            if (!rawMaterials.Any())
                return NotFound("No matching Raw Materials found.");

            return Ok(rawMaterials);
        }

        #endregion

        #region Get Active Raw Materials

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var rawMaterials = await _rawMaterialService.GetActiveAsync();

            if (!rawMaterials.Any())
                return NotFound("No active Raw Materials found.");

            return Ok(rawMaterials);
        }

        #endregion

        #region Get Inactive Raw Materials

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactive()
        {
            var rawMaterials = await _rawMaterialService.GetInactiveAsync();

            if (!rawMaterials.Any())
                return NotFound("No inactive Raw Materials found.");

            return Ok(rawMaterials);
        }

        #endregion

        #region Get Raw Materials By Date Range

        [HttpGet("date-range")]
        public async Task<IActionResult> GetByDateRange(
            [FromQuery] DateTime fromDate,
            [FromQuery] DateTime toDate)
        {
            var rawMaterials = await _rawMaterialService.GetByDateRangeAsync(fromDate, toDate);

            if (!rawMaterials.Any())
                return NotFound("No Raw Materials found for the given date range.");

            return Ok(rawMaterials);
        }

        #endregion

        #region Get Low Stock Raw Materials

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStock()
        {
            var rawMaterials = await _rawMaterialService.GetLowStockAsync();

            if (!rawMaterials.Any())
                return NotFound("No low stock Raw Materials found.");

            return Ok(rawMaterials);
        }

        #endregion

        #region Get Raw Materials By Supplier

        [HttpGet("supplier/{supplierId:int}")]
        public async Task<IActionResult> GetBySupplier(int supplierId)
        {
            var rawMaterials = await _rawMaterialService.GetBySupplierAsync(supplierId);

            if (!rawMaterials.Any())
                return NotFound("No Raw Materials found for the specified supplier.");

            return Ok(rawMaterials);
        }

        #endregion

        #region Get Controlled Substances

        [HttpGet("controlled-substances")]
        public async Task<IActionResult> GetControlledSubstances()
        {
            var rawMaterials = await _rawMaterialService.GetControlledSubstancesAsync();

            if (!rawMaterials.Any())
                return NotFound("No controlled substances found.");

            return Ok(rawMaterials);
        }

        #endregion

        #region Check Material Code Exists

        [HttpGet("exists/{materialCode}")]
        public async Task<IActionResult> IsMaterialCodeExists(string materialCode)
        {
            var exists = await _rawMaterialService.IsMaterialCodeExistsAsync(materialCode);

            return Ok(exists);
        }

        #endregion

        #region Create Raw Material

        [HttpPost]
        public async Task<IActionResult> Create(CreateRawMaterialDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _rawMaterialService.IsMaterialCodeExistsAsync(dto.MaterialCode);

            if (exists)
                return BadRequest("Material Code already exists.");

            await _rawMaterialService.CreateAsync(dto);

            return Ok("Raw Material created successfully.");
        }

        #endregion


        #region Update Raw Material

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRawMaterialDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRawMaterial = await _rawMaterialService.GetByIdAsync(dto.RawMaterialId);

            if (existingRawMaterial == null)
                return NotFound($"Raw Material with Id {dto.RawMaterialId} not found.");

            await _rawMaterialService.UpdateAsync(dto);

            return Ok("Raw Material updated successfully.");
        }

        #endregion

        #region Delete Raw Material

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingRawMaterial = await _rawMaterialService.GetByIdAsync(id);

            if (existingRawMaterial == null)
                return NotFound($"Raw Material with Id {id} not found.");

            await _rawMaterialService.DeleteAsync(id);

            return Ok("Raw Material deleted successfully.");
        }

        #endregion
    }
}