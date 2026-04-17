using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuctionBidRepository(DeseulanceDbContext context) : IAuctionBidRepository
    {
        public virtual async Task AddAsync(AuctionBid entity, CancellationToken cancellationToken)
                => await context.AddAsync(entity, cancellationToken);

        public async Task<List<AuctionBid>> GetAllAsync(int auctionId, CancellationToken cancellationToken)
        {
            return await context.AuctionBids
                .Where(ab => ab.AuctionId == auctionId)
                .ToListAsync(cancellationToken);
        }

        public async Task<decimal> GetMaxBidAmountByLotIdAsync(int lotId, CancellationToken cancellationToken)
        {
            return await context.AuctionBids
                .Where(ab => ab.LotId == lotId)
                .MaxAsync(ab => (decimal?)ab.BidAmount, cancellationToken) ?? 0m;
        }

        public async Task<AuctionBid?> GetWinnerAsync(int lotId, int auctionId, CancellationToken cancellationToken)
        {
            return await context.AuctionBids
                .Where(ab => ab.LotId == lotId && ab.AuctionId == auctionId)
                .OrderByDescending(ab => ab.BidAmount)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => await context.SaveChangesAsync(cancellationToken);
    }
}
