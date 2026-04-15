using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class AuctionService(IAuctionRepository auctionRepository) : IAuctionService
    {
        public Task AddAsync(Auction entity, CancellationToken cancellationToken)
            => auctionRepository.AddAsync(entity, cancellationToken);

        public void Delete(Auction entity)
            => auctionRepository.Delete(entity);

        public Task<List<Auction>> GetAllAsync(CancellationToken cancellationToken)
            => auctionRepository.GetAllAsync(cancellationToken);

        public Task<Auction?> GetByIdAsync(int id, CancellationToken cancellationToken)
            => auctionRepository.GetByIdAsync(id, cancellationToken);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => auctionRepository.SaveChangesAsync(cancellationToken);

        public void Update(Auction entity)
            => auctionRepository.Update(entity);
    }
}
