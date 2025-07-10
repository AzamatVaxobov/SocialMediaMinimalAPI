namespace DataAccess.Models;

public class User
{
    public int Id { get; set; }          // Primary Key
    public string Username { get; set; } // Username cannot be null
    public string Email { get; set; }    // Email should be unique
}