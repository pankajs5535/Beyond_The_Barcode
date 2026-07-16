using BeyondTheBarcode.Application.DTOs.SupplierDtos;
using BeyondTheBarcode.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        #region Get All Suppliers

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierService.GetAllAsync();
            return Ok(suppliers);
        }

        #endregion

        #region Get Supplier By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);

            if (supplier == null)
                return NotFound($"Supplier with Id {id} not found.");

            return Ok(supplier);
        }

        #endregion

        #region Get Supplier By Code

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var supplier = await _supplierService.GetByCodeAsync(code);

            if (supplier == null)
                return NotFound($"Supplier with Code '{code}' not found.");

            return Ok(supplier);
        }

        #endregion

        #region Create Supplier

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierDto dto)
        //public async Task<IActionResult> Create(CreateSupplierDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _supplierService.IsSupplierCodeExistsAsync(dto.SupplierCode))
                return BadRequest("Supplier Code already exists.");

            //if (await _supplierService.IsGstNumberExistsAsync(dto.Gstnumber))
            //    return BadRequest("GST Number already exists.");

            //if (await _supplierService.IsPanNumberExistsAsync(dto.Pannumber))
            //    return BadRequest("PAN Number already exists.");

            if (!string.IsNullOrWhiteSpace(dto.Gstnumber) &&
             await _supplierService.IsGstNumberExistsAsync(dto.Gstnumber))
            {
                return BadRequest("GST Number already exists.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Pannumber) &&
                await _supplierService.IsPanNumberExistsAsync(dto.Pannumber))
            {
                return BadRequest("PAN Number already exists.");
            }

            await _supplierService.AddAsync(dto);

            return Ok("Supplier created successfully.");
        }


        //[HttpPost]
        //public IActionResult Create([FromBody] CreateSupplierDto dto)
        //{
        //    return Ok(dto);
        //}

        #endregion

        #region Update Supplier

        [HttpPut]
        //public async Task<IActionResult> Update(UpdateSupplierDto dto)
        public async Task<IActionResult> Update([FromBody] UpdateSupplierDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingSupplier = await _supplierService.GetByIdAsync(dto.SupplierId);

            if (existingSupplier == null)
                return NotFound($"Supplier with Id {dto.SupplierId} not found.");

            await _supplierService.UpdateAsync(dto);

            return Ok("Supplier updated successfully.");
        }

        #endregion

        #region Delete Supplier

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);

            if (supplier == null)
                return NotFound($"Supplier with Id {id} not found.");

            await _supplierService.DeleteAsync(id);

            return Ok("Supplier deleted successfully.");
        }

        #endregion



        #region Delete Multiple Suppliers

        [HttpPost("delete-multiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] DeleteMultipleSuppliersDto dto)
        {
            if (dto == null || dto.Ids == null || !dto.Ids.Any())
                return BadRequest("No suppliers selected.");

            await _supplierService.DeleteMultipleAsync(dto);

            return Ok("Selected suppliers deleted successfully.");
        }

        #endregion

        #region Search Supplier

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Search keyword is required.");

            var suppliers = await _supplierService.SearchAsync(keyword);

            return Ok(suppliers);
        }

        #endregion

        #region Get Approved Suppliers

        [HttpGet("approved")]
        public async Task<IActionResult> GetApprovedSuppliers()
        {
            var suppliers = await _supplierService.GetApprovedSuppliersAsync();

            return Ok(suppliers);
        }

        #endregion

        #region Get Suppliers By Type

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            var suppliers = await _supplierService.GetByTypeAsync(type);

            return Ok(suppliers);
        }

        #endregion

        #region Get Active Suppliers

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveSuppliers()
        {
            var suppliers = await _supplierService.GetActiveSuppliersAsync();

            return Ok(suppliers);
        }

        #endregion

        #region Get Inactive Suppliers

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactiveSuppliers()
        {
            var suppliers = await _supplierService.GetInactiveSuppliersAsync();

            return Ok(suppliers);
        }

        #endregion

        #region Get Suppliers By Date Range

        [HttpGet("daterange")]
        public async Task<IActionResult> GetByDateRange(
            [FromQuery] DateTime fromDate,
            [FromQuery] DateTime toDate)
        {
            var suppliers = await _supplierService.GetByDateRangeAsync(fromDate, toDate);

            return Ok(suppliers);
        }

        #endregion

        #region Check Supplier Code Exists

        [HttpGet("exists/code/{supplierCode}")]
        public async Task<IActionResult> SupplierCodeExists(string supplierCode)
        {
            var exists = await _supplierService.IsSupplierCodeExistsAsync(supplierCode);

            return Ok(exists);
        }

        #endregion

        #region Check GST Number Exists

        [HttpGet("exists/gst/{gstNumber}")]
        public async Task<IActionResult> GstNumberExists(string gstNumber)
        {
            var exists = await _supplierService.IsGstNumberExistsAsync(gstNumber);

            return Ok(exists);
        }

        #endregion

        #region Check PAN Number Exists

        [HttpGet("exists/pan/{panNumber}")]
        public async Task<IActionResult> PanNumberExists(string panNumber)
        {
            var exists = await _supplierService.IsPanNumberExistsAsync(panNumber);

            return Ok(exists);
        }

        #endregion
    }
}