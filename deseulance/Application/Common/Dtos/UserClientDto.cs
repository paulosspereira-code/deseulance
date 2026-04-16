
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Common.Dtos
{
    public class UserClientDto : IMapFrom<UserClient>
    {
        public int IdUserClient { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
    }
}
