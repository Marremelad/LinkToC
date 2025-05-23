﻿using System.ComponentModel.DataAnnotations;

namespace equilog_backend.DTOs.PasswordDTOs;

public class PasswordResetDto
{
    [Required]
    public required string Token { get; init; }
    
    [Required]
    [StringLength(100, MinimumLength = 8)]
    public required string NewPassword { get; init; }
    
    [Required]
    [StringLength(100, MinimumLength = 8)]
    public required string ConfirmPassword { get; init; }
}