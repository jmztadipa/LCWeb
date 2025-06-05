using LCWeb.Services.LetterOfCreditService;
using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.DTOs.LetterOfCreditsDTO;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LCWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LetterOfCreditController : ControllerBase
    {
        private readonly ILetterOfCreditService _letterOfCreditService;

        public LetterOfCreditController(ILetterOfCreditService LetterOfCreditService)
        {
            _letterOfCreditService = LetterOfCreditService;
        }

        [HttpPost("add-entry")]
        public async Task<ActionResult<int>> CreateLC([FromBody] CreateLetterOfCreditsDTO request)
        {
            int result = await _letterOfCreditService.CreateLC(request);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpPut("edit-entry")]
        public async Task<ActionResult<int>> UpdateLC([FromBody] CreateLetterOfCreditsDTO request, [FromQuery] int LCId)
        {
            int result = await _letterOfCreditService.UpdateLC(request, LCId);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpGet("single-lc")]
        public async Task<ActionResult<GetLetterOfCreditsDTO>> GetSingleLC([FromQuery] int LCId)
        {
            var result = await _letterOfCreditService.GetSingleLC(LCId);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("lc-paginated")]
        public async Task<ActionResult<PaginatedTableResponse<GetLetterOfCreditsDTO>>> GetLetterOfCredits([FromQuery] GetPaginatedDTO request)
        {
            var result = await _letterOfCreditService.GetLetterOfCredits(request);
            return Ok(result);
        }

        [HttpGet("draft-lc-list")]
        public async Task<ActionResult<List<GetDraftLCListDTO>>> GetDraftLCList()
        {
            var result = await _letterOfCreditService.GetDraftLCList();
            return Ok(result);
        }

        [HttpPut("release-entry")]
        public async Task<ActionResult<int>> ReleaseLC([FromQuery] int LCId)
        {
            int result = await _letterOfCreditService.ReleaseLC(LCId);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

        [HttpPut("receive-entry")]
        public async Task<ActionResult<int>> ReceiveLC([FromQuery] int LCId)
        {
            int result = await _letterOfCreditService.ReceiveLC(LCId);
            return result == 0 ? BadRequest(0) : Ok(result);
        }

    }
}
