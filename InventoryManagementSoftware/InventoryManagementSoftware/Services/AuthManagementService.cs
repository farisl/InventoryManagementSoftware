using eProdaja.Filters;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class AuthManagementService : IAuthManagementService
    {
        public static int UserId;

        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMSContext _context;

        public AuthManagementService(UserManager<IdentityUser<int>> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, IMSContext context)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _context = context;
        }

        public async Task<AuthResult> Login(UserLoginRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);

            if (existingUser == null)
                throw new UserException("Incorrect username or password");

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, request.Password);

            if (!isCorrect)
                throw new UserException("Incorrect username or password");

            var jwtToken = GenerateJwtToken(existingUser);

            int? employeeId = _context.Employees.Where(x => x.UserId == existingUser.Id).FirstOrDefault()?.Id;
            int? inventoryId = _context.EmployeeInventories.Where(x => x.EmployeeId == employeeId && x.EndDate == null)
                .FirstOrDefault()?.InventoryId;

            UserId = existingUser.Id;
            var roles = await _userManager.GetRolesAsync(existingUser);

            return new AuthResult { Success = true, Token = jwtToken,
                UserId = existingUser.Id,
                EmployeeId = (int)(employeeId != null ? employeeId : 0),
                InventoryId = (int)(inventoryId != null ? inventoryId : 0),
                Roles = roles
            };
        }

        public async Task<AuthResult> Register(UserRegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser != null)
                throw new UserException("Email already in use");

            var newUser = new IdentityUser<int> { Email = request.Email, UserName = request.Username };
            var isCreated = await _userManager.CreateAsync(newUser, "test");

            if (!isCreated.Succeeded)
                throw new UserException("Unable to create the user");

            await _userManager.AddToRoleAsync(newUser, "User");

            var jwtToken = GenerateJwtToken(newUser);

            return new AuthResult { Success = true, Token = jwtToken, UserId = newUser.Id };
        }

        private string GenerateJwtToken(IdentityUser<int> user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
