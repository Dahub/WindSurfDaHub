using MediatR;

namespace WindSurfDaGet.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Email, string Username, string Password) : IRequest<int>;
