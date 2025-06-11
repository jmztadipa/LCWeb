using LCWeb.Services.UserManagementService;
using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.DTOs.UserManagementDTO;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LCWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService UserManagementService)
        {
            _userManagementService = UserManagementService;
        }

        [HttpGet("user-paginated")]
        public async Task<ActionResult<PaginatedTableResponse<GetUsersDTO>>> GetUsers([FromQuery] GetPaginatedDTO request)
        {
            var result = await _userManagementService.GetUsers(request);
            return Ok(result);
        }
    }
}
