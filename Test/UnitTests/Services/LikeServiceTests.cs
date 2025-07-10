using Xunit;
using Moq;
using FluentAssertions;
using Service.Interfaces;
using Service.Services;
using Repository.Interfaces;

namespace UnitTests.Services;

public class LikeServiceTests
{
    private readonly Mock<ILikeRepository> _mockLikeRepository;
    private readonly ILikeService _likeService;

    public LikeServiceTests()
    {
        _mockLikeRepository = new Mock<ILikeRepository>();
        _likeService = new LikeService(_mockLikeRepository.Object);
    }

    [Fact]
    public async Task LikePostAsync_Should_Return_True_When_PostIsLiked()
    {
        // Arrange
        var postId = 1;
        var userId = 1;

        _mockLikeRepository
            .Setup(repo => repo.LikePostAsync(postId, userId))
            .ReturnsAsync(1); // Mock that one row was inserted

        // Act
        var result = await _likeService.LikePostAsync(postId, userId);

        // Assert
        result.Should().Be(1);
        _mockLikeRepository.Verify(repo => repo.LikePostAsync(postId, userId), Times.Once);
    }

    [Fact]
    public async Task GetLikeCountAsync_Should_Return_Correct_Number_Of_Likes()
    {
        // Arrange
        var postId = 1;

        _mockLikeRepository
            .Setup(repo => repo.GetLikeCountAsync(postId))
            .ReturnsAsync(5); // Mock 5 likes

        // Act
        var result = await _likeService.GetLikeCountAsync(postId);

        // Assert
        result.Should().Be(5);
        _mockLikeRepository.Verify(repo => repo.GetLikeCountAsync(postId), Times.Once);
    }

    [Fact]
    public async Task UnlikePostAsync_Should_Return_True_When_Successful()
    {
        // Arrange
        var postId = 1;
        var userId = 1;

        _mockLikeRepository
            .Setup(repo => repo.RemoveLikeAsync(postId, userId))
            .ReturnsAsync(true);

        // Act
        var result = await _likeService.UnlikePostAsync(postId, userId);

        // Assert
        result.Should().BeTrue();
        _mockLikeRepository.Verify(repo => repo.RemoveLikeAsync(postId, userId), Times.Once);
    }
}