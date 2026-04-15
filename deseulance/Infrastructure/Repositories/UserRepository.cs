using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository(DeseulanceDbContext context) : IUserRepository
    {
        public virtual async Task AddAsync(UserClient entity, CancellationToken cancellationToken)
                => await context.AddAsync(entity, cancellationToken);

        public async Task<bool> CheckExist(string email, CancellationToken cancellationToken = default)
        {
            return await context.UserClients
                .AsNoTracking()
                .AnyAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<UserClient?> GetByEmail(string email, CancellationToken cancellationToken = default)
        {
            return await context.UserClients
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => await context.SaveChangesAsync(cancellationToken);
    }
}
