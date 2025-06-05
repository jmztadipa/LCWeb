using System.Net.Http.Json;
using LCWeb.Client.Utilities;
using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LCWeb.Client.Services.ClientDraftLCService
{
    public class ClientDraftLCService : IClientDraftLCService
    {
        private readonly HttpClient _http;
        private readonly ModifiedSnackBar _modifiedSnackBar;
        private readonly SubmitModal _submitModal;
        private readonly NavigationManager _navigationManager;

        public ClientDraftLCService(HttpClient http, ModifiedSnackBar modifiedSnackBar, SubmitModal submitModal, NavigationManager navigationManager)
        {
            _http = http;
            _modifiedSnackBar = modifiedSnackBar;
            _submitModal = submitModal;
            _navigationManager = navigationManager;
        }

        public async Task<int> CreateDraftLC(CreateDraftLCSectionDTO payload)
        {
            HttpResponseMessage? response = await _http.PostAsJsonAsync("api/draftlc/add-entry", payload);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                if (result == 0) return 0;
                _navigationManager.NavigateTo("/draft-lc-releasing");
                await _submitModal.ShowSuccess(null);
                return result;
            }
            else
            {
                _modifiedSnackBar.ShowMessage("Failed to create ENTRY", Severity.Error);
                return 0;
            }
        }

        public async Task<int> UpdateDraftLC(CreateDraftLCSectionDTO payload, int LCId)
        {
            HttpResponseMessage? response = await _http.PutAsJsonAsync($"api/draftlc/edit-entry?LCId={LCId}", payload);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                if (result == 0) return 0;
                _navigationManager.NavigateTo("/draft-lc-releasing");
                await _submitModal.ShowSuccess("Entry has been updated");
                return result;
            }
            else
            {
                _modifiedSnackBar.ShowMessage("Failed to update ENTRY", Severity.Error);
                return 0;
            }
        }

        public async Task<PaginatedTableResponse<GetLCReleasingDTO>> GetDraftLCSections(GetPaginatedDTO payload)
        {
            PaginatedTableResponse<GetLCReleasingDTO>? response = await _http.GetFromJsonAsync<PaginatedTableResponse<GetLCReleasingDTO>>($"api/draftlc/lc-section-paginated?Take={payload.Take}&Skip={payload.Skip}&SearchValue={payload.SearchValue}&Status={payload.Status}");
            if (response == null) return new PaginatedTableResponse<GetLCReleasingDTO>();
            return response;
        }

        public async Task<GetLCReleasingDTO?> GetSingleLCDraftSection(int LCId)
        {
            GetLCReleasingDTO? response = await _http.GetFromJsonAsync<GetLCReleasingDTO>($"api/draftlc/single-lc-section?LCId={LCId}");
            if (response == null) return new GetLCReleasingDTO();
            return response;
        }

        //RELEASING
        public async Task<int> ReleaseDraftLC(int LCId)
        {
            HttpResponseMessage? response = await _http.PutAsync($"api/draftlc/release-draft-lc?LCId={LCId}", null);
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

        public async Task<int> ReopenDraftLC(int LCId)
        {
            HttpResponseMessage? response = await _http.PutAsync($"api/draftlc/reopen-draft-lc?LCId={LCId}", null);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                if (result == 0) return 0;
                _submitModal.ShowSuccess("Entry has been re-opened");
                return result;
            }
            else
            {
                _modifiedSnackBar.ShowMessage("Failed to reopen ENTRY", Severity.Error);
                return 0;
            }
        }

    }
}
