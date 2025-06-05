using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.Models.DraftLC;
using LCWeb.Shared.Response;

namespace LCWeb.Services.DraftLCService
{
    public interface IDraftLCService
    {
        Task<int> CreateDraftLC(CreateDraftLCSectionDTO request);
        Task<int> UpdateDraftLC(CreateDraftLCSectionDTO request, int LCId);
        Task<GetLCReleasingDTO?> GetSingleLCDraftSection(int LCId);
        Task<PaginatedTableResponse<GetLCReleasingDTO>> GetDraftLCSections(GetPaginatedDTO request);

        //RELEASED
        Task<int> ReleaseDraftLC(int LCId);
        Task<int> ReopenDraftLC(int LCId);
    }
}
