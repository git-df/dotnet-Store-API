using Application.Functions.Auth.Commands.SignUp;
using Application.Responses;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignIn
{
    public class SignInHandler : IRequestHandler<SignInCommand, BaseResponse<string?>>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public SignInHandler(
            IConfiguration configuration,
            UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<BaseResponse<string?>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignInValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse<string?>(false, null, validationResult);

            var user = await _userManager.FindByNameAsync(request?.Email?.ToLower() ?? "");

            if (user != null && await _userManager.CheckPasswordAsync(user, request?.Password ?? ""))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user?.UserName ?? ""),
                    new Claim("FirstName", user?.FirstName ?? ""),
                    new Claim("LastName", user?.LastName ?? ""),
                    new Claim(ClaimTypes.NameIdentifier, user?.Id.ToString() ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return new BaseResponse<string?>(
                    new JwtSecurityTokenHandler().WriteToken(token).ToString(), true);
            }

            return new BaseResponse<string?>(false, "Login or password incorrect");
        }

        private JwtSecurityToken GetToken(List<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
