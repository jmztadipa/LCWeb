using System.Linq;
using LCWeb.Data;
using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Models.Maintenance;
using LCWeb.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace LCWeb.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly DataContext _context;

        public ReportService(DataContext context)
        {
            _context = context;
        }

        //MONITORING
        public async Task<int> CreateMonitoringReport(CreateMonitoringReportDTO request)
        {
            var entry = new MonitoringReport
            {
                LCNo = request.LCNo,
                PONo = request.PONo,
                OpeningBank1 = request.OpeningBank1,
                OpeningBank2 = request.OpeningBank2,
                OpenedFrom = request.OpenedFrom,
                OpenedTo = request.OpenedTo,
            };
            _context.MonitoringReports.Add(entry);
            return await _context.SaveChangesAsync() == 0 ? 0 : 1;

        }

        public async Task<int> UpdateMonitoringReport(CreateMonitoringReportDTO request, int Id)
        {
            var query = await _context.MonitoringReports
                .FirstOrDefaultAsync(q => q.Id == Id);

            if (query == null) return 0;

            query.LCNo = request.LCNo;
            query.PONo = request.PONo;
            query.OpeningBank1 = request.OpeningBank1;
            query.OpeningBank2 = request.OpeningBank2;
            query.OpenedFrom = request.OpenedFrom;
            query.OpenedTo = request.OpenedTo;

            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

        private GetMonitoringReportDTO ConvertMonitoringReportDTO(MonitoringReport request)
        {
            return new GetMonitoringReportDTO
            {
                Id = request.Id,
                LCNo = request.LCNo,
                PONo = request.PONo,
                OpeningBank1 = request.OpeningBank1,
                OpeningBank2 = request.OpeningBank2,
                OpenedFrom = request.OpenedFrom,
                OpenedTo = request.OpenedTo,
            };
        }

        public async Task<GetMonitoringReportDTO?> GetSingleMonitoringReport(int Id)
        {
            var query = await _context.MonitoringReports
                .FirstOrDefaultAsync(q => q.Id == Id);

            if (query == null) return null;

            return ConvertMonitoringReportDTO(query);
        }

        public async Task<PaginatedTableResponse<GetMonitoringReportDTO>> GetMonitoringReport(GetPaginatedDTO request)
        {
            IQueryable<MonitoringReport> query = _context.MonitoringReports
                .OrderByDescending(q => q.Id);

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(q => q.Id.ToString().Contains(request.SearchValue)
                || q.LCNo.Contains(request.SearchValue)
                || q.PONo.Contains(request.SearchValue)
                || q.OpeningBank1.Contains(request.SearchValue)
                || q.OpeningBank2.Contains(request.SearchValue));
            }

            int totalCount = await query.CountAsync();

            List<MonitoringReport> paginatedResult = await query
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            var result = paginatedResult.Select(vm => ConvertMonitoringReportDTO(vm)).ToList();

            return new PaginatedTableResponse<GetMonitoringReportDTO>
            {
                ResponseData = result,
                Count = result.Count,
            };
        }


        //AMENDMENT
        public async Task<int> CreateAmendmentReport(CreateAmendmentReportDTO request)
        {
            var entry = new AmendmentReport
            {
                LCNo = request.LCNo,
                OpeningBank1 = request.OpeningBank1,
                OpeningBank2 = request.OpeningBank2,
                ReceivedFrom = request.ReceivedFrom,
                ReceivedTo = request.ReceivedTo,
            };
            _context.AmendmentReports.Add(entry);
            return await _context.SaveChangesAsync() == 0 ? 0 : 1;

        }

        public async Task<int> UpdateAmendmentReport(CreateAmendmentReportDTO request, int Id)
        {
            var query = await _context.AmendmentReports
                .FirstOrDefaultAsync(q => q.Id == Id);

            if (query == null) return 0;

            query.LCNo = request.LCNo;
            query.OpeningBank1 = request.OpeningBank1;
            query.OpeningBank2 = request.OpeningBank2;
            query.ReceivedFrom = request.ReceivedFrom;
            query.ReceivedTo = request.ReceivedTo;

            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

        private GetAmendmentReportDTO ConvertAmendmentReportDTO(AmendmentReport request)
        {
            return new GetAmendmentReportDTO
            {
                Id = request.Id,
                LCNo = request.LCNo,
                OpeningBank1 = request.OpeningBank1,
                OpeningBank2 = request.OpeningBank2,
                ReceivedFrom = request.ReceivedFrom,
                ReceivedTo = request.ReceivedTo,
            };
        }

        public async Task<GetAmendmentReportDTO?> GetSingleAmendmentReport(int Id)
        {
            var query = await _context.AmendmentReports
                .FirstOrDefaultAsync(q => q.Id == Id);

            if (query == null) return null;

            return ConvertAmendmentReportDTO(query);
        }

        public async Task<PaginatedTableResponse<GetAmendmentReportDTO>> GetAmendmentReport(GetPaginatedDTO request)
        {
            IQueryable<AmendmentReport> query = _context.AmendmentReports
                .OrderByDescending(q => q.Id);

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(q => q.Id.ToString().Contains(request.SearchValue)
                || q.OpeningBank1.Contains(request.SearchValue)
                || q.OpeningBank2.Contains(request.SearchValue));
            }

            int totalCount = await query.CountAsync();

            List<AmendmentReport> paginatedResult = await query
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            var result = paginatedResult.Select(vm => ConvertAmendmentReportDTO(vm)).ToList();

            return new PaginatedTableResponse<GetAmendmentReportDTO>
            {
                ResponseData = result,
                Count = result.Count,
            };
        }

    }
}
