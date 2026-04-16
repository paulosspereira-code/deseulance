using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public Task AddAsync(UserClient entity, CancellationToken cancellationToken)
            => userRepository.AddAsync(entity, cancellationToken);

        public Task<bool> CheckExist(string email, CancellationToken cancellationToken = default)
            => userRepository.CheckExist(email, cancellationToken);

        public IQueryable<UserClient> GetUsers() => userRepository.GetUsers();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => userRepository.SaveChangesAsync(cancellationToken);
    }
}
