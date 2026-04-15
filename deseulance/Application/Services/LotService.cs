using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class LotService(ILotRepository lotRepository) : ILotService
    {
        public Task<List<Lot>> GetAllAsync(int auctionId, CancellationToken cancellationToken)
            => lotRepository.GetAllAsync(auctionId, cancellationToken);
    }
}
