using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Security
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public int UserId { get; set; }
        public int? EmployeeId { get; set; }
        public int? InventoryId { get; set; }
        public List<string> Errors { get; set; }
        public IList<string> Roles { get; set; }

        public string RolesString => string.Join(", ", Roles);
    }
}
