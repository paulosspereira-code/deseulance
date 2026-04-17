using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Domain.Enums;
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

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Lot?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Lots
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.IdLot == id, cancellationToken);
        }

        public IQueryable<Lot> GetLotsByIdAuction(int auctionId, CancellationToken cancellationToken)
        {
            return context.Lots
                .AsNoTracking()
                .Where(l => l.AuctionId == auctionId && l.IsActive);
        }

        public virtual void Update(Lot entity)
                => context.Update(entity);

        public async Task<bool> CheckDeactivate(int id, CancellationToken cancellationToken = default)
        {
            return await context.Lots.AnyAsync(a => a.IdLot == id && a.IsActive == false, cancellationToken);
        }
    }
}
