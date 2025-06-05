using LCWeb.Data;
using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Models.DraftLC;
using LCWeb.Shared.Models.Maintenance;
using LCWeb.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace LCWeb.Services.VendorMaintenanceService
{
    public class VendorMaintenanceService : IVendorMaintenanceService
    {
        private readonly DataContext _context;

        public VendorMaintenanceService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateVendor(CreateVendorMaintenanceDTO request)
        {
            var entry = new VendorMaintenance
            {
                Code = request.Code,
                Description = request.Description,
                Address1 = request.Address1,
                Address2 = request.Address2,
                Address3 = request.Address3,
            };
            _context.VendorMaintenances.Add(entry);
            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
            
        }

        public async Task<int> UpdateVendor(CreateVendorMaintenanceDTO request, int Id)
        {
            var query = await _context.VendorMaintenances
                .FirstOrDefaultAsync(q => q.Id == Id);

            if (query == null) return 0;

            query.Code = request.Code;
            query.Description = request.Description;
            query.Address1 = request.Address1;
            query.Address2 = request.Address2;
            query.Address3 = request.Address3;

            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

        private GetVendorMaintenanceDTO ConvertVendorMaintenanceDTO(VendorMaintenance request)
        {
            return new GetVendorMaintenanceDTO
            {
                Id = request.Id,
                Code = request.Code,
                Description = request.Description,
                Address1 = request.Address1,
                Address2 = request.Address2,
                Address3 = request.Address3,
            };
        }

        public async Task<GetVendorMaintenanceDTO?> GetSingleVendor(int Id)
        {
            var query = await _context.VendorMaintenances
                .FirstOrDefaultAsync(q => q.Id == Id);

            if (query == null) return null;

            return ConvertVendorMaintenanceDTO(query);
        }

        public async Task<PaginatedTableResponse<GetVendorMaintenanceDTO>> GetVendorMaintenance(GetPaginatedDTO request)
        {
            IQueryable<VendorMaintenance> query = _context.VendorMaintenances
                .OrderByDescending(q => q.Id);

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(q => q.Code.Contains(request.SearchValue) 
                || q.Description.Contains(request.SearchValue)
                || q.Address1.Contains(request.SearchValue)
                || q.Address2.Contains(request.SearchValue)
                || q.Address3.Contains(request.SearchValue));
            }

            int totalCount = await query.CountAsync();

            List<VendorMaintenance> paginatedResult = await query
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            var result = paginatedResult.Select(vm => ConvertVendorMaintenanceDTO(vm)).ToList();

            return new PaginatedTableResponse<GetVendorMaintenanceDTO>
            {
                ResponseData = result,
                Count = result.Count,
            };
        }

        
    }
}
