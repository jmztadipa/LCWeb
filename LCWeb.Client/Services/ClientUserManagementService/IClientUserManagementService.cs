using LCWeb.Shared.DTOs.UserManagementDTO;
using LCWeb.Shared.Response;

namespace LCWeb.Client.Services.ClientUserManagementService
{
    public interface IClientUserManagementService
    {
        Task<PaginatedTableResponse<GetUsersDTO>> GetUsers(GetPaginatedDTO payload);
    }
}
