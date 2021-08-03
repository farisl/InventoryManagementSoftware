using eProdaja.Filters;
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
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthManagementService(UserManager<IdentityUser<int>> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public async Task<AuthResult> Login(UserLoginRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            if (existingUser == null)
                throw new UserException("Incorrect username or password");

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, request.Password);

            if (!isCorrect)
                throw new UserException("Incorrect username or password");

            var jwtToken = GenerateJwtToken(existingUser);

            return new AuthResult { Success = true, Token = jwtToken };
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

            return new AuthResult { Success = true, Token = jwtToken, Id = newUser.Id };
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
