using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LotRepository(DeseulanceDbContext context) : ILotRepository
    {
        public async Task<List<Lot>> GetAllAsync(int auctionId, CancellationToken cancellationToken)
        {
            return await context.Lots
                .AsNoTracking()
                .Where(l => l.AuctionId == auctionId && l.IsActive)
                .ToListAsync(cancellationToken);
        }
    }
}
