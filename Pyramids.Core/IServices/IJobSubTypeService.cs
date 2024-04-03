using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IJobSubTypeService : IService<JobSubType> 
    {

        Task<IEnumerable<JobSubType>> GetAllSubTypesByTypeId(int typeId);
        Task<JobSubType> GetJobSubTypeByName(string name, int companyId);

    }

}
