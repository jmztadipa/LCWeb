using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Response;

namespace LCWeb.Services.ReportService
{
    public interface IReportService
    {
        Task<int> CreateMonitoringReport(CreateMonitoringReportDTO request);
        Task<int> UpdateMonitoringReport(CreateMonitoringReportDTO request, int Id);
        Task<GetMonitoringReportDTO?> GetSingleMonitoringReport(int Id);
        Task<PaginatedTableResponse<GetMonitoringReportDTO>> GetMonitoringReport(GetPaginatedDTO request);

        Task<int> CreateAmendmentReport(CreateAmendmentReportDTO request);
        Task<int> UpdateAmendmentReport(CreateAmendmentReportDTO request, int Id);
        Task<GetAmendmentReportDTO?> GetSingleAmendmentReport(int Id);
        Task<PaginatedTableResponse<GetAmendmentReportDTO>> GetAmendmentReport(GetPaginatedDTO request);
    }
}
