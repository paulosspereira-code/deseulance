using Application.Common.Dtos;
using Application.Features.Auctions.Commands;
using Application.Features.Auctions.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Features.Auctions.Endpoints
{
    public static class AuctionEndpoints
    {
        public static void MapAuctionEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/auctions")
                           .WithTags("Auctions");

            group.MapPost("/", async (CreateAuctionCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.Created();
            })
            .WithName("CreateAuction")
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Create Leilão.",
                Description = "Recebe os dados de um novo leilão e cria o leilão correspondente."
            })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            // GET: /api/auctions
            group.MapGet("/", async ([AsParameters] GetAllAuctionQuery query, IMediator mediator, CancellationToken ct) =>
            {
                var result = await mediator.Send(query, ct);
                return Results.Ok(result);
            })
            .WithName("GetAllAuctions")
            .WithOpenApi(operation => new(operation)
            {
                 Summary = "Get All Leilões.",
                 Description = "Retorna uma lista de todos os leilões."
            })
            .Produces<List<AuctionDto>>(StatusCodes.Status200OK);

            // PUT: /api/auctions/{id}
            group.MapPut("/", async (
                [FromBody] UpdateAuctionCommand command,
                [FromServices] IMediator mediator,
                CancellationToken ct) =>
            {
                await mediator.Send(command);
                return Results.NoContent();
            })
            .WithName("UpdateAuction")
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Update Leilão.",
                Description = "Recebe um ID de leilão via parâmetro e atualiza o leilão correspondente."
            })
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            // DELETE: /api/auctions/{id}
            group.MapDelete("/{id:int}", async (
                [FromRoute] int id,
                [FromServices] IMediator mediator,
                [FromServices] IValidator<DeleteAuctionCommand> validator,
                CancellationToken ct) =>
            {
                var commandDelete = new DeleteAuctionCommand { Id = id };

                await mediator.Send(commandDelete);

                return Results.NoContent();
            })
            .WithName("DeleteAuction")
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Delete Leilão.",
                Description = "Recebe um ID de leilão via parâmetro e deleta o leilão correspondente."
            })
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            // GET: /api/auctions/{id}
            group.MapGet("/{id:int}", async (int id, IMediator mediator, CancellationToken ct) =>
            {
                var result = await mediator.Send(new GetByIdAuctionQuery { Id = id }, ct);

                return result is not null
                    ? Results.Ok(result)
                    : Results.NotFound(new { Message = $"Leilão {id} não encontrado." });
            })
            .WithName("GetAuctionById")
            .WithOpenApi(operation => new(operation)
             {
                 Summary = "Get Leilão by ID.",
                 Description = "Recebe um ID de leilão via parâmetro e retorna os detalhes do leilão correspondente."
            })
            .Produces<AuctionDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            // PUT: /api/auctions/{id}/finish
            group.MapPut("/finish", async (
               [FromBody] FinishAuctionCommand command,
               [FromServices] IMediator mediator,
               CancellationToken ct) =>
            {
                await mediator.Send(command);
                return Results.NoContent();
            })
           .WithName("FinishAuction")
           .WithOpenApi(operation => new(operation)
           {
               Summary = "Finish Leilão.",
               Description = "Recebe um ID de leilão via parâmetro e finaliza o leilão correspondente."
           })
           .Produces(StatusCodes.Status204NoContent)
           .Produces(StatusCodes.Status400BadRequest)
           .Produces(StatusCodes.Status404NotFound);

        }
    }
}
