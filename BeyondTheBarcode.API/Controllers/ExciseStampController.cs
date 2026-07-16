using BeyondTheBarcode.Application.DTOs.ExciseStampDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExciseStampController : ControllerBase
    {
        private readonly IExciseStampService _exciseStampService;

        public ExciseStampController(IExciseStampService exciseStampService)
        {
            _exciseStampService = exciseStampService;
        }

        #region Get All Excise Stamps

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stamps = await _exciseStampService.GetAllAsync();
            return Ok(stamps);
        }

        #endregion

        #region Get Excise Stamp By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stamp = await _exciseStampService.GetByIdAsync(id);

            if (stamp == null)
                return NotFound($"Excise Stamp with Id {id} not found.");

            return Ok(stamp);
        }

        #endregion

        #region Get Excise Stamp By Serial Number

        [HttpGet("serial/{serialNumber}")]
        public async Task<IActionResult> GetBySerialNumber(string serialNumber)
        {
            var stamp = await _exciseStampService.GetBySerialNumberAsync(serialNumber);

            if (stamp == null)
                return NotFound($"Excise Stamp '{serialNumber}' not found.");

            return Ok(stamp);
        }

        #endregion

        #region Get Excise Stamps By Product

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var stamps = await _exciseStampService.GetByProductAsync(productId);

            if (!stamps.Any())
                return NotFound("No Excise Stamps found.");

            return Ok(stamps);
        }

        #endregion

        #region Get Excise Stamps By Production Order

        [HttpGet("production-order/{productionOrderId:int}")]
        public async Task<IActionResult> GetByProductionOrder(int productionOrderId)
        {
            var stamps = await _exciseStampService.GetByProductionOrderAsync(productionOrderId);

            if (!stamps.Any())
                return NotFound("No Excise Stamps found.");

            return Ok(stamps);
        }

        #endregion

        #region Search Excise Stamps

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var stamps = await _exciseStampService.SearchAsync(keyword);

            if (!stamps.Any())
                return NotFound("No matching Excise Stamps found.");

            return Ok(stamps);
        }

        #endregion

        #region Get Excise Stamps By Status

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var stamps = await _exciseStampService.GetByStatusAsync(status);

            if (!stamps.Any())
                return NotFound("No Excise Stamps found.");

            return Ok(stamps);
        }

        #endregion



        #region Get Available Excise Stamps

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var stamps = await _exciseStampService.GetAvailableAsync();

            if (!stamps.Any())
                return NotFound("No available Excise Stamps found.");

            return Ok(stamps);
        }

        #endregion

        #region Get Applied Excise Stamps

        [HttpGet("applied")]
        public async Task<IActionResult> GetApplied()
        {
            var stamps = await _exciseStampService.GetAppliedAsync();

            if (!stamps.Any())
                return NotFound("No applied Excise Stamps found.");

            return Ok(stamps);
        }

        #endregion

        #region Get Excise Stamps By Storage Bin

        [HttpGet("storage-bin/{binId:int}")]
        public async Task<IActionResult> GetByStorageBin(int binId)
        {
            var stamps = await _exciseStampService.GetByStorageBinAsync(binId);

            if (!stamps.Any())
                return NotFound("No Excise Stamps found.");

            return Ok(stamps);
        }

        #endregion

        #region Check Serial Number Exists

        [HttpGet("exists/{serialNumber}")]
        public async Task<IActionResult> IsSerialNumberExists(string serialNumber)
        {
            var exists = await _exciseStampService.IsSerialNumberExistsAsync(serialNumber);

            return Ok(exists);
        }

        #endregion

        #region Create Excise Stamp

        [HttpPost]
        public async Task<IActionResult> Create(CreateExciseStampDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _exciseStampService.IsSerialNumberExistsAsync(dto.StampSerialNumber);

            if (exists)
                return BadRequest("Stamp Serial Number already exists.");

            await _exciseStampService.CreateAsync(dto);

            return Ok("Excise Stamp created successfully.");
        }

        #endregion

        #region Update Excise Stamp

        [HttpPut]
        public async Task<IActionResult> Update(UpdateExciseStampDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingStamp = await _exciseStampService.GetByIdAsync(dto.StampId);

            if (existingStamp == null)
                return NotFound($"Excise Stamp with Id {dto.StampId} not found.");

            await _exciseStampService.UpdateAsync(dto);

            return Ok("Excise Stamp updated successfully.");
        }

        #endregion

        #region Delete Excise Stamp

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingStamp = await _exciseStampService.GetByIdAsync(id);

            if (existingStamp == null)
                return NotFound($"Excise Stamp with Id {id} not found.");

            await _exciseStampService.DeleteAsync(id);

            return Ok("Excise Stamp deleted successfully.");
        }

        #endregion
    }
}