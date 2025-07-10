namespace Service.Interfaces;

public interface ILikeService
{
    Task<int> LikePostAsync(int postId, int userId);
    Task<int> GetLikeCountAsync(int postId);
    Task<bool> UnlikePostAsync(int postId, int userId);
}