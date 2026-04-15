using Application.Features.Auctions.Commands;
using MediatR;

namespace API.Features.Commands
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
        }
    }
}
