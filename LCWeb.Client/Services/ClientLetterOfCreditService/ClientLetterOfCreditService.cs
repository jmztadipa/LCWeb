using LCWeb.Client.Utilities;
using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.DTOs.LetterOfCreditsDTO;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

namespace LCWeb.Client.Services.ClientLetterOfCreditService
{
    public class ClientLetterOfCreditService : IClientLetterOfCreditService
    {
        private readonly HttpClient _http;
        private readonly ModifiedSnackBar _modifiedSnackBar;
        private readonly SubmitModal _submitModal;
        private readonly NavigationManager _navigationManager;

        public ClientLetterOfCreditService(HttpClient http, ModifiedSnackBar modifiedSnackBar, SubmitModal submitModal, NavigationManager navigationManager)
        {
            _http = http;
            _modifiedSnackBar = modifiedSnackBar;
            _submitModal = submitModal;
            _navigationManager = navigationManager;
        }

        public async Task<int> CreateLC(CreateLetterOfCreditsDTO payload)
        {
            HttpResponseMessage? response = await _http.PostAsJsonAsync("api/letterofcredit/add-entry", payload);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                if (result == 0) return 0;
                _navigationManager.NavigateTo("/lc-issuance");
                await _submitModal.ShowSuccess(null);
                return result;
            }
            else
            {
                _modifiedSnackBar.ShowMessage("Failed to create ENTRY", Severity.Error);
                return 0;
            }
        }

        public async Task<int> UpdateLC(CreateLetterOfCreditsDTO payload, int LCId)
        {
            HttpResponseMessage? response = await _http.PutAsJsonAsync($"api/letterofcredit/edit-entry?LCId={LCId}", payload);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                if (result == 0) return 0;
                _navigationManager.NavigateTo("/lc-issuance");
                await _submitModal.ShowSuccess("Entry has been updated");
                return result;
            }
            else
            {
                _modifiedSnackBar.ShowMessage("Failed to update ENTRY", Severity.Error);
                return 0;
            }
        }

        public async Task<PaginatedTableResponse<GetLetterOfCreditsDTO>> GetLetterOfCredits(GetPaginatedDTO payload)
        {
            PaginatedTableResponse<GetLetterOfCreditsDTO>? response = await _http.GetFromJsonAsync<PaginatedTableResponse<GetLetterOfCreditsDTO>>($"api/letterofcredit/lc-paginated?Take={payload.Take}&Skip={payload.Skip}&SearchValue={payload.SearchValue}&Status={payload.Status}");
            if (response == null) return new PaginatedTableResponse<GetLetterOfCreditsDTO>();
            return response;
        }

        public async Task<GetLetterOfCreditsDTO?> GetSingleLC(int LCId)
        {
            GetLetterOfCreditsDTO? response = await _http.GetFromJsonAsync<GetLetterOfCreditsDTO>($"api/letterofcredit/single-lc?LCId={LCId}");
            if (response == null) return new GetLetterOfCreditsDTO();
            return response;
        }

        public async Task<List<GetDraftLCListDTO>> GetDraftLCList()
        {
            List<GetDraftLCListDTO>? response = await _http.GetFromJsonAsync<List<GetDraftLCListDTO>>($"api/letterofcredit/draft-lc-list");
            if (response == null) return new List<GetDraftLCListDTO>();
            return response;
        }


        public async Task<int> ReleaseLC(int LCId)
        {
            HttpResponseMessage? response = await _http.PutAsync($"api/letterofcredit/release-entry?LCId={LCId}", null);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                if (result == 0) return 0;
                _submitModal.ShowSuccess("Entry has been released");
                return result;
            }
            else
            {
                _modifiedSnackBar.ShowMessage("Failed to release ENTRY", Severity.Error);
                return 0;
            }
        }

        public async Task<int> ReceiveLC(int LCId)
        {
            HttpResponseMessage? response = await _http.PutAsync($"api/letterofcredit/receive-entry?LCId={LCId}", null);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                if (result == 0) return 0;
                _submitModal.ShowSuccess("Entry has been received");
                return result;
            }
            else
            {
                _modifiedSnackBar.ShowMessage("Failed to release ENTRY", Severity.Error);
                return 0;
            }
        }
    }
}
