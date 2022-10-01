namespace User.Api.Models;

public class UserModel
{
    public UserModel(
        Guid id, 
        string userName, 
        string firstName, 
        string lastName, 
        string email, 
        string password, 
        string status, 
        DateTime createdAt,
        DateTime lastUpdatedAt)
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Status = status;
        CreatedAt = createdAt;
        LastUpdatedAt = lastUpdatedAt;
    }

    public Guid Id { get; }
    public string UserName { get; } 
    public string FirstName { get; } 
    public string LastName { get;  } 
    public string Email { get; } 
    public string Password { get; }
    public string Status { get; }
    
    public DateTime CreatedAt { get; }
    public DateTime LastUpdatedAt { get; }
    
    
}