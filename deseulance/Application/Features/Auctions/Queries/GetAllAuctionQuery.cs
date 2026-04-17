using Application.Common.Dtos;
using Application.Common.Interfaces.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auctions.Queries
{
    public class GetAllAuctionQuery: IRequest<List<AuctionDto>>
    {
        // TO DO: Add filtering by date
    }
    public class GetAllAuctionQueryHandler(
        IAuctionService auctionService,
        IMapper mapper) : IRequestHandler<GetAllAuctionQuery, List<AuctionDto>>
    {

        public async Task<List<AuctionDto>> Handle(GetAllAuctionQuery request, CancellationToken cancellationToken)
        {
            var query = auctionService.GetAll();

            return await query.ProjectTo<AuctionDto>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
