using Domain.Entities;

namespace Application.Common.Interfaces.Services
{
    public interface IAuctionBidService
    {
        Task AddAsync(AuctionBid entity, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<List<AuctionBid>> GetAllAsync(int auctionId, CancellationToken cancellationToken);
        Task<decimal> GetMaxBidAmountByLotIdAsync(int lotId, CancellationToken cancellationToken);
        Task<AuctionBid?> GetWinnerAsync(int lotId, int auctionId, CancellationToken cancellationToken);
    }
}
