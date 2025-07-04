﻿using equilog_backend.Common;
using equilog_backend.Interfaces;

namespace equilog_backend.Endpoints;

public class StableLocationEndpoints
{
    public static void RegisterEndpoints(WebApplication app)
    {

        // Get stable location.
        app.MapGet("/api/stable-location/{postcode}", GetStableLocation) // "/api/stable-locations/{postcode}"
            .RequireAuthorization()
            .WithName("GetStableLocation");
    }
    private static async Task<IResult> GetStableLocation(
        IStableLocationService stableLocationService,
        string postcode)
    {
        return Result.Generate(await stableLocationService.GetStableLocationAsync(postcode));
    }
}