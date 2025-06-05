using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.DTOs.LetterOfCreditsDTO;
using LCWeb.Shared.Response;

namespace LCWeb.Services.LetterOfCreditService
{
    public interface ILetterOfCreditService
    {
        Task<int> CreateLC(CreateLetterOfCreditsDTO request);
        Task<int> UpdateLC(CreateLetterOfCreditsDTO request, int LCId);
        Task<GetLetterOfCreditsDTO?> GetSingleLC(int LCId);
        Task<PaginatedTableResponse<GetLetterOfCreditsDTO>> GetLetterOfCredits(GetPaginatedDTO request);
        Task<List<GetDraftLCListDTO>> GetDraftLCList();

        Task<int> ReleaseLC(int LCId);

        Task<int> ReceiveLC(int LCId);
    }
}
