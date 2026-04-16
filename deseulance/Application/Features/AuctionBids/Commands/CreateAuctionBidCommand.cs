using Application.Common.Interfaces.Services;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.AuctionBids.Commands
{
    public class CreateAuctionBidCommand : IRequest<Unit>
    {
        public int LotId { get; set; }
        public int UserClientId { get; set; }
        public int AuctionId { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime AuctionBidDate { get; set; }
    }

    public class CreateAuctionBidCommandHandler(
        IAuctionBidService auctionBidService,
        IValidator<CreateAuctionBidCommand> validator) : IRequestHandler<CreateAuctionBidCommand, Unit>
    {

        public async Task<Unit> Handle(CreateAuctionBidCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var auctionBid = new AuctionBid(request.LotId, request.UserClientId, request.AuctionId, request.BidAmount, request.AuctionBidDate);
           
            await auctionBidService.AddAsync(auctionBid, cancellationToken);
            
            await auctionBidService.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}
