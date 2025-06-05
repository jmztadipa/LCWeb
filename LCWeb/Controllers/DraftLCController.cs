using LCWeb.Services.DraftLCService;
using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.Models.DraftLC;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LCWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DraftLCController : ControllerBase
    {
        private readonly IDraftLCService _draftLCService;

        public DraftLCController(IDraftLCService DraftLCService)
        {
            _draftLCService = DraftLCService;
        }

        [HttpPost("add-entry")]
        public async Task<ActionResult<int>> CreateDraftLC([FromBody] CreateDraftLCSectionDTO request)
        {
            int result = await _draftLCService.CreateDraftLC(request);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpPut("edit-entry")]
        public async Task<ActionResult<int>> UpdateDraftLC([FromBody] CreateDraftLCSectionDTO request, [FromQuery] int LCId)
        {
            int result = await _draftLCService.UpdateDraftLC(request, LCId);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpGet("single-lc-section")]
        public async Task<ActionResult<GetLCReleasingDTO>> GetSingleLCDraftSection([FromQuery] int LCId)
        {
            var result = await _draftLCService.GetSingleLCDraftSection(LCId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("lc-section-paginated")]
        public async Task<ActionResult<PaginatedTableResponse<GetLCReleasingDTO>>> GetDraftLCSections([FromQuery] GetPaginatedDTO request)
        {
            var result = await _draftLCService.GetDraftLCSections(request);
            return Ok(result);
        }

        //RELEASED

        [HttpPut("release-draft-lc")]
        public async Task<ActionResult<int>> ReleaseDraftLC([FromQuery] int LCId)
        {
            int result = await _draftLCService.ReleaseDraftLC(LCId);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpPut("reopen-draft-lc")]
        public async Task<ActionResult<int>> ReopenDraftLC([FromQuery] int LCId)
        {
            int result = await _draftLCService.ReopenDraftLC(LCId);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

    }
}
