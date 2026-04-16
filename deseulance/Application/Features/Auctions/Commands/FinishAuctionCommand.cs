using Application.Common.Interfaces.Services;
using FluentValidation;
using MediatR;

namespace Application.Features.Auctions.Commands
{
    public class FinishAuctionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class FinishAuctionCommandHandler(
        IAuctionService auctionService,
        IValidator<FinishAuctionCommand> validator) : IRequestHandler<FinishAuctionCommand, Unit>
    {
        public async Task<Unit> Handle(FinishAuctionCommand request, CancellationToken ct)
        {

            await validator.ValidateAndThrowAsync(request, ct);

            var auction = await auctionService.GetByIdAsync(request.Id, ct);

            auction!.FinishAuction();

            auctionService.Update(auction);

            await auctionService.SaveChangesAsync(ct);

            return Unit.Value;
        }
    }
}
