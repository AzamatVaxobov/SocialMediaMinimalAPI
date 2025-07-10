using Application.DTOs;
using DataAccess.Models;

namespace Application.Mappers;

public static class UserMapper
{
    // Map UserCreateDto to User (for POST operations)
    public static User ToModel(this UserCreateDto dto)
    {
        return new User
        {
            Username = dto.Username,
            Email = dto.Email
        };
    }

    // Map UserUpdateDto to User (for PUT operations)
    public static User ToModel(this UserCreateDto dto, int userId)
    {
        return new User
        {
            Id = userId, // Ensure the ID is preserved
            Username = dto.Username,
            Email = dto.Email
        };
    }

    // Map User (Model) to UserResponseDto (for returning data to clients)
    public static UserResponseDto ToResponseDto(this User user)
    {
        return new UserResponseDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email
        };
    }

    // Map a list of Users (Models) to a list of UserResponseDto (for GET /users)
    public static IEnumerable<UserResponseDto> ToResponseDtoList(this IEnumerable<User> users)
    {
        return users.Select(user => user.ToResponseDto());
    }
}