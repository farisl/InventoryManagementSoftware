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
        public int Id { get; set; }
        public List<string> Errors { get; set; }
    }
}
