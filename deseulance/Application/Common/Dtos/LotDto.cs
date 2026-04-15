

using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos
{
    public class LotDto : IMapFrom<Lot>
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
