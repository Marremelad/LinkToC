﻿using equilog_backend.Common;
using equilog_backend.DTOs.UserDTOs;
using equilog_backend.Interfaces;

namespace equilog_backend.Endpoints
{
    public class UserEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {

            // Get all users.
            app.MapGet("/api/user", GetUsers)
                .WithName("GetUsers");

            // Get user.
            app.MapGet("/api/user/{id:int}", GetUser)
                .WithName("GetUser");

            // Update user properties.
            app.MapPut("/api/user/update", UpdateUser)
            .AddEndpointFilter<ValidationFilter<UserUpdateDto>>()
                .WithName("UpdateUser");

            // Delete user.
            app.MapDelete("/api/user/delete/{id:int}", DeleteUser)
                .WithName("DeleteUser");
        }

        private static async Task<IResult> GetUsers(IUserService userService)
        {
            return Result.Generate(await userService.GetUsersAsync());
        }

        private static async Task<IResult> GetUser(IUserService userService, int id)
        {
            return Result.Generate(await userService.GetUserAsync(id));
        }

        private static async Task<IResult> UpdateUser(IUserService userService, UserUpdateDto updatedUser)
        {
            return Result.Generate(await userService.UpdateUserAsync(updatedUser));
        }

        private static async Task<IResult> DeleteUser(IUserService userService, int id)
        {
            return Result.Generate(await userService.DeleteUserAsync(id));
        }
    }
}