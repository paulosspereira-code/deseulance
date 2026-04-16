using Domain.Enums;

namespace Domain.Entities
{
    public class Auction
    {
        public int IdAuction { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public EAuctionStatus Status { get; private set; }
        public DateTime AuctionDate { get; private set; }
        public bool IsActive { get; private set; }

        private readonly List<Lot> _lots = new();
        public IReadOnlyCollection<Lot> Lots => _lots.AsReadOnly();

        protected Auction() { }

        public Auction(
            string title,
            DateTime auctionDate,
            List<Lot> lots)
        {
            Title = title;
            AuctionDate = auctionDate;
            Status = EAuctionStatus.Aberto;
            IsActive = true;

            if (lots != null)
            {
                _lots.AddRange(lots);
            }

        }

        public void AddLot(Lot lot)
        {
            EnsureAuctionIsAberto();
            _lots.Add(lot);
        }

        public void FinishAuction()
        {
            Status = EAuctionStatus.Encerrado;
        }

        public void Update(string title, DateTime auctionDate)
        {
            EnsureAuctionIsAberto();
            Title = title;
            AuctionDate = auctionDate;
        }

        /// <summary>
        /// Substitui os lotes atuais por uma nova coleção.
        /// </summary>
        public void UpdateLots(IEnumerable<Lot> newLots)
        {
            EnsureAuctionIsAberto();

            _lots.Clear();
            _lots.AddRange(newLots);
        }

        private void EnsureAuctionIsAberto()
        {
            if (Status != EAuctionStatus.Aberto)
            {
                throw new InvalidOperationException("Operação não permitida: O leilão não está mais aberto.");
            }
        }
    }
}
