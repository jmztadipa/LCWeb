using LCWeb.Services.ReportService;
using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LCWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService ReportService)
        {
            _reportService = ReportService;
        }

        //MONITORING
        [HttpPost("add-monitoring-entry")]
        public async Task<ActionResult<int>> CreateMonitoringReport([FromBody] CreateMonitoringReportDTO request)
        {
            int result = await _reportService.CreateMonitoringReport(request);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpPut("edit-monitoring-entry")]
        public async Task<ActionResult<int>> UpdateMonitoringReport([FromBody] CreateMonitoringReportDTO request, [FromQuery] int Id)
        {
            int result = await _reportService.UpdateMonitoringReport(request, Id);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpGet("single-monitoring")]
        public async Task<ActionResult<GetMonitoringReportDTO>> GetSingleMonitoringReport([FromQuery] int Id)
        {
            var result = await _reportService.GetSingleMonitoringReport(Id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("monitoring-paginated")]
        public async Task<ActionResult<PaginatedTableResponse<GetMonitoringReportDTO>>> GetMonitoringReport([FromQuery] GetPaginatedDTO request)
        {
            var result = await _reportService.GetMonitoringReport(request);
            return Ok(result);
        }


        //AMENDMENT
        [HttpPost("add-ammendment-entry")]
        public async Task<ActionResult<int>> CreateAmendmentReport([FromBody] CreateAmendmentReportDTO request)
        {
            int result = await _reportService.CreateAmendmentReport(request);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpPut("edit-ammendment-entry")]
        public async Task<ActionResult<int>> UpdateAmendmentReport([FromBody] CreateAmendmentReportDTO request, [FromQuery] int Id)
        {
            int result = await _reportService.UpdateAmendmentReport(request, Id);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpGet("single-ammendment")]
        public async Task<ActionResult<GetAmendmentReportDTO>> GetSingleAmendmentReport([FromQuery] int Id)
        {
            var result = await _reportService.GetSingleAmendmentReport(Id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("ammendment-paginated")]
        public async Task<ActionResult<PaginatedTableResponse<GetAmendmentReportDTO>>> GetAmendmentReport([FromQuery] GetPaginatedDTO request)
        {
            var result = await _reportService.GetAmendmentReport(request);
            return Ok(result);
        }
    }
}
