
using Application.Common.Dtos;
using Application.Common.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace Application.Features.Auctions.Queries
{
    public class GetByIdAuctionQuery : IRequest<AuctionDto?>
    {
        public int Id { get; set; }
    }

    public class GetByIdAuctionQueryHandler(
       IAuctionService auctionService,
       IMapper mapper) : IRequestHandler<GetByIdAuctionQuery, AuctionDto?>
    {

        public async Task<AuctionDto?> Handle(GetByIdAuctionQuery request, CancellationToken cancellationToken)
        {
            var auction = await auctionService.GetByIdAsync(request.Id, cancellationToken);

            return mapper.Map<AuctionDto?>(auction);
        }
    }
}
