using Application.DTOs;
using Application.Mappers;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // Create a new user
    public async Task<int> CreateUserAsync(UserCreateDto userDto)
    {
        var userModel = userDto.ToModel(); // Map DTO to Model
        return await _userRepository.CreateUserAsync(userModel);
    }

    // Get a user by ID
    public async Task<UserResponseDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return user?.ToResponseDto(); // Map Model to DTO
    }

    // Get all users
    public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.ToResponseDtoList(); // Map Model list to DTO list
    }

    // Update user details
    public async Task<bool> UpdateUserAsync(int id, UserCreateDto userDto)
    {
        var userModel = userDto.ToModel(id); // Map DTO to Model
        return await _userRepository.UpdateUserAsync(userModel);
    }

    // Delete a user by ID
    public Task<bool> DeleteUserAsync(int id)
    {
        return _userRepository.DeleteUserAsync(id);
    }
}