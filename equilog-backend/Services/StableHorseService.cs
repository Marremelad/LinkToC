﻿using System.Net;
using AutoMapper;
using equilog_backend.Common;
using equilog_backend.Data;
using equilog_backend.DTOs.StableHorseDTOs;
using equilog_backend.Interfaces;
using equilog_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace equilog_backend.Services;

// Service that manages the relationship between stables and horses.
// Handles horse assignments to stables and provides information about stable horse compositions.
public class StableHorseService(EquilogDbContext context, IMapper mapper) : IStableHorseService
{
    // Retrieves all horses assigned to a specific stable with basic information.
    public async Task<ApiResponse<List<StableHorseDto>?>> GetStableHorsesAsync(int stableId)
    {
        try
        {
            // Fetch stable-horse relationships for the specified stable.
            var stableHorseDtos = mapper.Map<List<StableHorseDto>>(
                await context.StableHorses
                .Where(sh => sh.StableIdFk == stableId)
                .ToListAsync());

            // Provides an appropriate message based on whether horses were found or not.
            var message = stableHorseDtos.Count == 0
                ? "Operation was successful but the stable has no horses."
                : "Horses fetched successfully";
            
            return ApiResponse<List<StableHorseDto>?>.Success(
                HttpStatusCode.OK,
                stableHorseDtos,
                message);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<StableHorseDto>>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    // Retrieves horses assigned to a stable along with their owner's information.
    public async Task<ApiResponse<List<StableHorseOwnersDto>?>> GetHorsesWithOwnersByStableIdAsync(int stableId)
    {
        try
        {
            // Fetch stable-horse relationships with detailed horse and owner information.
            var stableHorseOwnersDtos = mapper.Map<List<StableHorseOwnersDto>>(
                await context.StableHorses
                .Where(sh => sh.StableIdFk == stableId)
                .Include(sh => sh.Horse)
                .ThenInclude(h => h!.UserHorses)!
                .ThenInclude(uh => uh.User)
                .ToListAsync());

            // Provides an appropriate message based on whether horses were found or not.
            var message = stableHorseOwnersDtos.Count == 0
                ? "Operation was successful but the stable has no horses."
                : "Horses fetched successfully.";
            
            return ApiResponse<List<StableHorseOwnersDto>>.Success(
                HttpStatusCode.OK,
                stableHorseOwnersDtos,
                message);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<StableHorseOwnersDto>>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
    
    // Creates a relationship between a stable and a horse (assigns horse to stable).
    public async Task<ApiResponse<Unit>> CreateStableHorseConnectionAsync(int stableId, int horseId)
    {
        try
        {
            // Create the stable-horse relationship entity.
            var stableHorse = new StableHorse
            {
                StableIdFk = stableId,
                HorseIdFk = horseId
            };

            // Add the relationship to the database and save.
            context.StableHorses.Add(stableHorse);
            await context.SaveChangesAsync();
        
            return ApiResponse<Unit>.Success(
                HttpStatusCode.Created,
                Unit.Value, 
                "Connection between stable and horse was created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<Unit>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    // Removes a horse from a stable by deleting the relationship.
    public async Task<ApiResponse<Unit>> RemoveHorseFromStableAsync(int stableHorseId)
    {
        try
        {
            // Find the stable-horse relationship to remove.
            var stableHorse = await context.StableHorses
                .Where(sh => sh.Id == stableHorseId)
                .FirstOrDefaultAsync();
            
            // Returns an error if the relationship doesn't exist.
            if (stableHorse == null)
                return ApiResponse<Unit>.Failure(
                    HttpStatusCode.NotAcceptable,
                    "Error: Connection between horse and stable was not found.");

            // Remove the relationship from the database.
            context.StableHorses.Remove(stableHorse);
            await context.SaveChangesAsync();
            
            return ApiResponse<Unit>.Success(
                HttpStatusCode.OK,
                Unit.Value,
                null);
        }
        catch (Exception ex)
        {
            return ApiResponse<Unit>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
}