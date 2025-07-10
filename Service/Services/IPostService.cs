using Application.DTOs;

namespace Service.Interfaces;

public interface IPostService
{
    Task<int> CreatePostAsync(PostCreateDto dto);
    Task<PostResponseDto?> GetPostByIdAsync(int id);
    Task<IEnumerable<PostResponseDto>> GetAllPostsAsync();
    Task<IEnumerable<PostResponseDto>> GetPostsByAuthorIdAsync(int authorId);
    Task<bool> DeletePostAsync(int id);
}