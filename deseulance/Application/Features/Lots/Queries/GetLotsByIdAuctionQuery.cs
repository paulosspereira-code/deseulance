using Application.Common.Dtos;
using Application.Common.Interfaces.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Lots.Queries
{
    public class GetLotsByIdAuctionQuery : IRequest<List<LotDto>>
    {
        public int IdAuction { get; set; }
    }

    public class GetLotsByIdAuctionQueryHandler(
       ILotService lotService,
       IMapper mapper) : IRequestHandler<GetLotsByIdAuctionQuery, List<LotDto>>
    {

        public async Task<List<LotDto>> Handle(GetLotsByIdAuctionQuery request, CancellationToken cancellationToken)
        {
            var query = lotService.GetLotsByIdAuction(request.IdAuction, cancellationToken);

            return await query.ProjectTo<LotDto>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
