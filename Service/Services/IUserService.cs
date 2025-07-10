using Application.DTOs;

namespace Service.Interfaces;

public interface IUserService
{
    Task<int> CreateUserAsync(UserCreateDto userDto);
    Task<UserResponseDto?> GetUserByIdAsync(int id);
    Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
    Task<bool> UpdateUserAsync(int id, UserCreateDto userDto);
    Task<bool> DeleteUserAsync(int id);
}