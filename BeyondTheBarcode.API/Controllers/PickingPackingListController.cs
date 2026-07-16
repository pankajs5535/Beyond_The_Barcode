using BeyondTheBarcode.Application.DTOs.PickingPackingListDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickingPackingListController : ControllerBase
    {
        private readonly IPickingPackingListService _pickingPackingListService;

        public PickingPackingListController(IPickingPackingListService pickingPackingListService)
        {
            _pickingPackingListService = pickingPackingListService;
        }

        #region Get All Pick & Pack Records

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lists = await _pickingPackingListService.GetAllAsync();
            return Ok(lists);
        }

        #endregion

        #region Get Pick & Pack By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var list = await _pickingPackingListService.GetByIdAsync(id);

            if (list == null)
                return NotFound($"Picking & Packing record with Id {id} not found.");

            return Ok(list);
        }

        #endregion

        #region Get Pick & Pack By Number

        [HttpGet("number/{pickPackNumber}")]
        public async Task<IActionResult> GetByNumber(string pickPackNumber)
        {
            var list = await _pickingPackingListService.GetByNumberAsync(pickPackNumber);

            if (list == null)
                return NotFound($"Pick & Pack '{pickPackNumber}' not found.");

            return Ok(list);
        }

        #endregion

        #region Get Pick & Pack By Sales Order

        [HttpGet("sales-order/{salesOrderId:int}")]
        public async Task<IActionResult> GetBySalesOrder(int salesOrderId)
        {
            var lists = await _pickingPackingListService.GetBySalesOrderAsync(salesOrderId);

            if (!lists.Any())
                return NotFound("No Pick & Pack records found.");

            return Ok(lists);
        }

        #endregion

        #region Get Pick & Pack By Product

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var lists = await _pickingPackingListService.GetByProductAsync(productId);

            if (!lists.Any())
                return NotFound("No Pick & Pack records found.");

            return Ok(lists);
        }

        #endregion

        #region Search Pick & Pack Records

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var lists = await _pickingPackingListService.SearchAsync(keyword);

            if (!lists.Any())
                return NotFound("No matching Pick & Pack records found.");

            return Ok(lists);
        }

        #endregion

        #region Get Pick & Pack By Status

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var lists = await _pickingPackingListService.GetByStatusAsync(status);

            if (!lists.Any())
                return NotFound("No Pick & Pack records found.");

            return Ok(lists);
        }

        #endregion

        #region Get Ready For Dispatch

        [HttpGet("ready-for-dispatch")]
        public async Task<IActionResult> GetReadyForDispatch()
        {
            var lists = await _pickingPackingListService.GetReadyForDispatchAsync();

            if (!lists.Any())
                return NotFound("No Pick & Pack records ready for dispatch.");

            return Ok(lists);
        }

        #endregion

        #region Get Pick & Pack By Picker

        [HttpGet("picker/{pickerId:int}")]
        public async Task<IActionResult> GetByPicker(int pickerId)
        {
            var lists = await _pickingPackingListService.GetByPickerAsync(pickerId);

            if (!lists.Any())
                return NotFound("No Pick & Pack records found.");

            return Ok(lists);
        }

        #endregion

        #region Check Pick & Pack Number Exists

        [HttpGet("exists/{pickPackNumber}")]
        public async Task<IActionResult> IsPickPackNumberExists(string pickPackNumber)
        {
            var exists = await _pickingPackingListService.IsPickPackNumberExistsAsync(pickPackNumber);

            return Ok(exists);
        }

        #endregion


        #region Create Pick & Pack

        [HttpPost]
        public async Task<IActionResult> Create(CreatePickingPackingListDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _pickingPackingListService.IsPickPackNumberExistsAsync(dto.PickPackNumber);

            if (exists)
                return BadRequest("Pick & Pack Number already exists.");

            await _pickingPackingListService.CreateAsync(dto);

            return Ok("Picking & Packing record created successfully.");
        }

        #endregion

        #region Update Pick & Pack

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePickingPackingListDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _pickingPackingListService.GetByIdAsync(dto.PickPackId);

            if (existing == null)
                return NotFound($"Picking & Packing record with Id {dto.PickPackId} not found.");

            await _pickingPackingListService.UpdateAsync(dto);

            return Ok("Picking & Packing record updated successfully.");
        }

        #endregion

        #region Delete Pick & Pack

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _pickingPackingListService.GetByIdAsync(id);

            if (existing == null)
                return NotFound($"Picking & Packing record with Id {id} not found.");

            await _pickingPackingListService.DeleteAsync(id);

            return Ok("Picking & Packing record deleted successfully.");
        }

        #endregion
    }
}