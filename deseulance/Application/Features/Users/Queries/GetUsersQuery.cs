using Application.Common.Dtos;
using Application.Common.Interfaces.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries
{
    public class GetUsersQuery : IRequest<List<UserClientDto>>
    {
        // TO DO: Add filtering by email or name
    }

    public class GetUsersQueryHandler(
    IUserService userService,
    IMapper mapper) : IRequestHandler<GetUsersQuery, List<UserClientDto>>
    {
        public async Task<List<UserClientDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = userService.GetUsers();

            return await query.ProjectTo<UserClientDto>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
