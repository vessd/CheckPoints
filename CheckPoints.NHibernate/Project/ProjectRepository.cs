using CheckPoints.Logic;
using CheckPoints.NHibernate.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckPoints.NHibernate
{
    public class ProjectRepository : ReadOnlyRepository<Project>, IProjectRepository
    {
        public async Task<IList<Project>> GetWithSets()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return await session.QueryOver<Project>().WhereRestrictionOn(p => p.Sets).IsNotEmpty.ListAsync();
            }
        }
    }
}
