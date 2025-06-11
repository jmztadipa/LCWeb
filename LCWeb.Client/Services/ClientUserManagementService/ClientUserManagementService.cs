using System.Net.Http.Json;
using LCWeb.Client.Utilities;
using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.DTOs.UserManagementDTO;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Components;

namespace LCWeb.Client.Services.ClientUserManagementService
{
    public class ClientUserManagementService : IClientUserManagementService
    {
        private readonly HttpClient _http;

        public ClientUserManagementService(HttpClient http)
        {
            _http = http;
        }

        public async Task<PaginatedTableResponse<GetUsersDTO>> GetUsers(GetPaginatedDTO payload)
        {
            PaginatedTableResponse<GetUsersDTO>? response = await _http.GetFromJsonAsync<PaginatedTableResponse<GetUsersDTO>>($"api/usermanagement/user-paginated?Take={payload.Take}&Skip={payload.Skip}&SearchValue={payload.SearchValue}");
            if (response == null) return new PaginatedTableResponse<GetUsersDTO>();
            return response;
        }
    }
}
