using Domain.Entities;

namespace Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(UserClient entity, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> CheckExist(string email, CancellationToken cancellationToken = default);
        IQueryable<UserClient> GetUsers();
    }
}
