using Application.Features.AuctionBids.Commands;
using FluentValidation;
using MediatR;

namespace API.Features.AuctionBids.Endpoints
{
    public static class AuctionBidEndpoints
    {
        public static void MapAuctionBidEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/auction-bids")
                           .WithTags("AuctionBids");

            group.MapPost("/", async (CreateAuctionBidCommand command, IMediator mediator) =>
            {
                await mediator.Send(command);
                return Results.Created();
            })
            .WithName("CreateAuctionBid")
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Efetuar o lance.",
                Description = "Recebe os dados do lance, valida e cria o lance"
            })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        }
    }
}

