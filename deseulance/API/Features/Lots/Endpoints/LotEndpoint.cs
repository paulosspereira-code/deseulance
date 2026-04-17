using Application.Common.Dtos;
using Application.Features.Auctions.Commands;
using Application.Features.Lots.Commands;
using Application.Features.Lots.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Lots.Endpoints
{
    public static class LotEndpoint
    {
        public static void MapLotEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/lots")
                           .WithTags("Lots");

            // GET: /api/auctions/{id}/lots
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

            // PUT: /api/lots/deactivate
            group.MapPut("/deactivate", async (
               [FromBody] DeactivateLotCommand command,
               [FromServices] IMediator mediator,
               CancellationToken ct) =>
                        {
                            await mediator.Send(command);
                            return Results.NoContent();
                        })
            .WithName("Deactivate")
            .WithOpenApi(operation => new(operation)
            {
               Summary = "Desativar lote.",
               Description = "Recebe um ID de lote via parâmetro e desativa o lote correspondente."
            })
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

        }
    }
}
