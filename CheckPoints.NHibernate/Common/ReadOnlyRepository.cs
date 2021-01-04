using CheckPoints.Logic.Common;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckPoints.NHibernate.Common
{
    public abstract class ReadOnlyRepository<T> : IReadOnlyRepository<T>
        where T : AggregateRoot
    {
        public async Task<List<T>> GetAllAsync()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return await session.Query<T>().ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return await session.GetAsync<T>(id);
            }
        }
    }
}
