using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckPoints.Logic.Common
{
    public interface IReadOnlyRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(long id);
    }
}
