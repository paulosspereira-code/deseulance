

using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos
{
    public class LotDto : IMapFrom<Lot>
    {
        public int IdLot { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
