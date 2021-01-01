using CheckPoints.Logic;
using System.Threading.Tasks;

namespace CheckPoints.NHibernate
{
    public abstract class ReadOnlyRepository<T>
        where T : AggregateRoot
    {
        public async Task<T> GetById(long id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return await session.GetAsync<T>(id);
            }
        }
    }
}
