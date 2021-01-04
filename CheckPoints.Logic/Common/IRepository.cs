using System.Threading.Tasks;

namespace CheckPoints.Logic.Common
{
    public interface IRepository<T> : IReadOnlyRepository<T>
    {
        Task SaveAsync(T aggregateRoot);
    }
}
