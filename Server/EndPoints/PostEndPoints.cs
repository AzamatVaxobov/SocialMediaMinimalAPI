using Application.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;

namespace Endpoints;

public static class PostEndpoints
{
    public static void Register(WebApplication app)
    {
        // Register Post API Endpoints here

        app.MapPost("/posts", async (IPostService postService, PostCreateDto dto) =>
        {
            var postId = await postService.CreatePostAsync(dto);
            return Results.Created($"/posts/{postId}", new { Id = postId });
        });

        app.MapGet("/posts/{id}", async (IPostService postService, int id) =>
        {
            var post = await postService.GetPostByIdAsync(id);
            return post == null ? Results.NotFound() : Results.Ok(post);
        });

        app.MapGet("/posts", async (IPostService postService) =>
        {
            var posts = await postService.GetAllPostsAsync();
            return Results.Ok(posts);
        });

        app.MapGet("/posts/author/{authorId}", async (IPostService postService, int authorId) =>
        {
            var posts = await postService.GetPostsByAuthorIdAsync(authorId);
            return Results.Ok(posts);
        });

        app.MapDelete("/posts/{id}", async (IPostService postService, int id) =>
        {
            var success = await postService.DeletePostAsync(id);
            return success ? Results.NoContent() : Results.NotFound();
        });
    }
}