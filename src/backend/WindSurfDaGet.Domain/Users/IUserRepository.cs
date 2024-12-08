namespace WindSurfDaGet.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUsernameAsync(string username);
    Task<bool> ExistsAsync(string email, string username);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}
