using Domain.Entities;

namespace Application.Common.Interfaces.Services
{
    public interface IUserService
    {
        Task AddAsync(UserClient entity, CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> CheckExist(string email, CancellationToken cancellationToken = default);
        IQueryable<UserClient> GetUsers();
    }
}
