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

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await lotRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<Lot?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await lotRepository.GetByIdAsync(id, cancellationToken);
        }

        public IQueryable<Lot> GetLotsByIdAuction(int auctionId, CancellationToken cancellationToken)
            => lotRepository.GetLotsByIdAuction(auctionId, cancellationToken);

        public void Update(Lot entity)
             => lotRepository.Update(entity);

        public async Task<bool> CheckDeactivate(int id, CancellationToken cancellationToken = default)
        {
            return await lotRepository.CheckDeactivate(id, cancellationToken);
        }
    }
}
