namespace DataAccess.Models;

public class Post
{
    public int Id { get; set; }          // Primary Key
    public string Title { get; set; }    // Title of the post
    public string Body { get; set; }     // The content of the post
    public int AuthorId { get; set; }    // Foreign Key to User
}