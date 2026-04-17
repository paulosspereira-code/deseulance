using Domain.Entities;

namespace Application.Common.Interfaces.Services
{
    public interface IAuctionService
    {
        Task AddAsync(Auction entity, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void Update(Auction entity);
        void Delete(Auction entity);
        Task<Auction?> GetByIdAsync(int id, CancellationToken cancellationToken);
        IQueryable<Auction> GetAll();
        Task<bool> CheckExist(int id, CancellationToken cancellationToken = default);
        Task<bool> CheckFinish(int id, CancellationToken cancellationToken = default);
    }
}
