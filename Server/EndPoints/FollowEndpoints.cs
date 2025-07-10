using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;

namespace Endpoints;

public static class FollowEndpoints
{
    public static void Register(WebApplication app)
    {
        // Register Follow API Endpoints here

        app.MapPost("/follows", async (IFollowService followService, int followerId, int followeeId) =>
        {
            var id = await followService.FollowUserAsync(followerId, followeeId);
            return Results.Ok(new { Id = id, Message = "User followed successfully." });
        });

        app.MapGet("/follows/{userId}/followers", async (IFollowService followService, int userId) =>
        {
            var followers = await followService.GetFollowersAsync(userId);
            return Results.Ok(followers);
        });

        app.MapGet("/follows/{userId}/following", async (IFollowService followService, int userId) =>
        {
            var following = await followService.GetFollowingAsync(userId);
            return Results.Ok(following);
        });

        app.MapDelete("/follows", async (IFollowService followService, int followerId, int followeeId) =>
        {
            var success = await followService.UnfollowUserAsync(followerId, followeeId);
            return success ? Results.Ok(new { Message = "User unfollowed successfully." }) : Results.BadRequest();
        });
    }
}