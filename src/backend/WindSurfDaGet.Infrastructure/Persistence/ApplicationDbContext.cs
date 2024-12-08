using Microsoft.EntityFrameworkCore;
using WindSurfDaGet.Infrastructure.Persistence.Entities;
using WindSurfDaGet.Infrastructure.Persistence.Configurations;

namespace WindSurfDaGet.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
