using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.Response;

namespace LCWeb.Client.Services.ClientDraftLCService
{
    public interface IClientDraftLCService 
    {
        Task<int> CreateDraftLC(CreateDraftLCSectionDTO payload);
        Task<int> UpdateDraftLC(CreateDraftLCSectionDTO payload, int LCId);
        Task<GetLCReleasingDTO?> GetSingleLCDraftSection(int LCId);
        Task<PaginatedTableResponse<GetLCReleasingDTO>> GetDraftLCSections(GetPaginatedDTO payload);

        //RELEASED
        Task<int> ReleaseDraftLC(int LCId);
        Task<int> ReopenDraftLC(int LCId);
    }
}
