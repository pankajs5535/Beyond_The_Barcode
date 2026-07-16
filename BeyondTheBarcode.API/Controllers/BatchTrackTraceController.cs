using BeyondTheBarcode.Application.DTOs.BatchTrackTraceDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchTrackTraceController : ControllerBase
    {
        private readonly IBatchTrackTraceService _batchTrackTraceService;

        public BatchTrackTraceController(IBatchTrackTraceService batchTrackTraceService)
        {
            _batchTrackTraceService = batchTrackTraceService;
        }

        #region Get All Batch Traces

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var traces = await _batchTrackTraceService.GetAllAsync();
            return Ok(traces);
        }

        #endregion

        #region Get Batch Trace By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trace = await _batchTrackTraceService.GetByIdAsync(id);

            if (trace == null)
                return NotFound($"Batch Trace with Id {id} not found.");

            return Ok(trace);
        }

        #endregion

        #region Get Batch Trace By Trace Number

        [HttpGet("trace/{traceNumber}")]
        public async Task<IActionResult> GetByTraceNumber(string traceNumber)
        {
            var trace = await _batchTrackTraceService.GetByTraceNumberAsync(traceNumber);

            if (trace == null)
                return NotFound($"Batch Trace '{traceNumber}' not found.");

            return Ok(trace);
        }

        #endregion

        #region Get Batch Traces By Batch Number

        [HttpGet("batch/{batchNumber}")]
        public async Task<IActionResult> GetByBatch(string batchNumber)
        {
            var traces = await _batchTrackTraceService.GetByBatchAsync(batchNumber);

            if (!traces.Any())
                return NotFound("No Batch Traces found.");

            return Ok(traces);
        }

        #endregion

        #region Get Batch Traces By Product

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var traces = await _batchTrackTraceService.GetByProductAsync(productId);

            if (!traces.Any())
                return NotFound("No Batch Traces found.");

            return Ok(traces);
        }

        #endregion

        #region Get Batch Traces By Production Order

        [HttpGet("production-order/{productionOrderId:int}")]
        public async Task<IActionResult> GetByProductionOrder(int productionOrderId)
        {
            var traces = await _batchTrackTraceService.GetByProductionOrderAsync(productionOrderId);

            if (!traces.Any())
                return NotFound("No Batch Traces found.");

            return Ok(traces);
        }

        #endregion

        #region Search Batch Traces

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var traces = await _batchTrackTraceService.SearchAsync(keyword);

            if (!traces.Any())
                return NotFound("No matching Batch Traces found.");

            return Ok(traces);
        }

        #endregion

        #region Get Recalled Batches

        [HttpGet("recalled")]
        public async Task<IActionResult> GetRecalled()
        {
            var traces = await _batchTrackTraceService.GetRecalledAsync();

            if (!traces.Any())
                return NotFound("No recalled Batch Traces found.");

            return Ok(traces);
        }

        #endregion

        #region Get Destroyed Batches

        [HttpGet("destroyed")]
        public async Task<IActionResult> GetDestroyed()
        {
            var traces = await _batchTrackTraceService.GetDestroyedAsync();

            if (!traces.Any())
                return NotFound("No destroyed Batch Traces found.");

            return Ok(traces);
        }

        #endregion

        #region Get Batch Traces By Customer

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            var traces = await _batchTrackTraceService.GetByCustomerAsync(customerId);

            if (!traces.Any())
                return NotFound("No Batch Traces found.");

            return Ok(traces);
        }

        #endregion

        #region Check Trace Number Exists

        [HttpGet("exists/{traceNumber}")]
        public async Task<IActionResult> IsTraceNumberExists(string traceNumber)
        {
            var exists = await _batchTrackTraceService.IsTraceNumberExistsAsync(traceNumber);

            return Ok(exists);
        }

        #endregion
        #region Create Batch Trace

        [HttpPost]
        public async Task<IActionResult> Create(CreateBatchTrackTraceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _batchTrackTraceService.IsTraceNumberExistsAsync(dto.TraceNumber);

            if (exists)
                return BadRequest("Trace Number already exists.");

            await _batchTrackTraceService.CreateAsync(dto);

            return Ok("Batch Trace created successfully.");
        }

        #endregion

        #region Update Batch Trace

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBatchTrackTraceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTrace = await _batchTrackTraceService.GetByIdAsync(dto.TraceId);

            if (existingTrace == null)
                return NotFound($"Batch Trace with Id {dto.TraceId} not found.");

            await _batchTrackTraceService.UpdateAsync(dto);

            return Ok("Batch Trace updated successfully.");
        }

        #endregion

        #region Delete Batch Trace

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTrace = await _batchTrackTraceService.GetByIdAsync(id);

            if (existingTrace == null)
                return NotFound($"Batch Trace with Id {id} not found.");

            await _batchTrackTraceService.DeleteAsync(id);

            return Ok("Batch Trace deleted successfully.");
        }

        #endregion
    }
}