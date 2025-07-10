using Xunit;
using Moq;
using FluentAssertions;
using Service.Interfaces;
using Service.Services;
using Repository.Interfaces;
using System.Collections.Generic;
using DataAccess.Models;

namespace UnitTests.Services;

public class FollowServiceTests
{
    private readonly Mock<IFollowRepository> _mockFollowRepository;
    private readonly IFollowService _followService;

    public FollowServiceTests()
    {
        _mockFollowRepository = new Mock<IFollowRepository>();
        _followService = new FollowService(_mockFollowRepository.Object);
    }

    [Fact]
    public async Task FollowUserAsync_Should_Return_Id_Of_Follow_Record()
    {
        // Arrange
        var followerId = 1;
        var followeeId = 2;

        _mockFollowRepository
            .Setup(repo => repo.FollowUserAsync(followerId, followeeId))
            .ReturnsAsync(1); // Mock follow record ID

        // Act
        var result = await _followService.FollowUserAsync(followerId, followeeId);

        // Assert
        result.Should().Be(1);
        _mockFollowRepository.Verify(repo => repo.FollowUserAsync(followerId, followeeId), Times.Once);
    }

    [Fact]
    public async Task GetFollowersAsync_Should_Return_List_Of_FollowerIds()
    {
        // Arrange
        var userId = 2;
        var followers = new List<User>
    {
        new User { Id = 1, Username = "john_doe", Email = "john.doe@example.com" },
        new User { Id = 3, Username = "jane_doe", Email = "jane.doe@example.com" }
    };

        // Mock the repository to return IEnumerable<User>
        _mockFollowRepository
            .Setup(repo => repo.GetFollowersAsync(userId))
            .ReturnsAsync(followers); // Returning IEnumerable<User>

        // Act
        var result = await _followService.GetFollowersAsync(userId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(new List<int> { 1, 3 }); // Only the IDs
        _mockFollowRepository.Verify(repo => repo.GetFollowersAsync(userId), Times.Once);
    }

    [Fact]
    public async Task UnfollowUserAsync_Should_Return_True_When_Successful()
    {
        // Arrange
        var followerId = 1;
        var followeeId = 2;

        _mockFollowRepository
            .Setup(repo => repo.UnfollowUserAsync(followerId, followeeId))
            .ReturnsAsync(true);

        // Act
        var result = await _followService.UnfollowUserAsync(followerId, followeeId);

        // Assert
        result.Should().BeTrue();
        _mockFollowRepository.Verify(repo => repo.UnfollowUserAsync(followerId, followeeId), Times.Once);
    }
}