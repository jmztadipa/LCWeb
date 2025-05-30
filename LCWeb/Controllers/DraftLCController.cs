using LCWeb.Services.DraftLCService;
using LCWeb.Shared.DTOs.DraftLCDTO;
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
        public async Task<ActionResult<int>> CreateDraftLC(CreateDraftLCSectionDTO request)
        {
            int result = await _draftLCService.CreateDraftLC(request);
            return result == 0 ? BadRequest(0) : Ok(result);
        }
    }
}
