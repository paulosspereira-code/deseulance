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
        Task<List<Auction>> GetAllAsync(CancellationToken cancellationToken);
    }
}
