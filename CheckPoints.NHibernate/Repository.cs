using CheckPoints.Logic;
using System.Threading.Tasks;

namespace CheckPoints.NHibernate
{
    public abstract class Repository<T> : ReadOnlyRepository<T>
        where T : AggregateRoot
    {
        public async Task Save(T aggregateRoot)
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
