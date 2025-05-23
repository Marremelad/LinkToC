﻿using System.Net;
using AutoMapper;
using equilog_backend.Common;
using equilog_backend.Data;
using equilog_backend.DTOs.StableDTOs;
using equilog_backend.Interfaces;
using equilog_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace equilog_backend.Services;

public class StableService(EquilogDbContext context, IMapper mapper) : IStableService
{
    public async Task<ApiResponse<StableDto?>> GetStableByStableIdAsync(int stableId)
    {
        try
        {
            var stable = await context.Stables
                .Include(s => s.UserStables)
                .Include(s => s.StableHorses)
                .Where(s => s.Id == stableId)
                .FirstOrDefaultAsync();
            
            if (stable == null)
                return ApiResponse<StableDto>.Failure(HttpStatusCode.NotFound,
                    "Error: Stable not found.");
            
            return ApiResponse<StableDto>.Success(HttpStatusCode.OK,
                mapper.Map<StableDto>(stable),
                "Stable fetched successfully.");
        }
        catch (Exception ex)
        {
           return ApiResponse<StableDto?>.Failure(HttpStatusCode.InternalServerError,
               ex.Message);
        }
    }
    
    public async Task<ApiResponse<List<StableSearchDto>?>> SearchStablesAsync(
        StableSearchParametersDto stableSearchParametersDto)
    {
        try
        {
            var searchTerm = stableSearchParametersDto.SearchTerm;
            var page = stableSearchParametersDto.Page;
            var pageSize = stableSearchParametersDto.PageSize;
            
            // maybe put this in validator?
            page = Math.Max(0, page);
            pageSize = Math.Clamp(pageSize, 1, 50);
            if (searchTerm.Length > 50)
            {
                searchTerm = searchTerm.Substring(0, 50);
            }
            
            var query = context.Stables.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim()
                    .ToLower();

                var starts = $"{term}%";
                var contains = $"%{term}%";

                query = query
                    .Where(s =>
                        EF.Functions.Like(s.Name, starts) ||
                        EF.Functions.Like(s.Name, contains) ||
                        EF.Functions.Like(s.County, contains) ||
                        EF.Functions.Like(s.Address, contains)
                    );

                query = query
                    .OrderBy(s =>
                         EF.Functions.Like(s.Name, starts) ? 0 :
                         EF.Functions.Like(s.Name, contains) ? 1 :
                         EF.Functions.Like(s.County, contains) ? 2 :
                         EF.Functions.Like(s.Address, contains) ? 3 : 4)
                    .ThenBy(s => s.Name);
            }
            else
            {
                query = query.OrderBy(s => s.Name);
            }

            var pagedResults = await query
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync()
                .ConfigureAwait(false);

            return ApiResponse<List<StableSearchDto>>.Success(HttpStatusCode.OK,
                mapper.Map<List<StableSearchDto>>(pagedResults),
                "Stables fetched successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<List<StableSearchDto>>.Failure(HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
    
    public async Task<ApiResponse<int>> CreateStableAsync(StableCreateDto stableCreateDto)
   {
      try
      {
            var stable = mapper.Map<Stable>(stableCreateDto);

            context.Stables.Add(stable);
            await context.SaveChangesAsync();

            return ApiResponse<int>.Success(HttpStatusCode.Created,
            stable.Id, 
            "Stable created successfully.");
      }
      catch (Exception ex)
      {
         return ApiResponse<int>.Failure(HttpStatusCode.InternalServerError,
            ex.Message);
      }
   }

   public async Task<ApiResponse<Unit>> UpdateStableAsync(StableUpdateDto stableUpdateDto)
   {
      try
      {
         var stable = await context.Stables
            .Where(s => s.Id == stableUpdateDto.Id)
            .FirstOrDefaultAsync();

         if (stable == null)
            return ApiResponse<Unit>.Failure(HttpStatusCode.NotFound,
               "Error: Stable not found.");

         mapper.Map(stableUpdateDto, stable);
         await context.SaveChangesAsync();

         return ApiResponse<Unit>.Success(HttpStatusCode.OK,
            Unit.Value,
            "Stable information updated successfully.");
      }
      catch (Exception ex)
      {
         return ApiResponse<Unit>.Failure(HttpStatusCode.InternalServerError,
            ex.Message);
      }
   }

   public async Task<ApiResponse<Unit>> DeleteStableAsync(int stableId)
   {
      try
      {
         var stable = await context.Stables
            .Where(s => s.Id == stableId)
            .FirstOrDefaultAsync();

         if (stable == null)
            return ApiResponse<Unit>.Failure(HttpStatusCode.NotFound,
               "Error: stable not found");

         context.Stables.Remove(stable);
         await context.SaveChangesAsync();

         return ApiResponse<Unit>.Success(HttpStatusCode.OK,
            Unit.Value, 
            $"Stable with id '{stableId}' was deleted successfully");
      }
      catch (Exception ex)
      {
         return ApiResponse<Unit>.Failure(HttpStatusCode.InternalServerError,
            ex.Message);
      }
   }
}