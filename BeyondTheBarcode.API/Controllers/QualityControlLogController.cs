using BeyondTheBarcode.Application.DTOs.QualityControlLogDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityControlLogController : ControllerBase
    {
        private readonly IQualityControlLogService _qualityControlLogService;

        public QualityControlLogController(IQualityControlLogService qualityControlLogService)
        {
            _qualityControlLogService = qualityControlLogService;
        }

        #region Get All Quality Control Logs

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _qualityControlLogService.GetAllAsync();
            return Ok(logs);
        }

        #endregion

        #region Get Quality Control Log By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var log = await _qualityControlLogService.GetByIdAsync(id);

            if (log == null)
                return NotFound($"Quality Control Log with Id {id} not found.");

            return Ok(log);
        }

        #endregion

        #region Get Quality Control Log By Reference

        [HttpGet("reference/{reference}")]
        public async Task<IActionResult> GetByReference(string reference)
        {
            var log = await _qualityControlLogService.GetByReferenceAsync(reference);

            if (log == null)
                return NotFound($"Quality Control Log with Reference '{reference}' not found.");

            return Ok(log);
        }

        #endregion

        #region Get Quality Control Logs By Production Order

        [HttpGet("production-order/{productionOrderId:int}")]
        public async Task<IActionResult> GetByProductionOrder(int productionOrderId)
        {
            var logs = await _qualityControlLogService.GetByProductionOrderAsync(productionOrderId);

            if (!logs.Any())
                return NotFound("No Quality Control Logs found.");

            return Ok(logs);
        }

        #endregion

        #region Get Quality Control Logs By Product

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var logs = await _qualityControlLogService.GetByProductAsync(productId);

            if (!logs.Any())
                return NotFound("No Quality Control Logs found.");

            return Ok(logs);
        }

        #endregion

        #region Get Quality Control Logs By Raw Material

        [HttpGet("raw-material/{rawMaterialId:int}")]
        public async Task<IActionResult> GetByRawMaterial(int rawMaterialId)
        {
            var logs = await _qualityControlLogService.GetByRawMaterialAsync(rawMaterialId);

            if (!logs.Any())
                return NotFound("No Quality Control Logs found.");

            return Ok(logs);
        }

        #endregion

        #region Search Quality Control Logs

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var logs = await _qualityControlLogService.SearchAsync(keyword);

            if (!logs.Any())
                return NotFound("No matching Quality Control Logs found.");

            return Ok(logs);
        }

        #endregion

        #region Get Released Quality Control Logs

        [HttpGet("released")]
        public async Task<IActionResult> GetReleased()
        {
            var logs = await _qualityControlLogService.GetReleasedAsync();

            if (!logs.Any())
                return NotFound("No released Quality Control Logs found.");

            return Ok(logs);
        }

        #endregion

        #region Get Pending Quality Control Logs

        [HttpGet("pending")]
        public async Task<IActionResult> GetPending()
        {
            var logs = await _qualityControlLogService.GetPendingAsync();

            if (!logs.Any())
                return NotFound("No pending Quality Control Logs found.");

            return Ok(logs);
        }

        #endregion

        #region Get Quality Control Logs By Result

        [HttpGet("result/{result}")]
        public async Task<IActionResult> GetByResult(string result)
        {
            var logs = await _qualityControlLogService.GetByResultAsync(result);

            if (!logs.Any())
                return NotFound("No Quality Control Logs found.");

            return Ok(logs);
        }

        #endregion

        #region Check QC Reference Exists

        [HttpGet("exists/{reference}")]
        public async Task<IActionResult> IsReferenceExists(string reference)
        {
            var exists = await _qualityControlLogService.IsReferenceExistsAsync(reference);

            return Ok(exists);
        }

        #endregion

        #region Create Quality Control Log

        [HttpPost]
        public async Task<IActionResult> Create(CreateQualityControlLogDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _qualityControlLogService.IsReferenceExistsAsync(dto.QcreferenceNumber);

            if (exists)
                return BadRequest("QC Reference already exists.");

            await _qualityControlLogService.CreateAsync(dto);

            return Ok("Quality Control Log created successfully.");
        }

        #endregion

        #region Update Quality Control Log

        [HttpPut]
        public async Task<IActionResult> Update(UpdateQualityControlLogDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingLog = await _qualityControlLogService.GetByIdAsync(dto.Qcid);

            if (existingLog == null)
                return NotFound($"Quality Control Log with Id {dto.Qcid} not found.");

            await _qualityControlLogService.UpdateAsync(dto);

            return Ok("Quality Control Log updated successfully.");
        }

        #endregion

        #region Delete Quality Control Log

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingLog = await _qualityControlLogService.GetByIdAsync(id);

            if (existingLog == null)
                return NotFound($"Quality Control Log with Id {id} not found.");

            await _qualityControlLogService.DeleteAsync(id);

            return Ok("Quality Control Log deleted successfully.");
        }

        #endregion
    }
}







