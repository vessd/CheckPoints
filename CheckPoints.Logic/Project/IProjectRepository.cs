using CheckPoints.Logic.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckPoints.Logic
{
    public interface IProjectRepository : IReadOnlyRepository<Project>
    {
        Task<IList<Project>> GetWithSets();
    }
}
