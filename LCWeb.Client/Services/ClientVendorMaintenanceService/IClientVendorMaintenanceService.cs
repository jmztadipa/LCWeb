using LCWeb.Shared.DTOs.MaintenanceDTO;
using LCWeb.Shared.Response;

namespace LCWeb.Client.Services.ClientVendorMaintenanceService
{
    public interface IClientVendorMaintenanceService
    {
        Task<int> CreateVendor(CreateVendorMaintenanceDTO payload);
        Task<int> UpdateVendor(CreateVendorMaintenanceDTO payload, int Id);
        Task<GetVendorMaintenanceDTO?> GetSingleVendor(int Id);
        Task<PaginatedTableResponse<GetVendorMaintenanceDTO>> GetVendorMaintenance(GetPaginatedDTO payload);
    }
}
