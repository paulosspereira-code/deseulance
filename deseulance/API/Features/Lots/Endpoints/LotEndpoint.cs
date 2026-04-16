using Application.Common.Dtos;
using Application.Features.Lots.Queries;
using MediatR;

namespace API.Features.Lots.Endpoints
{
    public static class LotEndpoint
    {
        public static void MapLotEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/lots")
                           .WithTags("Lots");

            group.MapGet("/{idAuction:int}/lots", async (int idAuction, IMediator mediator, CancellationToken ct) =>
            {
                var query = new GetLotsByIdAuctionQuery { IdAuction = idAuction };
                var result = await mediator.Send(query, ct);

                return Results.Ok(result);
            })
            .WithName("GetLotsByAuctionId")
            .WithOpenApi(operation => new(operation)
            {
                    Summary = "Busca Lotes por ID de Leilão",
                    Description = "Recebe o ID de um leilão e retorna os lotes correspondentes."
            })
            .Produces<List<LotDto>>(StatusCodes.Status200OK);

        }
    }
}
