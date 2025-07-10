using DataAccess.Models;

namespace Repository.Interfaces;

public interface IFollowRepository
{
    Task<int> FollowUserAsync(int followerId, int followeeId);         // Follow a user
    Task<bool> UnfollowUserAsync(int followerId, int followeeId);      // Unfollow a user
    Task<IEnumerable<User>> GetFollowersAsync(int userId);             // Get followers of a user
    Task<IEnumerable<User>> GetFollowingAsync(int userId);             // Get the users a user is following
}