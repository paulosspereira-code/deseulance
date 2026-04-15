using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<UserClient> UserClients { get; }
        DbSet<Auction> Auctions { get; }
        DbSet<AuctionBid> AuctionBids { get; }
        DbSet<Lot> Lots { get; }        
    }
}
