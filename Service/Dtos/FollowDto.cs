namespace Application.DTOs;

public class FollowDto
{
    public int FollowerId { get; set; }  // User ID of the follower
    public int FolloweeId { get; set; }  // User ID being followed
}