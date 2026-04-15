
namespace Application.Common.Interfaces.Repositories
{
    public interface IReadOnlyRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
