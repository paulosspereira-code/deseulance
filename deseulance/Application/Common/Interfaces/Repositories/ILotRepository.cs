using Domain.Entities;

namespace Application.Common.Interfaces.Repositories
{
    public interface ILotRepository
    {
        Task<List<Lot>> GetAllAsync(int auctionId, CancellationToken cancellationToken);
    }
}
