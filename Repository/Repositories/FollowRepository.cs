using Dapper;
using DataAccess.DbContext;
using DataAccess.Models;
using Repository.Interfaces;

namespace Repository.Repositories;

public class FollowRepository : IFollowRepository
{
    private readonly DatabaseInitializer _dbInitializer;

    public FollowRepository(DatabaseInitializer dbInitializer)
    {
        _dbInitializer = dbInitializer;
    }

    public async Task<int> FollowUserAsync(int followerId, int followeeId)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "INSERT INTO follows (followerid, followeeid) VALUES (@FollowerId, @FolloweeId);";
        return await connection.ExecuteAsync(sql, new { FollowerId = followerId, FolloweeId = followeeId });
    }

    public async Task<bool> UnfollowUserAsync(int followerId, int followeeId)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "DELETE FROM follows WHERE followerid = @FollowerId AND followeeid = @FolloweeId;";
        var rowsAffected = await connection.ExecuteAsync(sql, new { FollowerId = followerId, FolloweeId = followeeId });
        return rowsAffected > 0;
    }

    public async Task<IEnumerable<User>> GetFollowersAsync(int userId)
    {
        using var connection = _dbInitializer.CreateConnection();

        const string sql = @"
        SELECT u.* FROM users u
        INNER JOIN follows f ON u.id = f.followerid
        WHERE f.followeeid = @UserId;";

        return await connection.QueryAsync<User>(sql, new { UserId = userId });
    }

    public async Task<IEnumerable<User>> GetFollowingAsync(int userId)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = @"
            SELECT u.* FROM users u
            INNER JOIN follows f ON u.id = f.followeeid
            WHERE f.followerid = @UserId;";
        return await connection.QueryAsync<User>(sql, new { UserId = userId });
    }
}