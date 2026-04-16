using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LotRepository(DeseulanceDbContext context) : ILotRepository
    {
        public void DeleteRange(List<Lot> lots)
        {
            context.Lots.RemoveRange(lots);
        }

        public IQueryable<Lot> GetLotsByIdAuction(int auctionId, CancellationToken cancellationToken)
        {
            return context.Lots
                .AsNoTracking()
                .Where(l => l.AuctionId == auctionId && l.IsActive);
        }
    }
}
