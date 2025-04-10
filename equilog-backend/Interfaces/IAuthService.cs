﻿using equilog_backend.Common;
using equilog_backend.DTOs.AuthDTOs;
using equilog_backend.Models;

namespace equilog_backend.Interfaces;

public interface IAuthService
{
    public Task<ApiResponse<AuthResponseDto?>> Register(RegisterDto registerDto);
    public Task<ApiResponse<AuthResponseDto>?> Login(LoginDto loginDto);
    public string GenerateToke(User user);
}