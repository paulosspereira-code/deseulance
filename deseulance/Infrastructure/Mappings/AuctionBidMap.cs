using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class AuctionBidMap : IEntityTypeConfiguration<AuctionBid>
{
    public void Configure(EntityTypeBuilder<AuctionBid> builder)
    {
        builder.ToTable("AuctionBid");

        builder.HasKey(x => x.IdAuctionBid);

        builder.Property(x => x.IdAuctionBid)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.BidAmount)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.AuctionBidDate)
            .IsRequired();

        builder.Property(x => x.LotId)
            .IsRequired();

        builder.Property(x => x.UserClientId)
            .IsRequired();

        builder.Property(x => x.AuctionId)
            .IsRequired();

        builder.HasOne(x => x.Auction)
            .WithMany()
            .HasForeignKey(x => x.AuctionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Lot)
            .WithMany()
            .HasForeignKey(x => x.LotId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.UserClient)
            .WithMany()
            .HasForeignKey(x => x.UserClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
