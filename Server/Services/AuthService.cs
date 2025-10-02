﻿using Microsoft.AspNetCore.Components.Authorization;
using RaefTech.Shared.Entities;

namespace RaefTech.Server.Services;

public interface IAuthService
{
    Task<bool> IsAuthenticated();
    Task<Result<RaefTechUser>> GetUser();
}

public class AuthService : IAuthService
{
    private readonly AuthenticationStateProvider _authProvider;
    private readonly IDataService _dataService;

    public AuthService(
        AuthenticationStateProvider authProvider,
        IDataService dataService)
    {
        _authProvider = authProvider;
        _dataService = dataService;
    }

    public async Task<bool> IsAuthenticated()
    {
        var principal = await _authProvider.GetAuthenticationStateAsync();
        return principal?.User?.Identity?.IsAuthenticated ?? false;
    }

    public async Task<Result<RaefTechUser>> GetUser()
    {
        var principal = await _authProvider.GetAuthenticationStateAsync();

        if (principal?.User?.Identity?.IsAuthenticated == true)
        {
            return await _dataService.GetUserByName($"{principal.User.Identity.Name}");
        }

        return Result.Fail<RaefTechUser>("Not authenticated.");
    }
}
