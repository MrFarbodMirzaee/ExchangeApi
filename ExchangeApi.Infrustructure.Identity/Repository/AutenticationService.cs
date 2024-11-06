﻿using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using ExchangeApi.Infrustructure.Identity.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExchangeApi.Application.Enums;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Application.UseCases.Autentication;

namespace ExchangeApi.Infrustructure.Identity.Repository;
public class AutenticationService : IAutenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSettings _jwtSettings;

    public AutenticationService(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptionsMonitor<JwtSettings> jwtSettings,
        SignInManager<ApplicationUser> signInManager)
    {
        _jwtSettings = jwtSettings.CurrentValue;
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }
    public async Task<Response<AuthenticationResponseDto>> Login(LogInCommand dto, CancellationToken ct)
    {
        var user = await _userManager.FindByNameAsync(dto.UserName);
        if (user == null)
        {
            return new Response<AuthenticationResponseDto>("User not found");
        }
        var result = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, false, lockoutOnFailure: false);
        if (!result.Succeeded)
        {
            return new Response<AuthenticationResponseDto>("User name or password is wrong");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
        AuthenticationResponseDto response = new AuthenticationResponseDto();
        response.Id = user.Id;
        response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        response.Email = user.Email;
        response.UserName = user.UserName;
        var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
        response.Roles = rolesList.ToList();
        response.IsVerified = user.EmailConfirmed;
        return new Response<AuthenticationResponseDto>(response);
    }

    public async Task<Response<AuthenticationResponseDto>> Register(RegisterCommand dto, CancellationToken ct)
    {
        var userWithSameUserName = await _userManager.FindByNameAsync(dto.UserName);
        if (userWithSameUserName != null)
        {
            return new Response<AuthenticationResponseDto>("Username is already taken.");
        }
        var user = new ApplicationUser
        {
            Email = dto.UserName,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UserName = dto.UserName
        };
        var userWithSameName = await _userManager.FindByNameAsync(dto.UserName);
        if (userWithSameName == null)
        {
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                // Create AuthenticationResponseDto with user details
                var responseDto = new AuthenticationResponseDto
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = new List<string> { Roles.User.ToString() },
                    IsVerified = user.EmailConfirmed
                };

                return new Response<AuthenticationResponseDto>(responseDto);
            }
            else
            {
                return new Response<AuthenticationResponseDto>("User didn't create");
            }
        }
        else
        {
            return new Response<AuthenticationResponseDto>("User already register");
        }
    }
    private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim("roles", roles[i]));
        }

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
}
