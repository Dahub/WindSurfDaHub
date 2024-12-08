using Microsoft.EntityFrameworkCore;
using WindSurfDaGet.Domain.Models;
using WindSurfDaGet.Domain.Repositories;
using WindSurfDaGet.Infrastructure.Persistence.Mapping;

namespace WindSurfDaGet.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var entity = await _context.Users.FindAsync(id);

        return entity?.ToDomain();
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var entity = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        return entity?.ToDomain();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        var entity = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        return entity?.ToDomain();
    }

    public async Task<bool> ExistsAsync(string email, string username)
    {
        return await _context.Users.AnyAsync(u => u.Email == email || u.Username == username);
    }

    public async Task AddAsync(User user)
    {
        var entity = user.ToEntity();

        await _context.Users.AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<int> CreateAsync(User user, CancellationToken cancellationToken)
    {
        var entity = user.ToEntity();
        _context.Users.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
