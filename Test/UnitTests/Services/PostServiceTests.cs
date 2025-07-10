using Xunit;
using Moq;
using FluentAssertions;
using Service.Interfaces;
using Service.Services;
using Repository.Interfaces;
using DataAccess.Models;
using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests.Services;

public class PostServiceTests
{
    private readonly Mock<IPostRepository> _mockPostRepository;
    private readonly IPostService _postService;

    public PostServiceTests()
    {
        _mockPostRepository = new Mock<IPostRepository>();
        _postService = new PostService(_mockPostRepository.Object);
    }

    [Fact]
    public async Task CreatePostAsync_Should_Return_NewPostId()
    {
        // Arrange
        var postCreateDto = new PostCreateDto
        {
            Title = "My First Post",
            Body = "This is the content of the first post.",
            AuthorId = 1
        };

        var postModel = new Post
        {
            Id = 1,
            Title = postCreateDto.Title,
            Body = postCreateDto.Body,
            AuthorId = postCreateDto.AuthorId
        };

        _mockPostRepository
            .Setup(repo => repo.CreatePostAsync(It.IsAny<Post>()))
            .ReturnsAsync(postModel.Id);

        // Act
        var result = await _postService.CreatePostAsync(postCreateDto);

        // Assert
        result.Should().Be(1);
        _mockPostRepository.Verify(repo => repo.CreatePostAsync(It.IsAny<Post>()), Times.Once);
    }

    [Fact]
    public async Task GetPostByIdAsync_Should_Return_PostResponseDto_When_PostExists()
    {
        // Arrange
        var postId = 1;
        var postModel = new Post
        {
            Id = postId,
            Title = "My First Post",
            Body = "This is the content of the first post.",
            AuthorId = 1
        };

        _mockPostRepository
            .Setup(repo => repo.GetPostByIdAsync(postId))
            .ReturnsAsync(postModel);

        // Act
        var result = await _postService.GetPostByIdAsync(postId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(new
        {
            Id = postId,
            Title = "My First Post",
            Body = "This is the content of the first post.",
            AuthorId = 1
        });

        _mockPostRepository.Verify(repo => repo.GetPostByIdAsync(postId), Times.Once);
    }

    [Fact]
    public async Task GetAllPostsAsync_Should_Return_ListOfPosts()
    {
        // Arrange
        var posts = new List<Post>
        {
            new Post { Id = 1, Title = "Post 1", Body = "Body 1", AuthorId = 2 },
            new Post { Id = 2, Title = "Post 2", Body = "Body 2", AuthorId = 3 }
        };

        _mockPostRepository
            .Setup(repo => repo.GetAllPostsAsync())
            .ReturnsAsync(posts);

        // Act
        var result = await _postService.GetAllPostsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(new[]
        {
            new { Id = 1, Title = "Post 1", Body = "Body 1", AuthorId = 2 },
            new { Id = 2, Title = "Post 2", Body = "Body 2", AuthorId = 3 }
        });

        _mockPostRepository.Verify(repo => repo.GetAllPostsAsync(), Times.Once);
    }

    [Fact]
    public async Task DeletePostAsync_Should_Return_True_When_DeleteIsSuccessful()
    {
        // Arrange
        var postId = 1;

        _mockPostRepository
            .Setup(repo => repo.DeletePostAsync(postId))
            .ReturnsAsync(true);

        // Act
        var result = await _postService.DeletePostAsync(postId);

        // Assert
        result.Should().BeTrue();
        _mockPostRepository.Verify(repo => repo.DeletePostAsync(postId), Times.Once);
    }
}