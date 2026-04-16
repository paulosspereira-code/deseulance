using Application.Common.Interfaces.Services;
using MediatR;

namespace Application.Features.Auctions.Commands
{
    public class DeleteAuctionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteAuctionCommandHandler(
  IAuctionService auctionService,
  ILotService lotService) : IRequestHandler<DeleteAuctionCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteAuctionCommand request, CancellationToken ct)
        {

            var auction = await auctionService.GetByIdAsync(request.Id, ct);

            lotService.DeleteRange(auction!.Lots.ToList());

            auctionService.Delete(auction!);

            await auctionService.SaveChangesAsync(ct);

            return Unit.Value;
        }
    }
}
