﻿namespace equilog_backend.DTOs.StableDTOs;

public class StableCreateDto
{
    public required string Name { get; set; }
    
    public required string Type { get; set; }
    
    public required string Address { get; set; }
    
    public required string County { get; set; }

    public required int PostCode { get; set; }

    public required int BoxCount { get; set; }
}