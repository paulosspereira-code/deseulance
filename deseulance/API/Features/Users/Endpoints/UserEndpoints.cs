using Application.Common.Dtos;
using Application.Features.Users.Commands;
using Application.Features.Users.Queries;
using FluentValidation;
using MediatR;

namespace API.Features.Users.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/users")
                           .WithTags("Users");

            group.MapPost("/", async (CreateUserCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.Created();
            })
            .WithName("CreateUser")
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Create User.",
                Description = "Recebe os dados de um novo usuário e cria o usuário correspondente."
            })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            
            group.MapGet("/", async ([AsParameters] GetUsersQuery query, IMediator mediator, CancellationToken ct) =>
            {
                var result = await mediator.Send(query, ct);
                return Results.Ok(result);
            })
            .WithName("GetUsersQuery")
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Get All Users.",
                Description = "Retorna uma lista de todos os usuários."
            })
            .Produces<List<AuctionDto>>(StatusCodes.Status200OK);

           

        }
    }
}
