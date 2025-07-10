using Application.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;

namespace Endpoints;

public static class UserEndpoints
{
    public static void Register(WebApplication app)
    {
        // Register User API Endpoints here

        app.MapPost("/users", async (IUserService userService, UserCreateDto userDto) =>
        {
            var userId = await userService.CreateUserAsync(userDto);
            return Results.Created($"/users/{userId}", new { Id = userId });
        });

        app.MapGet("/users/{id}", async (IUserService userService, int id) =>
        {
            var user = await userService.GetUserByIdAsync(id);
            return user == null ? Results.NotFound() : Results.Ok(user);
        });

        app.MapGet("/users", async (IUserService userService) =>
        {
            var users = await userService.GetAllUsersAsync();
            return Results.Ok(users);
        });

        app.MapPut("/users/{id}", async (IUserService userService, int id, UserCreateDto userDto) =>
        {
            var success = await userService.UpdateUserAsync(id, userDto);
            return success ? Results.NoContent() : Results.NotFound();
        });

        app.MapDelete("/users/{id}", async (IUserService userService, int id) =>
        {
            var success = await userService.DeleteUserAsync(id);
            return success ? Results.NoContent() : Results.NotFound();
        });
    }
}