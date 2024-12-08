using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WindSurfDaGet.Domain.Repositories;
using WindSurfDaGet.Domain.Common.Interfaces;
using WindSurfDaGet.Infrastructure.Persistence;
using WindSurfDaGet.Infrastructure.Persistence.Repositories;
using WindSurfDaGet.Infrastructure.Services;

namespace WindSurfDaGet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
