using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services;

public class FollowService : IFollowService
{
    private readonly IFollowRepository _followRepository;

    public FollowService(IFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }

    public Task<int> FollowUserAsync(int followerId, int followeeId)
        => _followRepository.FollowUserAsync(followerId, followeeId);

    public Task<bool> UnfollowUserAsync(int followerId, int followeeId)
        => _followRepository.UnfollowUserAsync(followerId, followeeId);

    public async Task<IEnumerable<int>> GetFollowersAsync(int userId)
    {
        // Fetch followers as User objects from the repository
        var users = await _followRepository.GetFollowersAsync(userId);

        // Map the User object to just User.Id
        return users.Select(user => user.Id);
    }

    public async Task<IEnumerable<int>> GetFollowingAsync(int userId)
    {
        // Fetch following as User objects from the repository
        var users = await _followRepository.GetFollowingAsync(userId);

        // Map the User object to just User.Id
        return users.Select(user => user.Id);
    }
}