using Domain.Entities;

namespace Application.Common.Interfaces.Services
{
    public interface ILotService
    {
        IQueryable<Lot> GetLotsByIdAuction(int auctionId, CancellationToken cancellationToken);
        void DeleteRange(List<Lot> lots);
    }
}
