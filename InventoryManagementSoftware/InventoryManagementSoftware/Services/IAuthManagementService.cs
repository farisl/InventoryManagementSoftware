using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public interface IAuthManagementService
    {
        Task<AuthResult> Register(UserRegistrationRequest request);
        Task<AuthResult> Login(UserLoginRequest request);
    }
}
