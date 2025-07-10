using DataAccess.Models;

namespace Repository.Interfaces;

public interface ILikeRepository
{
    Task<int> LikePostAsync(int postId, int userId);     // Add a like
    Task<int> GetLikeCountAsync(int postId);             // Count likes for a post
    Task<bool> RemoveLikeAsync(int postId, int userId);  // Unlike a post
}