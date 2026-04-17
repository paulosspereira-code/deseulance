
namespace Domain.Entities
{
    public class AuctionBid
    {
        public int IdAuctionBid { get; private set; }
        public int LotId { get; private set; }
        public int UserClientId { get; private set; }
        public int AuctionId { get; private set; }  
        public decimal BidAmount { get; private set; }
        public DateTime AuctionBidDate { get; private set; }

        public virtual Auction Auction { get; private set; } = default!;
        public virtual Lot Lot { get; private set; } = default!;
        public virtual UserClient UserClient { get; private set; } = default!;

        protected AuctionBid() { }

        public AuctionBid(int lotId, int userClientId, int auctionId, decimal bidAmount, DateTime auctionBidDate)
        {
            LotId = lotId;
            UserClientId = userClientId;
            AuctionId = auctionId;
            BidAmount = bidAmount;
            AuctionBidDate = auctionBidDate;
        }
    }
}
