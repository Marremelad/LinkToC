﻿using equilog_backend.Common;
using equilog_backend.DTOs.AuthDTOs;
using equilog_backend.Interfaces;

namespace equilog_backend.Endpoints;

public class AuthEndpoints
{
    public static void RegisterEndpoints(WebApplication app)
    {
        // Register.
        app.MapPost("/api/auth/register", Register)
            .AddEndpointFilter<ValidationFilter<RegisterDto>>()
            .WithName("Register");

        // Login.
        app.MapPost("/api/auth/login", Login)
            .AddEndpointFilter<ValidationFilter<LoginDto>>()
            .WithName("Login");

        // Validate password.
        app.MapPost("/api/auth/validate-password", ValidatePassword)
            .WithName("ValidatePassword");
        
        // Refresh token.
        app.MapPost("/api/auth/refresh-token", RefreshToken)
            .WithName("RefreshToken");
        
        // Logout.
        app.MapPost("/api/auth/revoke-token", LogOut)
            .WithName("RevokeToken");
    }

    private static async Task<IResult> Register(
        IAuthService authService,
        RegisterDto registerDto)
    {
        return Result.Generate(await authService.RegisterAsync(registerDto));
    }

    private static async Task<IResult> Login(
        IAuthService authService,
        LoginDto loginDto)
    {
        return Result.Generate(await authService.LoginAsync(loginDto));
    }

    private static async Task<IResult> ValidatePassword(
        IAuthService authService,
        ValidatePasswordDto validatePasswordDto)
    {
        return Result.Generate(await authService.ValidatePasswordAsync(validatePasswordDto));
    }
    
    private static async Task<IResult> RefreshToken(
        IAuthService authService,
        RefreshTokenDto refreshTokenDto)
    {
        return Result.Generate(await authService.RefreshTokenAsync(refreshTokenDto.RefreshToken));
    }
    
    private static async Task<IResult> LogOut(
        IAuthService authService,
        RefreshTokenDto refreshTokenDto)
    {
        return Result.Generate(await authService.RevokeRefreshTokenAsync(refreshTokenDto.RefreshToken));
    }
}