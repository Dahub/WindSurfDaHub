using MediatR;

namespace WindSurfDaGet.Application.Users.Queries.LoginUser;

public record LoginUserQuery(string Email, string Password) : IRequest<LoginUserResult>;

public record LoginUserResult
{
    public bool Success { get; init; }
    public string? Token { get; init; }
    public string? Username { get; init; }
    
    public static LoginUserResult Successful(string token, string username) =>
        new() { Success = true, Token = token, Username = username };
    
    public static LoginUserResult Failed() =>
        new() { Success = false };
}
