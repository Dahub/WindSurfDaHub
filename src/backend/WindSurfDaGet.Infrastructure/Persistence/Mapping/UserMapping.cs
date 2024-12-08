using WindSurfDaGet.Domain.Models;
using WindSurfDaGet.Infrastructure.Persistence.Entities;

namespace WindSurfDaGet.Infrastructure.Persistence.Mapping;

internal static class UserMapping
{
    public static User ToDomain(this UserEntity entity)
    {
        return User.FromPersistence(
            entity.Id,
            entity.Email,
            entity.Username,
            entity.PasswordHash);
    }

    public static UserEntity ToEntity(this User domainModel)
    {
        return new UserEntity
        {
            Id = domainModel.Id,
            Email = domainModel.Email,
            Username = domainModel.Username,
            PasswordHash = domainModel.PasswordHash
        };
    }
}
