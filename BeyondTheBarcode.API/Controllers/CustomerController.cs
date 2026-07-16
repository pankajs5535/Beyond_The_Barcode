using BeyondTheBarcode.Application.DTOs.CustomerDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #region Get All Customers

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        #endregion

        #region Get Customer By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
                return NotFound($"Customer with Id {id} not found.");

            return Ok(customer);
        }

        #endregion

        #region Get Customer By Code

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var customer = await _customerService.GetByCodeAsync(code);

            if (customer == null)
                return NotFound($"Customer with code '{code}' not found.");

            return Ok(customer);
        }

        #endregion

        #region Get Customers By Type

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            var customers = await _customerService.GetByTypeAsync(type);

            if (!customers.Any())
                return NotFound("No Customers found.");

            return Ok(customers);
        }

        #endregion

        #region Search Customers

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var customers = await _customerService.SearchAsync(keyword);

            if (!customers.Any())
                return NotFound("No matching Customers found.");

            return Ok(customers);
        }

        #endregion

        #region Get Active Customers

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var customers = await _customerService.GetActiveAsync();

            if (!customers.Any())
                return NotFound("No active Customers found.");

            return Ok(customers);
        }

        #endregion

        #region Get Inactive Customers

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactive()
        {
            var customers = await _customerService.GetInactiveAsync();

            if (!customers.Any())
                return NotFound("No inactive Customers found.");

            return Ok(customers);
        }

        #endregion

        #region Get Customers By Distribution Zone

        [HttpGet("zone/{zone}")]
        public async Task<IActionResult> GetByZone(string zone)
        {
            var customers = await _customerService.GetByZoneAsync(zone);

            if (!customers.Any())
                return NotFound("No Customers found.");

            return Ok(customers);
        }

        #endregion



        #region Get Customers By Region

        [HttpGet("region/{region}")]
        public async Task<IActionResult> GetByRegion(string region)
        {
            var customers = await _customerService.GetByRegionAsync(region);

            if (!customers.Any())
                return NotFound("No Customers found.");

            return Ok(customers);
        }

        #endregion

        #region Get Customers By Sales Representative

        [HttpGet("sales-rep/{salesRepId:int}")]
        public async Task<IActionResult> GetBySalesRep(int salesRepId)
        {
            var customers = await _customerService.GetBySalesRepAsync(salesRepId);

            if (!customers.Any())
                return NotFound("No Customers found.");

            return Ok(customers);
        }

        #endregion

        #region Check Customer Code Exists

        [HttpGet("exists/{customerCode}")]
        public async Task<IActionResult> IsCustomerCodeExists(string customerCode)
        {
            var exists = await _customerService.IsCustomerCodeExistsAsync(customerCode);

            return Ok(exists);
        }

        #endregion

        #region Create Customer

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _customerService.IsCustomerCodeExistsAsync(dto.CustomerCode);

            if (exists)
                return BadRequest("Customer Code already exists.");

            await _customerService.CreateAsync(dto);

            return Ok("Customer created successfully.");
        }

        #endregion


        #region Update Customer

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCustomer = await _customerService.GetByIdAsync(dto.CustomerId);

            if (existingCustomer == null)
                return NotFound($"Customer with Id {dto.CustomerId} not found.");

            await _customerService.UpdateAsync(dto);

            return Ok("Customer updated successfully.");
        }

        #endregion

        #region Delete Customer

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCustomer = await _customerService.GetByIdAsync(id);

            if (existingCustomer == null)
                return NotFound($"Customer with Id {id} not found.");

            await _customerService.DeleteAsync(id);

            return Ok("Customer deleted successfully.");
        }

        #endregion
    }
}