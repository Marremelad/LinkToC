﻿namespace equilog_backend.DTOs.AuthDTOs;

public class LoginDto
{
    public required string Email { get; init; }

    public required string Password { get; init; }
}