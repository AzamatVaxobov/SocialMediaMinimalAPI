namespace Application.DTOs;

public class PostCreateDto
{
    public string Title { get; set; }    // Title of the post
    public string Body { get; set; }     // Content of the post
    public int AuthorId { get; set; }    // User ID of the post author
}