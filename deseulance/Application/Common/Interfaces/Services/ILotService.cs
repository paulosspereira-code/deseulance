using Domain.Entities;

namespace Application.Common.Interfaces.Services
{
    public interface ILotService
    {
        IQueryable<Lot> GetLotsByIdAuction(int auctionId, CancellationToken cancellationToken);
        void DeleteRange(List<Lot> lots);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<Lot?> GetByIdAsync(int id, CancellationToken cancellationToken);
        void Update(Lot entity);
        Task<bool> CheckDeactivate(int id, CancellationToken cancellationToken = default);
    }
}
