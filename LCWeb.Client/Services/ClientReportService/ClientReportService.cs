using System.Net.Http.Json;
using LCWeb.Client.Utilities;
using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Response;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LCWeb.Client.Services.ClientReportService
{
    public class ClientReportService : IClientReportService
    {
        private readonly HttpClient _http;
        private readonly ModifiedSnackBar _modifiedSnackBar;
        private readonly SubmitModal _submitModal;
        private readonly NavigationManager _navigationManager;

        public ClientReportService(HttpClient http, ModifiedSnackBar modifiedSnackBar, SubmitModal submitModal, NavigationManager navigationManager)
        {
            _http = http;
            _modifiedSnackBar = modifiedSnackBar;
            _submitModal = submitModal;
            _navigationManager = navigationManager;
        }

        //MONITORING
        public async Task<int> CreateMonitoringReport(CreateMonitoringReportDTO payload)
        {
            HttpResponseMessage? response = await _http.PostAsJsonAsync("api/report/add-monitoring-entry", payload);
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

        public async Task<int> UpdateMonitoringReport(CreateMonitoringReportDTO payload, int Id)
        {
            HttpResponseMessage? response = await _http.PutAsJsonAsync($"api/report/edit-monitoring-entry?Id={Id}", payload);
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

        public async Task<GetMonitoringReportDTO?> GetSingleMonitoringReport(int Id)
        {
            GetMonitoringReportDTO? response = await _http.GetFromJsonAsync<GetMonitoringReportDTO>($"api/report/single-monitoring?Id={Id}");
            if (response == null) return new GetMonitoringReportDTO();
            return response;
        }

        public async Task<PaginatedTableResponse<GetMonitoringReportDTO>> GetMonitoringReport(GetPaginatedDTO payload)
        {
            PaginatedTableResponse<GetMonitoringReportDTO>? response = await _http.GetFromJsonAsync<PaginatedTableResponse<GetMonitoringReportDTO>>($"api/report/monitoring-paginated?Take={payload.Take}&Skip={payload.Skip}&SearchValue={payload.SearchValue}");
            if (response == null) return new PaginatedTableResponse<GetMonitoringReportDTO>();
            return response;
        }

        //AMENDMENT
        public async Task<int> CreateAmendmentReport(CreateAmendmentReportDTO payload)
        {
            HttpResponseMessage? response = await _http.PostAsJsonAsync("api/report/add-ammendment-entry", payload);
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

        public async Task<int> UpdateAmendmentReport(CreateAmendmentReportDTO payload, int Id)
        {
            HttpResponseMessage? response = await _http.PutAsJsonAsync($"api/report/edit-ammendment-entry?Id={Id}", payload);
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

        public async Task<GetAmendmentReportDTO?> GetSingleAmendmentReport(int Id)
        {
            GetAmendmentReportDTO? response = await _http.GetFromJsonAsync<GetAmendmentReportDTO>($"api/report/single-ammendment?Id={Id}");
            if (response == null) return new GetAmendmentReportDTO();
            return response;
        }

        public async Task<PaginatedTableResponse<GetAmendmentReportDTO>> GetAmendmentReport(GetPaginatedDTO payload)
        {
            PaginatedTableResponse<GetAmendmentReportDTO>? response = await _http.GetFromJsonAsync<PaginatedTableResponse<GetAmendmentReportDTO>>($"api/report/ammendment-paginated?Take={payload.Take}&Skip={payload.Skip}&SearchValue={payload.SearchValue}");
            if (response == null) return new PaginatedTableResponse<GetAmendmentReportDTO>();
            return response;
        }

    }
}
