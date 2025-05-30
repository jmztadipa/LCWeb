using LCWeb.Shared.DTOs.DraftLCDTO;

namespace LCWeb.Client.Services.ClientDraftLCService
{
    public interface IClientDraftLCService 
    {
        Task<int> CreateDraftLC(CreateDraftLCSectionDTO payload);
    }
}
