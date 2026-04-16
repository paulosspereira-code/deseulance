
using Application.Common.Dtos;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;

namespace Application.Features.Auctions.Commands
{
    public class UpdateAuctionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime AuctionDate { get; set; }
        public List<LotDto>? Lots { get; set; }
    }

    public class UpdateAuctionCommandHandler(
    IAuctionService auctionService,
        IValidator<UpdateAuctionCommand> validator) : IRequestHandler<UpdateAuctionCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateAuctionCommand request, CancellationToken ct)
        {

            await validator.ValidateAndThrowAsync(request, ct);
            // 1. Busca a entidade no banco (incluindo os lotes para o EF rastrear a substituição)
            var auction = await auctionService.GetByIdAsync(request.Id, ct);

            auction!.Update(request.Title, request.AuctionDate);

                if (request.Lots != null)
                {
                    // Mapeia DTOs para Entidades de Lote (pode usar AutoMapper aqui se preferir)
                    var newLots = request.Lots.Select(l => new Lot(l.Title, l.Price));
                    auction.UpdateLots(newLots);
                }

            // 3. Persiste as mudanças
            auctionService.Update(auction);
            await auctionService.SaveChangesAsync(ct);


                return Unit.Value;
        }
    }
}
