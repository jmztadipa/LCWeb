using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Response;

namespace LCWeb.Services.VendorMaintenanceService
{
    public interface IVendorMaintenanceService
    {
        Task<int> CreateVendor(CreateVendorMaintenanceDTO request);
        Task<int> UpdateVendor(CreateVendorMaintenanceDTO request, int Id);
        Task<GetVendorMaintenanceDTO?> GetSingleVendor(int Id);
        Task<PaginatedTableResponse<GetVendorMaintenanceDTO>> GetVendorMaintenance(GetPaginatedDTO request);
    }
}
