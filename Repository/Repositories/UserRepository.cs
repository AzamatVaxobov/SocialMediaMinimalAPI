using Dapper;
using DataAccess.DbContext; // Include the DatabaseInitializer class
using DataAccess.Models;
using Repository.Interfaces;

namespace Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseInitializer _dbInitializer;

    // Constructor to inject DatabaseInitializer (via Dependency Injection)
    public UserRepository(DatabaseInitializer dbInitializer)
    {
        _dbInitializer = dbInitializer;
    }

    // Create a new user in the database
    public async Task<int> CreateUserAsync(User user)
    {
        using var connection = _dbInitializer.CreateConnection(); // Opens a PostgreSQL connection

        const string sql = "INSERT INTO users (username, email) VALUES (@Username, @Email) RETURNING id;";

        // Executes SQL query and returns the newly created user's ID
        return await connection.ExecuteScalarAsync<int>(sql, user);
    }

    // Retrieve a single user by ID
    public async Task<User?> GetUserByIdAsync(int id)
    {
        using var connection = _dbInitializer.CreateConnection(); // Opens a connection with PostgreSQL

        const string sql = "SELECT * FROM users WHERE id = @Id;";

        // Query PostgreSQL and retrieve the user (null if not found)
        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
    }

    // Retrieve all users from the database
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        using var connection = _dbInitializer.CreateConnection();

        const string sql = "SELECT * FROM users;";

        // Query PostgreSQL to get all user records
        return await connection.QueryAsync<User>(sql);
    }

    // Update a user in the database
    public async Task<bool> UpdateUserAsync(User user)
    {
        using var connection = _dbInitializer.CreateConnection();

        const string sql = "UPDATE users SET username = @Username, email = @Email WHERE id = @Id;";

        // Execute the update query and return true if any row was updated
        var rowsAffected = await connection.ExecuteAsync(sql, user);
        return rowsAffected > 0;
    }

    // Delete a user from the database by their ID
    public async Task<bool> DeleteUserAsync(int id)
    {
        using var connection = _dbInitializer.CreateConnection();

        const string sql = "DELETE FROM users WHERE id = @Id;";

        // Execute the delete query and check if a row was affected
        var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;
    }
}