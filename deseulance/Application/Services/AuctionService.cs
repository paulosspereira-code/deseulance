using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class AuctionService(IAuctionRepository auctionRepository) : IAuctionService
    {
        public Task AddAsync(Auction entity, CancellationToken cancellationToken)
            => auctionRepository.AddAsync(entity, cancellationToken);

        public async Task<bool> CheckExist(int id, CancellationToken cancellationToken = default)
        {
            return await auctionRepository.CheckExist(id, cancellationToken);
        }

        public void Delete(Auction entity)
            => auctionRepository.Delete(entity);

        public IQueryable<Auction> GetAll() => auctionRepository.GetAll();

        public Task<Auction?> GetByIdAsync(int id, CancellationToken cancellationToken)
            => auctionRepository.GetByIdAsync(id, cancellationToken);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => auctionRepository.SaveChangesAsync(cancellationToken);

        public void Update(Auction entity)
            => auctionRepository.Update(entity);
    }
}
