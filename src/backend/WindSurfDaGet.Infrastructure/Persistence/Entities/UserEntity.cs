namespace WindSurfDaGet.Infrastructure.Persistence.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
