using System.Collections.Generic;

namespace Service.Interfaces;

public interface IFollowService
{
    Task<int> FollowUserAsync(int followerId, int followeeId);
    Task<bool> UnfollowUserAsync(int followerId, int followeeId);
    Task<IEnumerable<int>> GetFollowersAsync(int userId);   // Returns a list of User IDs
    Task<IEnumerable<int>> GetFollowingAsync(int userId);   // Returns a list of User IDs
}