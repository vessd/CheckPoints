using CheckPoints.Logic.Common;
using System.Threading.Tasks;

namespace CheckPoints.NHibernate.Common
{
    public abstract class Repository<T> : ReadOnlyRepository<T>, IRepository<T>
        where T : AggregateRoot
    {
        public async Task SaveAsync(T aggregateRoot)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    await session.SaveOrUpdateAsync(aggregateRoot);
                    await transaction.CommitAsync();
                }
            }
        }
    }
}
