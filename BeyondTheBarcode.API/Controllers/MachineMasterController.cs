using BeyondTheBarcode.Application.DTOs.MachineMasterDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineMasterController : ControllerBase
    {
        private readonly IMachineMasterService _machineMasterService;

        public MachineMasterController(IMachineMasterService machineMasterService)
        {
            _machineMasterService = machineMasterService;
        }

        #region Get All Machines

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var machines = await _machineMasterService.GetAllAsync();
            return Ok(machines);
        }

        #endregion

        #region Get Machine By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var machine = await _machineMasterService.GetByIdAsync(id);

            if (machine == null)
                return NotFound($"Machine with Id {id} not found.");

            return Ok(machine);
        }

        #endregion

        #region Get Machine By Code

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var machine = await _machineMasterService.GetByCodeAsync(code);

            if (machine == null)
                return NotFound($"Machine with code '{code}' not found.");

            return Ok(machine);
        }

        #endregion

        #region Get Machines By Type

        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            var machines = await _machineMasterService.GetByTypeAsync(type);

            if (!machines.Any())
                return NotFound("No Machines found.");

            return Ok(machines);
        }

        #endregion

        #region Search Machines

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var machines = await _machineMasterService.SearchAsync(keyword);

            if (!machines.Any())
                return NotFound("No matching Machines found.");

            return Ok(machines);
        }

        #endregion

        #region Get Active Machines

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var machines = await _machineMasterService.GetActiveAsync();

            if (!machines.Any())
                return NotFound("No active Machines found.");

            return Ok(machines);
        }

        #endregion

        #region Get Inactive Machines

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactive()
        {
            var machines = await _machineMasterService.GetInactiveAsync();

            if (!machines.Any())
                return NotFound("No inactive Machines found.");

            return Ok(machines);
        }

        #endregion

        #region Get Machines By Status

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var machines = await _machineMasterService.GetByStatusAsync(status);

            if (!machines.Any())
                return NotFound("No Machines found.");

            return Ok(machines);
        }

        #endregion


        #region Get Maintenance Due Machines

        [HttpGet("maintenance-due")]
        public async Task<IActionResult> GetMaintenanceDue()
        {
            var machines = await _machineMasterService.GetMaintenanceDueAsync();

            if (!machines.Any())
                return NotFound("No machines due for maintenance found.");

            return Ok(machines);
        }

        #endregion

        #region Get Machines By Plant

        [HttpGet("plant/{plant}")]
        public async Task<IActionResult> GetByPlant(string plant)
        {
            var machines = await _machineMasterService.GetByPlantAsync(plant);

            if (!machines.Any())
                return NotFound("No machines found.");

            return Ok(machines);
        }

        #endregion

        #region Check Machine Code Exists

        [HttpGet("exists/{machineCode}")]
        public async Task<IActionResult> IsMachineCodeExists(string machineCode)
        {
            var exists = await _machineMasterService.IsMachineCodeExistsAsync(machineCode);

            return Ok(exists);
        }

        #endregion

        #region Create Machine

        [HttpPost]
        public async Task<IActionResult> Create(CreateMachineMasterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _machineMasterService.IsMachineCodeExistsAsync(dto.MachineCode);

            if (exists)
                return BadRequest("Machine Code already exists.");

            await _machineMasterService.CreateAsync(dto);

            return Ok("Machine created successfully.");
        }

        #endregion

        #region Update Machine

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMachineMasterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingMachine = await _machineMasterService.GetByIdAsync(dto.MachineId);

            if (existingMachine == null)
                return NotFound($"Machine with Id {dto.MachineId} not found.");

            await _machineMasterService.UpdateAsync(dto);

            return Ok("Machine updated successfully.");
        }

        #endregion

        #region Delete Machine

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingMachine = await _machineMasterService.GetByIdAsync(id);

            if (existingMachine == null)
                return NotFound($"Machine with Id {id} not found.");

            await _machineMasterService.DeleteAsync(id);

            return Ok("Machine deleted successfully.");
        }

        #endregion
    }
}