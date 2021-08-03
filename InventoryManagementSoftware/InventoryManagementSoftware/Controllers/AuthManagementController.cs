using eProdaja.Filters;
using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Security;
using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthManagementController : ControllerBase
    {
        private readonly IAuthManagementService _service;

        public AuthManagementController(IAuthManagementService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<AuthResult> Register([FromQuery] UserRegistrationRequest request)
        {
            return await _service.Register(request);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<AuthResult> Login([FromQuery] UserLoginRequest request)
        {
            return await _service.Login(request);
        }

    }
}
