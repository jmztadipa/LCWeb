using LCWeb.Shared.DTOs.LetterOfCreditsDTO;
using LCWeb.Shared.Response;

namespace LCWeb.Client.Services.ClientLetterOfCreditService
{
    public interface IClientLetterOfCreditService
    {
        Task<int> CreateLC(CreateLetterOfCreditsDTO payload);
        Task<int> UpdateLC(CreateLetterOfCreditsDTO payload, int LCId);
        Task<GetLetterOfCreditsDTO?> GetSingleLC(int LCId);
        Task<PaginatedTableResponse<GetLetterOfCreditsDTO>> GetLetterOfCredits(GetPaginatedDTO payload);
        Task<List<GetDraftLCListDTO>> GetDraftLCList();

        Task<int> ReleaseLC(int LCId);
        Task<int> ReceiveLC(int LCId);
    }
}
