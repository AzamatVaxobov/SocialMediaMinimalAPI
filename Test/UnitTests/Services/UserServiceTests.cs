using Xunit;
using Moq;
using FluentAssertions;
using Service.Interfaces;
using Service.Services;
using Repository.Interfaces;
using DataAccess.Models;
using Application.DTOs;

namespace UnitTests.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository; // Mock repository
    private readonly IUserService _userService;                // Service under test

    public UserServiceTests()
    {
        // Initialize mock and service
        _mockUserRepository = new Mock<IUserRepository>();
        _userService = new UserService(_mockUserRepository.Object);
    }

    [Fact]
    public async Task CreateUserAsync_Should_Return_NewUserId()
    {
        // Arrange
        var createUserDto = new UserCreateDto
        {
            Username = "john_doe",
            Email = "john.doe@example.com"
        };

        var userModel = new User
        {
            Id = 1,
            Username = createUserDto.Username,
            Email = createUserDto.Email
        };

        _mockUserRepository
            .Setup(repo => repo.CreateUserAsync(It.IsAny<User>()))
            .ReturnsAsync(userModel.Id);

        // Act
        var result = await _userService.CreateUserAsync(createUserDto);

        // Assert
        result.Should().Be(1); // New user's ID
        _mockUserRepository.Verify(repo => repo.CreateUserAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task GetUserByIdAsync_Should_Return_UserResponseDto_When_UserExists()
    {
        // Arrange
        var userId = 1;
        var userModel = new User
        {
            Id = userId,
            Username = "john_doe",
            Email = "john.doe@example.com"
        };

        _mockUserRepository
            .Setup(repo => repo.GetUserByIdAsync(userId))
            .ReturnsAsync(userModel); // Mock repo returns user

        // Act
        var result = await _userService.GetUserByIdAsync(userId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(new
        {
            Id = userId,
            Username = "john_doe",
            Email = "john.doe@example.com"
        });

        _mockUserRepository.Verify(repo => repo.GetUserByIdAsync(userId), Times.Once);
    }

    [Fact]
    public async Task GetUserByIdAsync_Should_Return_Null_When_UserDoesNotExist()
    {
        // Arrange
        var userId = 99;

        _mockUserRepository
            .Setup(repo => repo.GetUserByIdAsync(userId))
            .ReturnsAsync((User?)null); // User not found

        // Act
        var result = await _userService.GetUserByIdAsync(userId);

        // Assert
        result.Should().BeNull();
        _mockUserRepository.Verify(repo => repo.GetUserByIdAsync(userId), Times.Once);
    }

    [Fact]
    public async Task GetAllUsersAsync_Should_Return_ListOfUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = 1, Username = "john_doe", Email = "john.doe@example.com" },
            new User { Id = 2, Username = "jane_doe", Email = "jane.doe@example.com" }
        };

        _mockUserRepository
            .Setup(repo => repo.GetAllUsersAsync())
            .ReturnsAsync(users);

        // Act
        var result = await _userService.GetAllUsersAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(new[]
        {
            new { Id = 1, Username = "john_doe", Email = "john.doe@example.com" },
            new { Id = 2, Username = "jane_doe", Email = "jane.doe@example.com" }
        });

        _mockUserRepository.Verify(repo => repo.GetAllUsersAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateUserAsync_Should_Return_True_When_UpdateIsSuccessful()
    {
        // Arrange
        var userId = 1;
        var updatedUserDto = new UserCreateDto
        {
            Username = "john_updated",
            Email = "john.updated@example.com"
        };

        _mockUserRepository
            .Setup(repo => repo.UpdateUserAsync(It.IsAny<User>()))
            .ReturnsAsync(true);

        // Act
        var result = await _userService.UpdateUserAsync(userId, updatedUserDto);

        // Assert
        result.Should().BeTrue();
        _mockUserRepository.Verify(repo => repo.UpdateUserAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task DeleteUserAsync_Should_Return_True_When_DeleteIsSuccessful()
    {
        // Arrange
        var userId = 1;

        _mockUserRepository
            .Setup(repo => repo.DeleteUserAsync(userId))
            .ReturnsAsync(true);

        // Act
        var result = await _userService.DeleteUserAsync(userId);

        // Assert
        result.Should().BeTrue();
        _mockUserRepository.Verify(repo => repo.DeleteUserAsync(userId), Times.Once);
    }
}