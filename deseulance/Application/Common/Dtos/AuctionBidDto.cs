

using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos
{
    public class AuctionBidDto : IMapFrom<AuctionBid>
    {
        public int IdAuctionBid { get; set; }
        public int LotId { get; set; }
        public int UserClientId { get; set; }
        public int AuctionId { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime AuctionBidDate { get; set; }
    }
}
