using DataAccess.Models;

namespace Repository.Interfaces;

public interface IPostRepository
{
    Task<int> CreatePostAsync(Post post);
    Task<Post?> GetPostByIdAsync(int id);
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<IEnumerable<Post>> GetPostsByAuthorIdAsync(int authorId);
    Task<bool> UpdatePostAsync(Post post);
    Task<bool> DeletePostAsync(int id);
}