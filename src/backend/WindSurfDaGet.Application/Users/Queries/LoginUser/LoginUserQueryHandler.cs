using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WindSurfDaGet.Domain.Common.Interfaces;
using WindSurfDaGet.Domain.Models;
using WindSurfDaGet.Domain.Repositories;

namespace WindSurfDaGet.Application.Users.Queries.LoginUser;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserQueryHandler(
        IUserRepository userRepository,
        IConfiguration configuration,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginUserResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user == null)
        {
            return LoginUserResult.Failed();
        }

        if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            return LoginUserResult.Failed();
        }

        var token = GenerateJwtToken(user);
        return LoginUserResult.Successful(token, user.Username);
    }

    private string GenerateJwtToken(Domain.Models.User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not found in configuration")));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Username)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
