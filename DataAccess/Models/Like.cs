namespace DataAccess.Models;

public class Like
{
    public int Id { get; set; }          // Primary Key
    public int PostId { get; set; }      // Foreign Key: The post being liked
    public int UserId { get; set; }      // Foreign Key: The user who liked the post
}