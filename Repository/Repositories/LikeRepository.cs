using Dapper;
using DataAccess.DbContext;
using Repository.Interfaces;

namespace Repository.Repositories;

public class LikeRepository : ILikeRepository
{
    private readonly DatabaseInitializer _dbInitializer;

    public LikeRepository(DatabaseInitializer dbInitializer)
    {
        _dbInitializer = dbInitializer;
    }

    public async Task<int> LikePostAsync(int postId, int userId)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "INSERT INTO likes (postid, userid) VALUES (@PostId, @UserId);";
        return await connection.ExecuteAsync(sql, new { PostId = postId, UserId = userId });
    }

    public async Task<int> GetLikeCountAsync(int postId)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "SELECT COUNT(*) FROM likes WHERE postid = @PostId;";
        return await connection.ExecuteScalarAsync<int>(sql, new { PostId = postId });
    }

    public async Task<bool> RemoveLikeAsync(int postId, int userId)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "DELETE FROM likes WHERE postid = @PostId AND userid = @UserId;";
        var rowsAffected = await connection.ExecuteAsync(sql, new { PostId = postId, UserId = userId });
        return rowsAffected > 0;
    }
}