using LCWeb.Data;
using LCWeb.Shared.DTOs.UserManagementDTO;
using LCWeb.Shared.Models.Auth;
using LCWeb.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace LCWeb.Services.UserManagementService
{
    public class UserManagementService : IUserManagementService
    {
        private readonly DataContext _context;

        public UserManagementService(DataContext context)
        {
            _context = context;
        }

        private GetUsersDTO ConvertUserDTO(UserDetails request)
        {
            return new GetUsersDTO
            {
                Id = request.Id,
                Email = request.User.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.User.Username == string.Empty ? "-" : request.User.Username,
                IsActive = request.User.IsActive,
                Role = request.User.Role,   
            };
        }

        public async Task<PaginatedTableResponse<GetUsersDTO>> GetUsers(GetPaginatedDTO request)
        {
            IQueryable<UserDetails> query = _context.UserDetails
                .Include(q => q.User)
                .OrderByDescending(q => q.Id);

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(q => q.FirstName.Contains(request.SearchValue) || q.LastName.Contains(request.SearchValue));
            }

            int totalCount = await query.CountAsync();

            var paginatedResult = await query
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            var result = paginatedResult.Select(res => ConvertUserDTO(res)).ToList();

            return new PaginatedTableResponse<GetUsersDTO>
            {
                ResponseData = result,
                Count = totalCount
            };
        }

    }
}
