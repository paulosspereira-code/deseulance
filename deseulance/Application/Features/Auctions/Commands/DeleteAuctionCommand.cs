using Application.Common.Interfaces.Services;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Auctions.Commands
{
    public class DeleteAuctionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteAuctionCommandHandler(
  IAuctionService auctionService, IValidator<DeleteAuctionCommand> validator,
  ILotService lotService) : IRequestHandler<DeleteAuctionCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteAuctionCommand request, CancellationToken ct)
        {
           await validator.ValidateAsync(request, ct);

            var auction = await auctionService.GetByIdAsync(request.Id, ct);

            lotService.DeleteRange(auction!.Lots.ToList());

            auctionService.Delete(auction!);

            await auctionService.SaveChangesAsync(ct);

            return Unit.Value;
        }
    }
}
