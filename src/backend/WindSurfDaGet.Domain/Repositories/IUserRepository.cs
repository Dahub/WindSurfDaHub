using WindSurfDaGet.Domain.Models;

namespace WindSurfDaGet.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<int> CreateAsync(User user, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(string email, string username);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}
