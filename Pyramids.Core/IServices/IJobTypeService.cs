using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IJobTypeService : IService<JobType> {

        Task<JobType> GetJobTypeByName(string name, int companyId);
    }
}
