using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCWeb.Shared.Enums;

namespace LCWeb.Shared.DTOs.UserManagementDTO
{
    public class GetUsersDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserRoles Role { get; set; }
        public bool IsActive { get; set; }
    }
}
