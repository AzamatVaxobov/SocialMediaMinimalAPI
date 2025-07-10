using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services;

public class LikeService : ILikeService
{
    private readonly ILikeRepository _likeRepository;

    public LikeService(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public Task<int> LikePostAsync(int postId, int userId) => _likeRepository.LikePostAsync(postId, userId);

    public Task<int> GetLikeCountAsync(int postId) => _likeRepository.GetLikeCountAsync(postId);

    public Task<bool> UnlikePostAsync(int postId, int userId) => _likeRepository.RemoveLikeAsync(postId, userId);
}