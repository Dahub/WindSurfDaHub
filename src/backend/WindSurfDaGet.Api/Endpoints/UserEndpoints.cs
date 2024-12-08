using MediatR;
using Microsoft.AspNetCore.Mvc;
using WindSurfDaGet.Application.Users.Commands.CreateUser;
using WindSurfDaGet.Application.Users.Queries.LoginUser;

namespace WindSurfDaGet.Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users", async (
            [FromBody] CreateUserRequest request,
            ISender mediator) =>
        {
            try
            {
                var command = new CreateUserCommand(request.Email, request.Username, request.Password);
                var userId = await mediator.Send(command);
                return Results.Created($"/api/users/{userId}", userId);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("email existe déjà"))
            {
                return Results.Conflict(new { message = ex.Message });
            }
            catch (Exception)
            {
                return Results.BadRequest(new { message = "Une erreur est survenue lors de la création de l'utilisateur" });
            }
        })
        .WithName("CreateUser")
        .WithOpenApi();

        app.MapPost("/api/users/login", async (
            [FromBody] LoginUserRequest request,
            ISender mediator) =>
        {
            var query = new LoginUserQuery(request.Email, request.Password);
            var result = await mediator.Send(query);
            
            if (result.Success)
            {
                return Results.Ok(new { token = result.Token, username = result.Username });
            }
            
            return Results.Unauthorized();
        })
        .WithName("LoginUser")
        .WithOpenApi();
    }
}

public record CreateUserRequest(string Email, string Username, string Password);
public record LoginUserRequest(string Email, string Password);
