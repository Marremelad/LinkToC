﻿using System.Net;
using AutoMapper;
using equilog_backend.Common;
using equilog_backend.Data;
using equilog_backend.DTOs.StablePostDTOs;
using equilog_backend.Interfaces;
using equilog_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace equilog_backend.Services;

// Service that manages stable posts (announcements, news, and communications) within stables.
// Handles CRUD operations for posts, including special features like pinning important announcements.
public class StablePostService(EquilogDbContext context, IMapper mapper) : IStablePostService
{
    // Retrieves all posts associated with a specific stable including author information.
    public async Task<ApiResponse<List<StablePostDto>?>> GetStablePostsByStableIdAsync(int stableId)
    {
        try
        {
            // Fetch stable posts for the specified stable and include user (author) information.
            var stablePostDtos = mapper.Map<List<StablePostDto>>(
                await context.StablePosts
                .Where(sp => sp.StableIdFk == stableId)
                .Include(sp => sp.User)
                .ToListAsync());
            
            // Provides an appropriate message based on whether posts were found or not.
             var message = stablePostDtos.Count == 0
                ? "Operation successful but stable has no stable-posts."
                : "Stable-posts fetched successfully.";

            return ApiResponse<List<StablePostDto>>.Success(
                HttpStatusCode.OK,
                stablePostDtos,
                message);
        }
        catch (Exception ex)
        {
            return ApiResponse<List<StablePostDto>>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    // Retrieves a specific stable post by its ID including author information.
    public async Task<ApiResponse<StablePostDto?>> GetStablePostByStablePostIdAsync(int stablePostId)
    {
        try
        {  
            // Find the stable post with author information included.
            var stablePost = await context.StablePosts
                .Include(sp => sp.User)
                .Where(sp => sp.Id == stablePostId)
                .FirstOrDefaultAsync();

            // Returns an error if the stable post doesn't exist.
            if (stablePost == null)
                return ApiResponse<StablePostDto>.Failure(
                    HttpStatusCode.NotFound,
                "Error: Stable-post not found.");

            return ApiResponse<StablePostDto>.Success(
                HttpStatusCode.OK,
                mapper.Map<StablePostDto>(stablePost),
                "Stable-post fetched successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<StablePostDto>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    // Creates a new stable post and returns the created post with generated ID.
    public async Task<ApiResponse<StablePostDto?>> CreateStablePostAsync(StablePostCreateDto stablePostCreateDto)
    {
        try
        {
            // Map the creation DTO to a stable post-entity.
            var stablePost = mapper.Map<StablePost>(stablePostCreateDto);

            // Add the stable post to the database and save to generate ID.
            context.StablePosts.Add(stablePost);
            await context.SaveChangesAsync();

            return ApiResponse<StablePostDto>.Success(
                HttpStatusCode.Created,
                mapper.Map<StablePostDto>(stablePost),
                "Stable-post created successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<StablePostDto>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    // Updates an existing stable post with new content information.
    public async Task<ApiResponse<Unit>> UpdateStablePostAsync(StablePostUpdateDto stablePostUpdateDto)
    {
        try
        {
            // Find the existing stable post to update.
            var stablePost = await context.StablePosts
                .Where(sp => sp.Id == stablePostUpdateDto.Id)
                .FirstOrDefaultAsync();
                
            // Returns an error if the stable post doesn't exist.
            if ( stablePost == null) 
                return ApiResponse<Unit>.Failure(
                    HttpStatusCode.NotFound ,
                "Error: Stable-post not found.");

            // Apply updates from DTO to an existing entity and save changes.
            mapper.Map(stablePostUpdateDto, stablePost);
            await context.SaveChangesAsync();

            return ApiResponse<Unit>.Success(
                HttpStatusCode.OK,
                Unit.Value,
                "Stable-post information updated successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<Unit>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    // Toggles the pinned status of a stable post.
    public async Task<ApiResponse<Unit>> ChangeStablePostIsPinnedFlagAsync(int stablePostId)
    {
        try
        {
            // Find the stable post to modify.
            var stablePost = await context.StablePosts
                .Where(sp => sp.Id == stablePostId)
                .FirstOrDefaultAsync();
            
            // Returns an error if the stable post doesn't exist.
            if (stablePost == null)
                return ApiResponse<Unit>.Failure(
                    HttpStatusCode.NotFound,
                    "Error: Stable-post not found.");

            // Toggle the pinned status (true becomes false, false becomes true).
            stablePost.IsPinned = !stablePost.IsPinned;
            await context.SaveChangesAsync();
            
            return ApiResponse<Unit>.Success(
                HttpStatusCode.OK,
                Unit.Value,
                "IsPinned flag for stable-post was changed successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<Unit>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }

    // Removes a stable post from the system along with all its relationships.
    public async Task<ApiResponse<Unit>> DeleteStablePostAsync(int stablePostId)
    {
        try
        {
            // Find the stable post to delete.
            var stablePost = await context.StablePosts
                .Where(sp => sp.Id == stablePostId)
                .FirstOrDefaultAsync();

            // Returns an error if the stable post doesn't exist.
            if (stablePost == null)
                return ApiResponse<Unit>.Failure(
                    HttpStatusCode.NotFound,
                "Error: Stable-post not found.");

            // Remove the stable post (cascade delete will handle related comments).
            context.StablePosts.Remove(stablePost);
            await context.SaveChangesAsync();

            return ApiResponse<Unit>.Success(
                HttpStatusCode.OK,
                Unit.Value,
                $"Stable-post with id '{stablePostId}' was deleted successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<Unit>.Failure(
                HttpStatusCode.InternalServerError,
                ex.Message);
        }
    }
}