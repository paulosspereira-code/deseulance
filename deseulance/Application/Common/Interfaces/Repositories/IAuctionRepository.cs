

using Domain.Entities;

namespace Application.Common.Interfaces.Repositories
{
    public interface IAuctionRepository
    {
        Task AddAsync(Auction entity, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void Update(Auction entity);
        void Delete(Auction entity);
        Task<Auction?> GetByIdAsync(int id, CancellationToken cancellationToken);
        IQueryable<Auction> GetAll();
        Task<bool> CheckExist(int id, CancellationToken cancellationToken = default);

    }
}
