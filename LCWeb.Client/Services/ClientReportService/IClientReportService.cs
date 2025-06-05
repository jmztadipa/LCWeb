using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Response;

namespace LCWeb.Client.Services.ClientReportService
{
    public interface IClientReportService
    {
        Task<int> CreateMonitoringReport(CreateMonitoringReportDTO payload);
        Task<int> UpdateMonitoringReport(CreateMonitoringReportDTO payload, int Id);
        Task<GetMonitoringReportDTO?> GetSingleMonitoringReport(int Id);
        Task<PaginatedTableResponse<GetMonitoringReportDTO>> GetMonitoringReport(GetPaginatedDTO payload);

        Task<int> CreateAmendmentReport(CreateAmendmentReportDTO payload);
        Task<int> UpdateAmendmentReport(CreateAmendmentReportDTO payload, int Id);
        Task<GetAmendmentReportDTO?> GetSingleAmendmentReport(int Id);
        Task<PaginatedTableResponse<GetAmendmentReportDTO>> GetAmendmentReport(GetPaginatedDTO payload);
    }
}
