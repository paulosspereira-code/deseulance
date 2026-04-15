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

        public Auction(string title, DateTime auctionDate)
        {
            Title = title;
            AuctionDate = auctionDate;
            Status = EAuctionStatus.Aberto;
        }

        public void FinishAuction()
        {
            Status = EAuctionStatus.Encerrado;
        }

        public void Update(string title, DateTime auctionDate)
        {
            Title = title;
            AuctionDate = auctionDate;
        }

        /// <summary>
        /// Substitui os lotes atuais por uma nova coleção.
        /// </summary>
        public void UpdateLots(IEnumerable<Lot> newLots)
        {
            if (Status != EAuctionStatus.Aberto)
            {
                throw new InvalidOperationException("Não é possível alterar lotes de um leilão encerrado ou finalizado.");
            }

            _lots.Clear();

            foreach (var lot in newLots)
            {
                _lots.Add(lot);
            }
        }
    }
}
