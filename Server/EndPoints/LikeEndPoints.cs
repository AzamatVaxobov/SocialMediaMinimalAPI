using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;

namespace Endpoints;

public static class LikeEndpoints
{
    public static void Register(WebApplication app)
    {
        // Register Like API Endpoints here

        app.MapPost("/likes", async (ILikeService likeService, int postId, int userId) =>
        {
            await likeService.LikePostAsync(postId, userId);
            return Results.Ok(new { Message = "Post liked successfully." });
        });

        app.MapGet("/likes/{postId}/count", async (ILikeService likeService, int postId) =>
        {
            var count = await likeService.GetLikeCountAsync(postId);
            return Results.Ok(new { Count = count });
        });

        app.MapDelete("/likes", async (ILikeService likeService, int postId, int userId) =>
        {
            var success = await likeService.UnlikePostAsync(postId, userId);
            return success ? Results.Ok(new { Message = "Post unliked successfully." }) : Results.BadRequest();
        });
    }
}