using LCWeb.Services.VendorMaintenanceService;
using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LCWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorMaintenanceController : ControllerBase
    {
        private readonly IVendorMaintenanceService _vendorMaintenanceService;

        public VendorMaintenanceController(IVendorMaintenanceService VendorMaintenanceService)
        {
            _vendorMaintenanceService = VendorMaintenanceService;
        }

        [HttpPost("add-entry")]
        public async Task<ActionResult<int>> CreateVendor([FromBody] CreateVendorMaintenanceDTO request)
        {
            int result = await _vendorMaintenanceService.CreateVendor(request);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpPut("edit-entry")]
        public async Task<ActionResult<int>> UpdateVendor([FromBody] CreateVendorMaintenanceDTO request, [FromQuery] int Id)
        {
            int result = await _vendorMaintenanceService.UpdateVendor(request, Id);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpGet("single-vendor")]
        public async Task<ActionResult<GetVendorMaintenanceDTO>> GetSingleVendor([FromQuery] int Id)
        {
            var result = await _vendorMaintenanceService.GetSingleVendor(Id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("vendor-paginated")]
        public async Task<ActionResult<PaginatedTableResponse<GetVendorMaintenanceDTO>>> GetVendorMaintenance([FromQuery] GetPaginatedDTO request)
        {
            var result = await _vendorMaintenanceService.GetVendorMaintenance(request);
            return Ok(result);
        }
    }
}
