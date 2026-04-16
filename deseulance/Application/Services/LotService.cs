using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class LotService(ILotRepository lotRepository) : ILotService
    {
        public void DeleteRange(List<Lot> lots)
        {
            lotRepository.DeleteRange(lots);
        }

        public IQueryable<Lot> GetLotsByIdAuction(int auctionId, CancellationToken cancellationToken)
            => lotRepository.GetLotsByIdAuction(auctionId, cancellationToken);
    }
}
