using WindSurfDaGet.Domain.Entities;

namespace WindSurfDaGet.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<int> CreateAsync(User user, CancellationToken cancellationToken);
}
