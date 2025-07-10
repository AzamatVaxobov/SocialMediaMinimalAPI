namespace Application.DTOs;

public class LikeDto
{
    public int PostId { get; set; }    // Post ID to be liked/unliked
    public int UserId { get; set; }    // User ID who is liking/unliking
}