namespace WindSurfDaGet.Domain.Models;

public class User
{
    public int Id { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }

    private User(int id, string email, string username, string passwordHash)
    {
        Id = id;
        Email = email;
        Username = username;
        PasswordHash = passwordHash;
    }

    public static User Create(string email, string username, string passwordHash)
    {
        return new User(0, email, username, passwordHash);
    }

    public static User FromPersistence(int id, string email, string username, string passwordHash)
    {
        return new User(id, email, username, passwordHash);
    }
}
