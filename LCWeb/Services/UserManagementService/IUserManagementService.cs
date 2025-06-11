using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.DTOs.UserManagementDTO;
using LCWeb.Shared.Response;

namespace LCWeb.Services.UserManagementService
{
    public interface IUserManagementService
    {
        Task<PaginatedTableResponse<GetUsersDTO>> GetUsers(GetPaginatedDTO request);
    }
}
