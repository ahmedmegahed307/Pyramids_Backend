using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IPriorityRepository : IGenericRepository<Priority>
    {
        Task<Priority> GetJobPriorityByName(string name);
    }
}
