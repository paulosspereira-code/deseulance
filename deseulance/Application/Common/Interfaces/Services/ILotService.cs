using Domain.Entities;

namespace Application.Common.Interfaces.Services
{
    public interface ILotService
    {
        Task<List<Lot>> GetAllAsync(int auctionId, CancellationToken cancellationToken);
    }
}
