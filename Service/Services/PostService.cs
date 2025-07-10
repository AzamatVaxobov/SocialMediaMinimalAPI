using Application.DTOs;
using Application.Mappers;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<int> CreatePostAsync(PostCreateDto dto)
    {
        var model = dto.ToModel();
        return await _postRepository.CreatePostAsync(model);
    }

    public async Task<PostResponseDto?> GetPostByIdAsync(int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        return post?.ToResponseDto();
    }

    public async Task<IEnumerable<PostResponseDto>> GetAllPostsAsync()
    {
        var posts = await _postRepository.GetAllPostsAsync();
        return posts.ToResponseDtoList();
    }

    public async Task<IEnumerable<PostResponseDto>> GetPostsByAuthorIdAsync(int authorId)
    {
        var posts = await _postRepository.GetPostsByAuthorIdAsync(authorId);
        return posts.ToResponseDtoList();
    }

    public async Task<bool> DeletePostAsync(int id)
    {
        return await _postRepository.DeletePostAsync(id);
    }
}