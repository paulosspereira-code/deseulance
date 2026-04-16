using Domain.Entities;

namespace Application.Common.Interfaces.Repositories
{
    public interface ILotRepository
    {
        IQueryable<Lot> GetLotsByIdAuction(int auctionId, CancellationToken cancellationToken);
        void DeleteRange(List<Lot> lots);
    }
}
