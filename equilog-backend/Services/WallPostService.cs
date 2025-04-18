﻿using AutoMapper;
using equilog_backend.Common;
using equilog_backend.Data;
using equilog_backend.DTOs.WallPostDTOs;
using equilog_backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace equilog_backend.Services
{
    public class WallPostService(EquilogDbContext context, IMapper mapper) : IWallPostService
    {
        public async Task<ApiResponse<WallPostDto?>> GetWallPost(int stableId)
        {
            try
            {
                var wallPost = await context.WallPosts
                    .Where(wp => wp.StableIdFk == stableId)
                    .FirstOrDefaultAsync();

                if (wallPost == null)
                {
                    return ApiResponse<WallPostDto>.Failure(HttpStatusCode.NotFound,
                    "Error: WallPost not found");
                }

                return ApiResponse<WallPostDto>.Success(HttpStatusCode.OK,
                    mapper.Map<WallPostDto>(wallPost),
                    null);
            }
            catch (Exception ex)
            {
                return ApiResponse<WallPostDto>.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<ApiResponse<WallPostDto?>> ReplaceWallPost(WallPostReplaceDto wallPostReplaceDto)
        {
            try
            {
                var wallPost = await context.WallPosts
                    .Where(wp => wp.StableIdFk == wallPostReplaceDto.StableIdFk)
                    .FirstOrDefaultAsync();

                if (wallPost == null)
                {
                    return ApiResponse<WallPostDto>.Failure(HttpStatusCode.NotFound,
                    "Error: WallPost not found");
                }
                    
                mapper.Map(wallPostReplaceDto, wallPost);
                wallPost.PostDate = DateTime.UtcNow;
                wallPost.LastEdited = null;
                await context.SaveChangesAsync();

                return ApiResponse<WallPostDto>.Success(HttpStatusCode.OK,
                    mapper.Map<WallPostDto>(wallPost),
                    "Posted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<WallPostDto>.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<ApiResponse<WallPostDto?>> EditWallPost(WallPostEditDto wallPostEditDto)
        {
            try
            {
                var wallPost = await context.WallPosts
                    .Where(wp => wp.StableIdFk == wallPostEditDto.StableIdFk)
                    .FirstOrDefaultAsync();

                if (wallPost == null)
                    return ApiResponse<WallPostDto>.Failure(HttpStatusCode.NotFound,
                    "Error: WallPost not found");

                mapper.Map(wallPostEditDto, wallPost);
                wallPost.LastEdited = DateTime.UtcNow;
                await context.SaveChangesAsync();

                return ApiResponse<WallPostDto>.Success(HttpStatusCode.OK,
                    mapper.Map<WallPostDto>(wallPost),
                    "Edited successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<WallPostDto>.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        public async Task<ApiResponse<WallPostDto?>> ClearWallPost(int stableId)
        {
            try
            {
                var wallPost = await context.WallPosts
                    .Where(wp => wp.StableIdFk == stableId)
                    .FirstOrDefaultAsync();

                if (wallPost == null)
                {
                    return ApiResponse<WallPostDto>.Failure(HttpStatusCode.NotFound,
                        "Error: Wall post not found for this stable");
                }

                var ClearPost = new WallPostClearDto();
                mapper.Map(ClearPost, wallPost);
                await context.SaveChangesAsync();

                return ApiResponse<WallPostDto>.Success(HttpStatusCode.OK,
                    mapper.Map<WallPostDto>(wallPost),
                    "Wallpost cleared successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<WallPostDto>.Failure(HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }
    }
}
