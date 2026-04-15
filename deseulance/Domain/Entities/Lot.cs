
namespace Domain.Entities
{
    public class Lot
    {
        public int IdLot { get; private set; }
        public int AuctionId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }

        public virtual Auction Auction { get; private set; } = default!;

        protected Lot() { }

        public Lot(string title, decimal price)
        {
            Title = title;
            Price = price;
            IsActive = true;
        }
    }
}
