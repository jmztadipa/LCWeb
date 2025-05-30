using LCWeb.Shared.DTOs.DraftLCDTO;

namespace LCWeb.Services.DraftLCService
{
    public interface IDraftLCService
    {
        Task<int> CreateDraftLC(CreateDraftLCSectionDTO request);
    }
}
