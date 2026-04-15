using Domain.Entities;

namespace Application.Common.Interfaces.Services
{
    public interface IAuctionBidService
    {
        Task AddAsync(AuctionBid entity, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<List<AuctionBid>> GetAllAsync(int auctionId, CancellationToken cancellationToken);
    }
}
