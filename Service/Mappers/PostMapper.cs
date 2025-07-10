using Application.DTOs;
using DataAccess.Models;

namespace Application.Mappers;

public static class PostMapper
{
    // Map PostCreateDto to Post (Model)
    public static Post ToModel(this PostCreateDto dto)
    {
        return new Post
        {
            Title = dto.Title,
            Body = dto.Body,
            AuthorId = dto.AuthorId
        };
    }

    // Map Post (Model) to PostResponseDto
    public static PostResponseDto ToResponseDto(this Post model)
    {
        return new PostResponseDto
        {
            Id = model.Id,
            Title = model.Title,
            Body = model.Body,
            AuthorId = model.AuthorId
        };
    }

    // Map a list of Post objects to a list of PostResponseDto
    public static IEnumerable<PostResponseDto> ToResponseDtoList(this IEnumerable<Post> posts)
    {
        return posts.Select(post => post.ToResponseDto());
    }
}