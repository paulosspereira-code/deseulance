using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuctionRepository(DeseulanceDbContext context) : IAuctionRepository
    {
        public virtual async Task AddAsync(Auction entity, CancellationToken cancellationToken)
                => await context.AddAsync(entity, cancellationToken);

        public async Task<bool> CheckExist(int id, CancellationToken cancellationToken = default)
        {
            return await context.Auctions.AnyAsync(a => a.IdAuction == id, cancellationToken);
        }

        public virtual void Delete(Auction entity)
            => context.Remove(entity);

        public IQueryable<Auction> GetAll()
        {
            return context.Auctions.AsNoTracking();
        }

        public async Task<Auction?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Auctions
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.IdAuction == id, cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => await context.SaveChangesAsync(cancellationToken);

        public virtual void Update(Auction entity)
                => context.Update(entity);

    }
}
