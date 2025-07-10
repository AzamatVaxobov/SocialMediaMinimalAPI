using Dapper;
using DataAccess.DbContext;
using DataAccess.Models;
using Repository.Interfaces;

namespace Repository.Repositories;

public class PostRepository : IPostRepository
{
    private readonly DatabaseInitializer _dbInitializer;

    public PostRepository(DatabaseInitializer dbInitializer)
    {
        _dbInitializer = dbInitializer;
    }

    public async Task<int> CreatePostAsync(Post post)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "INSERT INTO posts (title, body, authorid) VALUES (@Title, @Body, @AuthorId) RETURNING id;";
        return await connection.ExecuteScalarAsync<int>(sql, post);
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "SELECT * FROM posts WHERE id = @Id;";
        return await connection.QueryFirstOrDefaultAsync<Post>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "SELECT * FROM posts;";
        return await connection.QueryAsync<Post>(sql);
    }

    public async Task<IEnumerable<Post>> GetPostsByAuthorIdAsync(int authorId)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "SELECT * FROM posts WHERE authorid = @AuthorId;";
        return await connection.QueryAsync<Post>(sql, new { AuthorId = authorId });
    }

    public async Task<bool> UpdatePostAsync(Post post)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "UPDATE posts SET title = @Title, body = @Body WHERE id = @Id;";
        var rowsAffected = await connection.ExecuteAsync(sql, post);
        return rowsAffected > 0;
    }

    public async Task<bool> DeletePostAsync(int id)
    {
        using var connection = _dbInitializer.CreateConnection();
        const string sql = "DELETE FROM posts WHERE id = @Id;";
        var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;
    }
}