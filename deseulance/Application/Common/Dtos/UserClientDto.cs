
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos
{
    public class UserClientDto : IMapFrom<UserClient>
    {
        public int IdUserClient { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
