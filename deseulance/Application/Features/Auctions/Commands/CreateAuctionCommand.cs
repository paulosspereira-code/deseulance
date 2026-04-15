using Application.Common.Dtos;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Auctions.Commands
{
    public class CreateAuctionCommand : IRequest<Unit>
    {
        public string Title { get; set; } = string.Empty;
        public DateTime? AuctionDate { get; set; }
        public List<LotDto> Lots { get; set; } = [];
    }

    public class CreateAuctionCommandHandler(
        IAuctionService auctionService,
        IValidator<CreateAuctionCommand> validator) : IRequestHandler<CreateAuctionCommand, Unit>
    {

        public async Task<Unit> Handle(CreateAuctionCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var lots = request.Lots
                    .Select(dto => new Lot(dto.Title, dto.Price))
                    .ToList();

            var auction = new Auction(request.Title, request.AuctionDate!.Value, lots);
            await auctionService.AddAsync(auction, cancellationToken);
            await auctionService.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
