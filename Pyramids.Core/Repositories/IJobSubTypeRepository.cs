using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IJobSubTypeRepository : IGenericRepository<JobSubType>
    {
        Task<IEnumerable<JobSubType>> GetAllSubTypesByTypeId(int typeId);
        Task<JobSubType> GetJobSubTypeByName(string name, int companyId);

    }
}
