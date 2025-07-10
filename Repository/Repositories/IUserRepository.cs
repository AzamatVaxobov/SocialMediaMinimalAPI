using DataAccess.Models;

namespace Repository.Interfaces;

public interface IUserRepository
{
    // Create a new user in the database
    Task<int> CreateUserAsync(User user);

    // Retrieve a user by their ID
    Task<User?> GetUserByIdAsync(int id);

    // Retrieve all users from the database
    Task<IEnumerable<User>> GetAllUsersAsync();

    // Update an existing user
    Task<bool> UpdateUserAsync(User user);

    // Delete a user by their ID
    Task<bool> DeleteUserAsync(int id);
}