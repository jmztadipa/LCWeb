using System.Net.Http.Json;
using LCWeb.Client.Utilities;
using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LCWeb.Client.Services.ClientVendorMaintenanceService
{
    public class ClientVendorMaintenanceService : IClientVendorMaintenanceService
    {
        private readonly HttpClient _http;
        private readonly ModifiedSnackBar _modifiedSnackBar;
        private readonly SubmitModal _submitModal;
        private readonly NavigationManager _navigationManager;

        public ClientVendorMaintenanceService(HttpClient http, ModifiedSnackBar modifiedSnackBar, SubmitModal submitModal, NavigationManager navigationManager)
        {
            _http = http;
            _modifiedSnackBar = modifiedSnackBar;
            _submitModal = submitModal;
            _navigationManager = navigationManager;
        }

        public async Task<int> CreateVendor(CreateVendorMaintenanceDTO payload)
        {
            HttpResponseMessage? response = await _http.PostAsJsonAsync("api/vendormaintenance/add-entry", payload);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                if (result == 0) return 0;
                _submitModal.ShowSuccess(null);
                return result;
            }
            else
            {
                _modifiedSnackBar.ShowMessage("Failed to create ENTRY", Severity.Error);
                return 0;
            }
        }

        public async Task<int> UpdateVendor(CreateVendorMaintenanceDTO payload, int Id)
        {
            HttpResponseMessage? response = await _http.PutAsJsonAsync($"api/vendormaintenance/edit-entry?Id={Id}", payload);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                if (result == 0) return 0;
                _submitModal.ShowSuccess("Entry has been updated");
                return result;
            }
            else
            {
                _modifiedSnackBar.ShowMessage("Failed to update ENTRY", Severity.Error);
                return 0;
            }
        }

        public async Task<GetVendorMaintenanceDTO?> GetSingleVendor(int Id)
        {
            GetVendorMaintenanceDTO? response = await _http.GetFromJsonAsync<GetVendorMaintenanceDTO>($"api/vendormaintenance/single-vendor?Id={Id}");
            if (response == null) return new GetVendorMaintenanceDTO();
            return response;
        }

        public async Task<PaginatedTableResponse<GetVendorMaintenanceDTO>> GetVendorMaintenance(GetPaginatedDTO payload)
        {
            PaginatedTableResponse<GetVendorMaintenanceDTO>? response = await _http.GetFromJsonAsync<PaginatedTableResponse<GetVendorMaintenanceDTO>>($"api/vendormaintenance/vendor-paginated?Take={payload.Take}&Skip={payload.Skip}&SearchValue={payload.SearchValue}");
            if (response == null) return new PaginatedTableResponse<GetVendorMaintenanceDTO>();
            return response;
        }
    }
}
