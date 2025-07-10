namespace DataAccess.Models;

public class Follow
{
    public int Id { get; set; }              // Primary Key
    public int FollowerId { get; set; }      // Foreign Key: Who is following
    public int FolloweeId { get; set; }      // Foreign Key: Who is being followed
}