using MediatR;
using Microsoft.EntityFrameworkCore;
using WindSurfDaGet.Domain.Repositories;
using WindSurfDaGet.Domain.Common.Interfaces;
using WindSurfDaGet.Domain.Models;

namespace WindSurfDaGet.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Vérifier si l'email existe déjà
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existingUser != null)
        {
            throw new InvalidOperationException("Un utilisateur avec cet email existe déjà");
        }

        var hashedPassword = _passwordHasher.HashPassword(request.Password);
        var user = User.Create(request.Email, request.Username, hashedPassword);

        try
        {
            await _userRepository.CreateAsync(user, cancellationToken);
            return user.Id;
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("IX_Users_Email") == true)
        {
            throw new InvalidOperationException("Un utilisateur avec cet email existe déjà");
        }
    }
}
