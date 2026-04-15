using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class AuctionBidService(IAuctionBidRepository auctionBidRepository) : IAuctionBidService
    {
        public Task AddAsync(AuctionBid entity, CancellationToken cancellationToken)
            => auctionBidRepository.AddAsync(entity, cancellationToken);

        public Task<List<AuctionBid>> GetAllAsync(int auctionId, CancellationToken cancellationToken)
            => auctionBidRepository.GetAllAsync(auctionId, cancellationToken);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => auctionBidRepository.SaveChangesAsync(cancellationToken);
    }
}
