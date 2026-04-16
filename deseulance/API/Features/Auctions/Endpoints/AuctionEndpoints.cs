using Application.Common.Dtos;
using Application.Features.Auctions.Commands;
using Application.Features.Auctions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            // GET: /api/auctions
            group.MapGet("/", async ([AsParameters] GetAllAuctionQuery query, IMediator mediator, CancellationToken ct) =>
            {
                var result = await mediator.Send(query, ct);
                return Results.Ok(result);
            })
            .WithName("GetAllAuctions")
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
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
