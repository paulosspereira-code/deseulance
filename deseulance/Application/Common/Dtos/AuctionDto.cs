using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Dtos
{
    public class AuctionDto : IMapFrom<Auction>
    {
        public int IdAuction { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime AuctionDate { get; set; }
        public List<LotDto> Lots { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Auction, AuctionDto>()
                .ForMember(dest => dest.Lots, opt => opt.MapFrom(src => src.Lots));
        }
    }
}
