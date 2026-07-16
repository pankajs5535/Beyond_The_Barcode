using BeyondTheBarcode.Application.DTOs.BillOfMaterialsBomDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillOfMaterialsBomController : ControllerBase
    {
        private readonly IBillOfMaterialsBomService _billOfMaterialsBomService;

        public BillOfMaterialsBomController(IBillOfMaterialsBomService billOfMaterialsBomService)
        {
            _billOfMaterialsBomService = billOfMaterialsBomService;
        }

        #region Get All BOMs

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var boms = await _billOfMaterialsBomService.GetAllAsync();
            return Ok(boms);
        }

        #endregion

        #region Get BOM By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bom = await _billOfMaterialsBomService.GetByIdAsync(id);

            if (bom == null)
                return NotFound($"BOM with Id {id} not found.");

            return Ok(bom);
        }

        #endregion

        #region Get BOM By Version

        [HttpGet("version/{version}")]
        public async Task<IActionResult> GetByVersion(string version)
        {
            var bom = await _billOfMaterialsBomService.GetByVersionAsync(version);

            if (bom == null)
                return NotFound($"BOM Version '{version}' not found.");

            return Ok(bom);
        }

        #endregion

        #region Get BOMs By Product

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var boms = await _billOfMaterialsBomService.GetByProductAsync(productId);

            if (!boms.Any())
                return NotFound("No BOMs found.");

            return Ok(boms);
        }

        #endregion

        #region Get BOMs By Raw Material

        [HttpGet("raw-material/{rawMaterialId:int}")]
        public async Task<IActionResult> GetByRawMaterial(int rawMaterialId)
        {
            var boms = await _billOfMaterialsBomService.GetByRawMaterialAsync(rawMaterialId);

            if (!boms.Any())
                return NotFound("No BOMs found.");

            return Ok(boms);
        }

        #endregion

        #region Search BOMs

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var boms = await _billOfMaterialsBomService.SearchAsync(keyword);

            if (!boms.Any())
                return NotFound("No matching BOMs found.");

            return Ok(boms);
        }

        #endregion

        #region Get Active BOMs

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var boms = await _billOfMaterialsBomService.GetActiveAsync();

            if (!boms.Any())
                return NotFound("No active BOMs found.");

            return Ok(boms);
        }

        #endregion

        #region Get BOMs By Effective Date

        [HttpGet("effective-date")]
        public async Task<IActionResult> GetByEffectiveDate(
            [FromQuery] DateOnly fromDate,
            [FromQuery] DateOnly toDate)
        {
            var boms = await _billOfMaterialsBomService.GetByEffectiveDateAsync(fromDate, toDate);

            if (!boms.Any())
                return NotFound("No BOMs found.");

            return Ok(boms);
        }

        #endregion

        #region Get Critical Components

        [HttpGet("critical-components")]
        public async Task<IActionResult> GetCriticalComponents()
        {
            var boms = await _billOfMaterialsBomService.GetCriticalComponentsAsync();

            if (!boms.Any())
                return NotFound("No critical component BOMs found.");

            return Ok(boms);
        }

        #endregion

        #region Get Substitute Allowed BOMs

        [HttpGet("substitute-allowed")]
        public async Task<IActionResult> GetSubstituteAllowed()
        {
            var boms = await _billOfMaterialsBomService.GetSubstituteAllowedAsync();

            if (!boms.Any())
                return NotFound("No substitute allowed BOMs found.");

            return Ok(boms);
        }

        #endregion

        #region Check BOM Version Exists

        [HttpGet("exists/{version}")]
        public async Task<IActionResult> IsBomVersionExists(string version)
        {
            var exists = await _billOfMaterialsBomService.IsBomVersionExistsAsync(version);

            return Ok(exists);
        }

        #endregion

        #region Create BOM

        [HttpPost]
        public async Task<IActionResult> Create(CreateBillOfMaterialsBomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _billOfMaterialsBomService.IsBomVersionExistsAsync(dto.Bomversion);

            if (exists)
                return BadRequest("BOM Version already exists.");

            await _billOfMaterialsBomService.CreateAsync(dto);

            return Ok("BOM created successfully.");
        }

        #endregion

        #region Update BOM

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBillOfMaterialsBomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingBom = await _billOfMaterialsBomService.GetByIdAsync(dto.Bomid);

            if (existingBom == null)
                return NotFound($"BOM with Id {dto.Bomid} not found.");

            await _billOfMaterialsBomService.UpdateAsync(dto);

            return Ok("BOM updated successfully.");
        }

        #endregion

        #region Delete BOM

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingBom = await _billOfMaterialsBomService.GetByIdAsync(id);

            if (existingBom == null)
                return NotFound($"BOM with Id {id} not found.");

            await _billOfMaterialsBomService.DeleteAsync(id);

            return Ok("BOM deleted successfully.");
        }

        #endregion
    }
}