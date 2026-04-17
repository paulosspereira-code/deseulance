using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DeseulanceDbContext : DbContext, IApplicationDbContext
{
    public DeseulanceDbContext(DbContextOptions<DeseulanceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Auction> Auctions => Set<Auction>();
    public DbSet<AuctionBid> AuctionBids => Set<AuctionBid>();
    public DbSet<Lot> Lots => Set<Lot>();
    public DbSet<UserClient> UserClients => Set<UserClient>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeseulanceDbContext).Assembly);
    }
}
